using System.Data;
using Core.Infraestructure;
using Core.Models;

namespace Core.Infraestructure
{
    public class Seguridad : BaseDao
    {
        public Seguridad(IConfiguration configuration) : base(configuration)
        {
        }

        #region [Constants]

        //DECLARA PROCEDIMIENTOS 
        private const String SEGURIDAD_VALIDARUSUARIO = "sp_Seguridad_ValidarUsuario";
        private const String SEGURIDAD_GETUSUARIO = "sp_Seguridad_BuscarUsuarioPorNombre";
        private const String SEGURIDAD_BUSCARPREGUNTAS = "sp_Seguridad_BuscarPreguntas";
        private const String SEGURIDAD_ENVIARRESPUESTAS = "sp_Seguridad_EnviarRespuestas";

        // Constantes Entidad Seguridad
        public const string SEGURIDAD_NOMBREUSUARIO = "nombreUsuario";
        public const string SEGURIDAD_CLAVE = "clave";

        //Constantes para cargar VO Usuario
        public const string SEGURIDAD_IDCOLEGIO = "idColegio";
        public const string SEGURIDAD_NOMCOLEGIO = "nomColegio";
        public const string SEGURIDAD_NOMCOLEGIO2 = "nomColegio2";
        public const string SEGURIDAD_WEBSITE = "webSite";
        public const string SEGURIDAD_DOMINIO = "dominio";
        public const string SEGURIDAD_IDUSUARIO = "idUsuario";
        public const string SEGURIDAD_TIPIDENTIFICACION = "tipIdentificacion";
        public const string SEGURIDAD_NUMIDENTIFICACION = "numIdentificacion";
        public const string SEGURIDAD_NOMBRE1 = "nombre1";
        public const string SEGURIDAD_NOMBRE2 = "nombre2";
        public const string SEGURIDAD_APELLIDO1 = "apellido1";
        public const string SEGURIDAD_APELLIDO2 = "apellido2";
        public const string SEGURIDAD_TIPOMITADPERIODO = "tipoMitadPeriodo";
        public const string SEGURIDAD_ESADMON = "esAdmon";


        //Constantes para cargar VO Rol
        public const string ROL_IDROL = "idRol";
        public const string ROL_NOMBRE = "nombre";

        //Constantes para cargar VO Formulario
        public const string FORMULARIO_IDFORMULARIO = "IdFormulario";
        public const string FORMULARIO_NOMFORMULARIO = "NomFormulario";
        public const string FORMULARIO_DIRECCION = "Direccion";
        public const string FORMULARIO_IDPADRE = "IdPadre";
        public const string FORMULARIO_VISIBLE = "Visible";

        //Constantes para cargar Preguntas para restaurar clave
        public const string PREGUNTA_IDPREGUNTA = "idPregunta";
        public const string PREGUNTA_DESPREGUNTA = "desPregunta";
        public const string PREGUNTA_VALORRESPUESTA1 = "valorRespuesta1";
        public const string PREGUNTA_VALORRESPUESTA2 = "valorRespuesta2";
        public const string PREGUNTA_VALORRESPUESTA3 = "valorRespuesta3";
        public const string PREGUNTA_VALORRESPUESTA4 = "valorRespuesta4";
        public const string PREGUNTA_RESPUESTA1 = "Respuesta1";
        public const string PREGUNTA_RESPUESTA2 = "Respuesta2";
        public const string PREGUNTA_RESPUESTA3 = "Respuesta3";
        public const string PREGUNTA_RESPUESTA4 = "Respuesta4";
        public const string PREGUNTA_IDPREGUNTA1RETORNAR = "idPreguntaRetornar1";
        public const string PREGUNTA_IDPREGUNTA2RETORNAR = "idPreguntaRetornar2";
        public const string PREGUNTA_IDPREGUNTA3RETORNAR = "idPreguntaRetornar3";
        public const string PREGUNTA_NUMRESPUESTASINCORRECTAS = "numRespuestasIncorrectas";

        #endregion

        #region  [Metodos Expuestos]

        /// <summary>
        /// Se valida que las credenciales del usuario sean correctas.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public Boolean validarUsuario(String nombreUsuario, String clave)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, nombreUsuario, DbType.String),
                         new Parametro(SEGURIDAD_CLAVE, clave, DbType.String)
                   };

                DataRow dr = this.EjecutarStoredProcedureDataRow(SEGURIDAD_VALIDARUSUARIO, valParam);

