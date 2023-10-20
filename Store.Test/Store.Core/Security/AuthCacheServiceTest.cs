using Store.Core.Modules.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.Store.Core.Security
{
    public class AuthCacheServiceTest
    {
        private AuthCacheService _service;

        public AuthCacheServiceTest()
        {
            _service = new AuthCacheService();
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
    }
}
