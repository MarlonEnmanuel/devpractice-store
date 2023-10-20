using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Modules.Security
{
    // Cache de Tokens
    // Estructura del token -> { username, claims, roles, expiration }

    // Funcionalidad
    // 1. Poder registrar el token en la memoria cache
    // 2. Poder consulta el token desde la memoria
    // 3. Verificar si el token aun es valido para un usuario
    // 4. Caducar un token guardado en memoria
    // 5. Eliminar todos los tokens de la memoria
    // 6. Obtener todos los tokens de la memoria
    // 7. Eliminar tokens caducados

    public class AuthCacheService
    {
    }
}
