using Moq;
using Store.Core.Modules.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.Store.Core.Security
{
    public class AuthCacheServiceTest
    {
        private Mock<AuthCacheService> _serviceMock;
        private AuthCacheService _service;

        public AuthCacheServiceTest()
        {
            _serviceMock = new Mock<AuthCacheService>();
            _service = _serviceMock.Object;
        }

        [Fact]
        public void RegisterToken_ShouldRegister()
        {
            var token = "abcdefg";
            var username = "csamillan";
            var expiration = DateTime.Now.AddHours(1);

            var resp = _service.RegisterToken(token, username, expiration);

            Assert.True(resp);
        }

        [Fact]
        public void RegisterToken_ShouldNotRegisterDuplicatedTokens()
        {
            var token = "abcdefg";
            var username = "csamillan";
            var expiration = DateTime.Now.AddHours(1);

            var resp1 = _service.RegisterToken(token, username, expiration);
            var resp2 = _service.RegisterToken(token, username, expiration);
            var resp3 = _service.RegisterToken(token, "otherUser", expiration);

            Assert.True(resp1);
            Assert.False(resp2);
            Assert.False(resp3);
        }

        [Fact]
        public void RegisterToken_ShouldNotHasDuplicatedUser()
        {
            var username = "csamillan";
            var expiration = DateTime.Now.AddHours(1);

            var resp1 = _service.RegisterToken("abcdefg", username, expiration);
            var resp2 = _service.RegisterToken("1234567", username, expiration);
            var resp3 = _service.RegisterToken("xyz1234", username, expiration);

            Assert.True(resp1);
            Assert.False(resp2);
            Assert.False(resp3);
        }

        [Theory]
        [InlineData("abcd1111", "uverify1", true)]
        [InlineData("abcd2222", "uverify2", true)]
        [InlineData("abcd3336", "uverify3", false)]
        [InlineData("abcd4447", "uverify4", false)]
        public void VerifyToken_ShouldBeValid(string token, string username, bool showValid)
        {
            _service._cache["abcd1111"] = new CacheItem() { Username = "uverify1", Expiration = DateTime.Now.AddHours(1)};
            _service._cache["abcd2222"] = new CacheItem() { Username = "uverify2", Expiration = DateTime.Now.AddHours(1) };
            _service._cache["abcd3333"] = new CacheItem() { Username = "uverify3", Expiration = DateTime.Now.AddHours(1) };
            _service._cache["abcd4444"] = new CacheItem() { Username = "uverify4", Expiration = DateTime.Now.AddHours(1) };

            var resp1 = _service.IsValidToken(token, username);

            Assert.Equal(showValid, resp1);
        }

        [Fact]
        public void IsValidToken_VerifyExpirationDate()
        {
            var nowMock = new DateTime(2023, 10, 1, 12, 0, 0);

            _serviceMock.Setup(s => s.GetNow())
                        .Returns(() => nowMock);
            _service = _serviceMock.Object;

            _service._cache["abcd1111"] = new CacheItem() { Username = "uverify1", Expiration = nowMock.AddHours(1) };

            nowMock = nowMock.AddMinutes(30);
            var resp1 = _service.IsValidToken("abcd1111", "uverify1");
            Assert.True(resp1);

            nowMock = nowMock.AddMinutes(30);
            var resp2 = _service.IsValidToken("abcd1111", "uverify1");
            Assert.True(resp2);

            nowMock = nowMock.AddMinutes(30);
            var resp3 = _service.IsValidToken("abcd1111", "uverify1");
            Assert.False(resp3);
        }

        [Fact]
        public void IsValidToken_VerifyUsername()
        {
            _service._cache["abcd1111"] = new CacheItem() { Username = "uverify1", Expiration = DateTime.Now.AddMinutes(1) };

            var resp1 = _service.IsValidToken("abcd1111", "uverify1");

            var resp2 = _service.IsValidToken("abcd1111", "uverify2");

            Assert.True(resp1);
            Assert.False(resp2);
        }

    }
}
