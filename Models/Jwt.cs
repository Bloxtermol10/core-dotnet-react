using Core.Infraestructure;
using System.Security.Claims;

namespace Core.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        private readonly Seguridad _seguridad;

        protected IConfiguration configuration;

        public Jwt()
        {
        }
   
        private Jwt(Seguridad seguridad)
        {

            _seguridad = seguridad;
            configuration = _seguridad.configuration;
        }
        public dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0) {
                    return new
                    {
                        success = false,
                        message = "Verificar si estas enviento el token valido",
                        result = ""
                    };
                }

                var userName = identity.Claims.FirstOrDefault(x => x.Type == "userName").Value;

                UsuarioVO usuario = _seguridad.getUsuario(userName);

                return new
                {
                    success = true,
                    message = "Exito",
                    result = usuario,
                };
            }
            catch (Exception ex) {
                return new
                {
                    success = false,
                    message = "Catch" + ex.Message,
                    result = ""
                };
            }
        }
    }
}
