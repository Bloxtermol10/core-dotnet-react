using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class UsuarioVO 
    {
        public String Avatar  { get; set; }
        public Int32 IdEmpresa { get; set; }
        public Int32 idRol { get; set; }
        public String NomEmpresa { get; set; }
        public String NomEmpresa2 { get; set; }
        public String WebSite { get; set; }
        public String Dominio { get; set; }
        public String NomUsuario { get; set; }
        public String Token {get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 TipIdentificacion { get; set; }
        public Int32 esAdmon { get; set; }
        public Int32 idPregunta { get; set; }
        public Int32 idPregunta1Retornar { get; set; }
        public Int32 idPregunta2Retornar { get; set; }
        public Int32 idPregunta3Retornar { get; set; }
        public Int32 valorRespuesta1 { get; set; }
        public Int32 valorRespuesta2 { get; set; }
        public Int32 valorRespuesta3 { get; set; }
        public Int32 tipoUsuario { get; set; }
        public Int32 diligenciaFormulario { get; set; }
        public Int32 resultadoEnvioRespuestas { get; set; }
        public Int32 numRespuestasIncorrectas { get; set; }
        public String NumIdentificacion { get; set; }
        public String Nombre1 { get; set; }

        public String Nombre2 { get; set; }
        public String Apellido1 { get; set; }
        public String Apellido2 { get; set; }
        public String NombreCompleto { get; set; }
        public String desPregunta { get; set; }
        public String respuesta1 { get; set; }
        public String respuesta2 { get; set; }
        public String respuesta3 { get; set; }
        public String pasword1 { get; set; }
        public String pasword2 { get; set; }

        public List<RolVO> Rol { get; set; }
        public List<FormularioVO> Formulario { get; set; }
       
    }
}
