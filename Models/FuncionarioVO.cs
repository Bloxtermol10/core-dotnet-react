using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class FuncionarioVO
    {
        public int IdFuncionario { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        
        //Manejo del Usuario. (Solo se va  a usar para crear usuario o resetear clave.)
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Dominio { get; set; }
        public int? IdRol { get; set; }
        //Fin

        public int TipIdentificacion { get; set; }
        public string NumIdentificacion { get; set; }
        public int IdPaisExpedicion { get; set; }
        public int IdProvinciaExpedicion { get; set; }
        public int IdCiudadExpedicion { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPaisNacimiento { get; set; }
        public int IdProvinciaNacimiento { get; set; }
        public int IdCiudadNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int? TipDoc { get; set; }
        public string NumDoc { get; set; }
        public int IdRH { get; set; }
        public int IdProfesion { get; set; }
        public int IdCargo { get; set; }
        public string nomCargo { get; set; }
        public int? IdJefe { get; set; }
        public string nomJefe { get; set; }
        public string Escalafon { get; set; }
        public string ResEscalafon { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public int EstadoCivil { get; set; }
        public string DireccionResidencia { get; set; }
        public string BarrioResidencia { get; set; }
        public string TelefonoResidencia { get; set; }
        public string TelefonoCelular { get; set; }
        public int IdPaisResidencia { get; set; }
        public int IdProvinciaResidencia { get; set; }
        public int IdCiudadResidencia { get; set; }
        public string CorreoElectronico { get; set; }
        public int IdAFP { get; set; }
        public int IdEPS { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public int IdEstrato { get; set; }
        public int IdTipoContrato { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

        public string ClaveActual { get; set; }
        public string ClaveNueva { get; set; }
        public string Usuario { get; set; }

        public string Observaciones { get; set; }

    }

    [Serializable]
    public class FuncionarioEstudiosVO
    {
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }
        public int IdTipoEstudio { get; set; }
        public string nombreEstudio { get; set; }
        public string Institucion { get; set; }
        public DateTime? FechaEstudio { get; set; }
        public string Titulo { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

    }

    [Serializable]
    public class FuncionarioExperienciasVO
    {
        public int IdEmpresa { get; set; }
        public int IdExperiencia { get; set; }
        public int IdFuncionario { get; set; }                
        public string Institucion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Cargo { get; set; }
        public string Jefe { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
    }


    [Serializable]
    public class SalidaFuncionarioVO
    {
        public int IdEmpresa { get; set; }
        public int IdSalidaFuncionario { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime FechaSalidaAuto { get; set; }
        public DateTime FechaRegresoAuto { get; set; }
        public DateTime? FechaSalidaReal { get; set; }
        public DateTime? FechaRegresoReal { get; set; }
        public string Observaciones { get; set; }
        public int IdFuncionarioAutoriza { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string nombreFuncionario { get; set; }
        public string nombreFuncionarioAutoriza { get; set; }
    }

    [Serializable]
    public class VisitaFuncionarioVO
    {
        public int IdEmpresa { get; set; }
        public int IdVisita { get; set; }
        public int IdFuncionario { get; set; }
        public string NomVisitante { get; set; }
        public string Asunto { get; set; }
        public DateTime HoraIngreso { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string nombreFuncionario { get; set; }
    }


    [Serializable]
    public class IngesoFuncionarioVO
    {
        public int IdEmpresa { get; set; }
        public int IdControl { get; set; }
        public string Documento { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Asunto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? HoraInicial { get; set; }
        public DateTime? HoraFinal { get; set; }


    }


    [Serializable]
    public class CorrespondenciaVO
    {
        public int IdEmpresa { get; set; }
        public int IdCorreo { get; set; }
        public string Remitente { get; set; }
        public DateTime? FechaRecibido { get; set; }
        public int IdFuncionario { get; set; }
        public string Asunto { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string nombreFuncionario { get; set; }
    }



}
