using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Modules.Security
{
    // Cache de Tokens
    // Estructura del token -> { username, claims, roles, expiration }

    // Funcionalidad
    // 1. Poder registrar el token en la memoria cache (durante el login) 👍
    //    - Permitir solo una sesión por usuario 👍
    // 2. Poder consulta el token desde la memoria
    // 3. Verificar si el token aun es valido para un usuario 👍
    //    - Token pertenezca al usuario a verificar
    //    - Token aún esté vigente 👍
    // 4. Caducar un token guardado en memoria
    // 5. Eliminar todos los tokens de la memoria
    // 6. Obtener todos los tokens de la memoria
    // 7. Eliminar tokens caducados

    public class AuthCacheService
    {
        public readonly ConcurrentDictionary<string, CacheItem> _cache = new();

        public AuthCacheService()
        {
        }

        public bool RegisterToken (string token, string username, DateTime expiration)
        {
            var allOkey = _cache.Values.All(x => x.Username != username);
            if (!allOkey)
                return false;

            return _cache.TryAdd(token, new CacheItem
            {
                Username = username,
                Expiration = expiration,
            });
        }

        public bool IsValidToken(string token)
        {
            var exists = _cache.TryGetValue(token, out var item);
            return exists && item.Expiration >= GetNow();
        }

        public virtual DateTime GetNow() => DateTime.Now;
    }

    public class CacheItem
    {
        public string Username { get; set; }
        public DateTime Expiration { get; set; }
    }
}

/// FLUJO DE AUTENTICACION (LOGIN)
/// 1. REcibies usuario y password
/// 2. Buscar en la tabla de usuarios
/// 3. Verificas que el password coincida
/// 4. Verificas estado del usuario (bloqueado, deshabilitado, eliminado, etc)
/// 5. Generas token de autenticación
/// 6. Guardar el token en cache <------------------
/// 7. Reponder al cliente con el token

/// FLUJO DE VERIFICACION
/// 1. Recibir el token
/// 2. Verificar el token en la memoria cache <------------
/// 3. Si el token es valido, permitir
/// 4. Sino responder con Unathorized

/// Panel de control de tokens de autenticación (Usuarios conectados)
/// 1. Listar tokes en memoria cache <--------
/// 2. Poder caducar los tokens <--------
/// 3. Poder eliminar todos los tokens <--------
/// 4. Limpiar tokens en desuso <--------
