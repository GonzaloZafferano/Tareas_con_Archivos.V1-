using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaPassword
    {
        private static string password;
        private static bool tienePassword;

        static SistemaPassword()
        {
            SistemaPassword.TienePassword = false;
            SistemaPassword.password = string.Empty;
        }

        public static string Password
        {
            private get
            {
                return SistemaPassword.password;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("La contraseña esta vacia.");
                }
                else
                {
                    if(value.Length >= 4 && value.Length <= 12)
                    {
                        SistemaPassword.password = value;
                    }
                    else
                    {
                        throw new DatoInvalidoException("La contraseña debe tener entre 4 y 12 caracteres.");
                    }
                }
            }
        }

        public static bool TienePassword { get => tienePassword; set => tienePassword = value; }

        /// <summary>
        /// Verifica que la password recibida por parametro sea correcta.
        /// </summary>
        /// <param name="password">Password que se evaluara.</param>
        /// <returns>True si la password es correcta, caso contrario False.</returns>
        public static bool VerificarPassword(string password)
        {
            if(!string.IsNullOrWhiteSpace(password) && SistemaPassword.TienePassword && SistemaPassword.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
