using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class PersonaVO
    {
        public int? idPersona { get; set; }
        public int? idUsuario { get; set; }
        public int? idTipoIde { get; set; }
        public int? numeroIde { get; set; }
        public string rutaAvatar { get; set; }
        public string nomPersona { get; set; }
        public string apePersona { get; set; }
        public string perfil { get; set; }
        public DateTime? fechaNac { get; set; }
        public int? edad { get; set; }
        public int? idCiudadNac { get; set; }
        public int? idSexo { get; set; }
        public string correoElectronico { get; set; }
        public string telefono { get; set; }
        public int? idCiudadResidencia { get; set; }
        public string ciudadResidencia { get; set; }
        public int? idRangoSalario { get; set; }
        public int? idModalidadTrabajo { get; set; }
        public string nomModalidadTrabajo { get; set; }
        public int? diligenciaBasicos { get; set; }
        public int? diligenciaPerfil { get; set; }
        public int? diligenciaAcademia { get; set; }
        public int? diligenciaExperiencia { get; set; }
        public int? diligenciaAptitud { get; set; }
        public string usuarioCrea { get; set; }
        public DateTime fechaCrea { get; set; }
        public string usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        public string typeModify { get; set; }
        public string nomMaxNivelEducativo { get; set; }
        public List<PersonaAcademiaVO> Academia { get; set; }
        public List<PersonaAptitudVO> Aptitud { get; set; }
        public List<PersonaExperienciaVO> Experiencia { get; set; }
    }
    
    public class PersonaAcademiaVO
    {
        public int? idUsuario { get; set; }
        public int? idPersona { get; set; }
        public int? idPersonaAcademia { get; set; }
        public int? idNivelEducativo { get; set; }
        public string nivelEducativo { get; set; }
        public int? idOcupacion { get; set; }
        public string nomInstitucion { get; set; }
        public string tituloFormacionAcademica { get; set; }
        public DateTime? fechaFinFormacion { get; set; }
        public int? idCiudadFormacion { get; set; }
        public string typeModify { get; set; }

    }
    public class PersonaAptitudVO
    {
        public int? idUsuario { get; set; }
        public int? idPersona { get; set; }
        public int? idPersonaAptitud { get; set; }
        public int? idAptitud { get; set; }
        public string nomAptitud { get; set; }
        public string typeModify { get; set; }
    }
    public class PersonaExperienciaVO
    {
        public int? idUsuario { get; set; }
        public int? idPersona { get; set; }
        public int? idPersonaExperiencia { get; set; }
        public string nomCargo { get; set; }
        public int? idNivelEducativo { get; set; }
        public int? idOcupacion { get; set; }
        public int? idCiudadCargo { get; set; }
        public DateTime? fechaIniCargo { get; set; }
        public DateTime? fechaFinCargo { get; set; }
        public int? tiempoCargo { get; set; }
        public string desCargo { get; set; }
        public string typeModify { get; set; }

    }
}
