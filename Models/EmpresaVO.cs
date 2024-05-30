using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    [Serializable]
    public class EmpresaVO
    {
        public int idEmpresa { get; set; }
        public int? fase { get; set; }
        public int? idUsuario { get; set; }
        public string? nomEmpresa { get; set; }
        public int? idTipoIde { get; set; }
        public string? numeroIde { get; set; }
        public int?  idSectorEconomico { get; set; }
        public int?  idActividadEconomica { get; set; }
        public int? idCiudadEmpresa { get; set; }
        public string? NomCiudadEmpresa { get; set; }
        public int? idDepartamentoEmpresa { get; set; }
        public string? correoElectronico { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public int?  idTipoIdeRepLegal { get; set; }
        public string? nomRepLegal { get; set; }
        public string?  apeRepLegal { get; set; }
        public string?  telRepLegal { get; set; }
        public int? numIdeRepLegal { get; set; }
        public Boolean?  camaraComercio { get; set; }
        public Boolean?  rut { get; set; }
        public string? rutaAvatar { get; set; }
        public Boolean?  completaDatos { get; set; }
        public string?  usuarioCrea { get; set; }
        public DateTime? fechaCrea { get; set; }
        public string? usuarioModfica { get; set; }
        public DateTime? fechaModifica { get; set; }
        //Campos para trareo guardar ofertas de la empresa
        public string? typeModify { get; set; }
        public int? idOferta { get; set; }
        public int? paquetesActivos { get; set; }
        public string? estado { get; set; }
        public string? observacion { get; set; }
        
    }
}