                if (dr != null)
                    return true;
                else
                    return false;

            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public UsuarioVO getUsuario(String nombreUsuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, nombreUsuario, DbType.String)
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_GETUSUARIO, valParam);
                UsuarioVO item = this.CargaUsuarioVO(ds.Tables[0].Rows[0]);
                List<RolVO> roles = this.CargaRolVO(ds.Tables[1]);
                List<FormularioVO> formularios = this.CargaFormularioVO(ds.Tables[2]);
                item.Rol = roles;
                item.Formulario = formularios;
                return item;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public List<UsuarioVO> buscarPreguntas(UsuarioVO Usuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Usuario.NomUsuario, DbType.String)
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_BUSCARPREGUNTAS, valParam);
                List<UsuarioVO> item = this.CargaPreguntas(ds.Tables[0]);
                return item;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Se obtiene la informacion del usuario. Una vez se ha autenticado.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public List<UsuarioVO> EnviarRespuestas(UsuarioVO Usuario)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                   {
                         new Parametro(SEGURIDAD_NOMBREUSUARIO, Usuario.NomUsuario, DbType.String),
                         new Parametro(PREGUNTA_IDPREGUNTA1RETORNAR, Usuario.idPregunta1Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_IDPREGUNTA2RETORNAR, Usuario.idPregunta2Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_IDPREGUNTA3RETORNAR, Usuario.idPregunta3Retornar, DbType.Int32),
                         new Parametro(PREGUNTA_RESPUESTA1, Usuario.respuesta1, DbType.String),
                         new Parametro(PREGUNTA_RESPUESTA2, Usuario.respuesta2, DbType.String),
                         new Parametro(PREGUNTA_RESPUESTA3, Usuario.respuesta3, DbType.String),
                         new Parametro(PREGUNTA_VALORRESPUESTA1, Usuario.valorRespuesta1, DbType.Int32),
                         new Parametro(PREGUNTA_VALORRESPUESTA2, Usuario.valorRespuesta2, DbType.Int32),
                         new Parametro(PREGUNTA_VALORRESPUESTA3, Usuario.valorRespuesta3, DbType.Int32),
                   };

                DataSet ds = this.EjecutarStoredProcedureDataSet(SEGURIDAD_ENVIARRESPUESTAS, valParam);
                List<UsuarioVO> retorno = new List<UsuarioVO>();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Resultado"]) == 1)
                {
                    UsuarioVO item = new UsuarioVO();
                    item.resultadoEnvioRespuestas = 1;
                    retorno.Add(item);

                }
                else
                {
                    retorno = this.CargaPreguntas(ds.Tables[1]);
                    retorno[0].resultadoEnvioRespuestas = 0;
                }
                return retorno;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region  [Metodos Privados]

        private List<UsuarioVO> CargaPreguntas(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<UsuarioVO> Preguntas = new List<UsuarioVO>();

            foreach (DataRow dr in dt.Rows)
            {
                UsuarioVO Pregunta = new UsuarioVO();
                Pregunta.idPregunta = Convert.ToInt32(dr[PREGUNTA_IDPREGUNTA]);
                Pregunta.desPregunta = Convert.ToString(dr[PREGUNTA_DESPREGUNTA]);
                Pregunta.valorRespuesta1 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA1]);
                Pregunta.valorRespuesta2 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA2]);
                Pregunta.valorRespuesta3 = Convert.ToInt32(dr[PREGUNTA_VALORRESPUESTA3]);
                
                Pregunta.respuesta1 = Convert.ToString(dr[PREGUNTA_RESPUESTA1]);
                Pregunta.respuesta2 = Convert.ToString(dr[PREGUNTA_RESPUESTA2]);
                Pregunta.respuesta3 = Convert.ToString(dr[PREGUNTA_RESPUESTA3]);
                
                Pregunta.numRespuestasIncorrectas = Convert.ToInt32(dr[PREGUNTA_NUMRESPUESTASINCORRECTAS]);
                Preguntas.Add(Pregunta);
            }
            return Preguntas;
        }

        public UsuarioVO CargaUsuarioVO(DataRow dr)
        {
            //  Generando Metodo
            if (dr == null)
                return null;

            UsuarioVO retorno = new UsuarioVO();

            
            
            
            retorno.WebSite = Convert.ToString(dr[SEGURIDAD_WEBSITE]);
            retorno.Dominio = Convert.ToString(dr[SEGURIDAD_DOMINIO]);
            retorno.IdUsuario = Convert.ToInt32(dr[SEGURIDAD_IDUSUARIO]);
            retorno.TipIdentificacion = Convert.ToInt32(dr[SEGURIDAD_TIPIDENTIFICACION]);
            retorno.NumIdentificacion = Convert.ToString(dr[SEGURIDAD_NUMIDENTIFICACION]);
            retorno.Nombre1 = Convert.ToString(dr[SEGURIDAD_NOMBRE1]);
            retorno.Nombre2 = Convert.ToString(dr[SEGURIDAD_NOMBRE2]);
            retorno.Apellido1 = Convert.ToString(dr[SEGURIDAD_APELLIDO1]);
            retorno.Apellido2 = Convert.ToString(dr[SEGURIDAD_APELLIDO2]);
            
            retorno.esAdmon = Convert.ToInt32(dr[SEGURIDAD_ESADMON]);

            return retorno;
        }

        private List<RolVO> CargaRolVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<RolVO> roles = new List<RolVO>();

            foreach (DataRow dr in dt.Rows)
            {
                RolVO rol = new RolVO();
                rol.IdRol = Convert.ToInt32(dr[ROL_IDROL]);
                rol.Nombre = Convert.ToString(dr[ROL_NOMBRE]);
                roles.Add(rol);
            }
            return roles;
        }

        private List<FormularioVO> CargaFormularioVO(DataTable dt)
        {
            //  Generando Metodo
            if (dt == null)
                return null;

            List<FormularioVO> formularios = new List<FormularioVO>();

            foreach (DataRow dr in dt.Rows)
            {
                FormularioVO form = new FormularioVO();
                form.IdFormulario = Convert.ToInt32(dr[FORMULARIO_IDFORMULARIO]);
                form.NomFormulario = Convert.ToString(dr[FORMULARIO_NOMFORMULARIO]);
                form.Direccion = Convert.ToString(dr[FORMULARIO_DIRECCION]);
                form.Visible = Convert.ToBoolean(dr[FORMULARIO_VISIBLE]);
                if (dr[FORMULARIO_IDPADRE] != System.DBNull.Value)
                    form.IdPadre = Convert.ToInt32(dr[FORMULARIO_IDPADRE]);
                //form.Visible = true;

                formularios.Add(form);
            }
            return formularios;
        }

        #endregion
    }
}
