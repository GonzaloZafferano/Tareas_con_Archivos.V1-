using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class GeneradorDeIDs
    {
        private const string rutaRelativaArchivo = "Ids/UltimoIdTareas";
        private static GeneradorDeIDs identificadorUnicoTarea;
        private static int tareaId;

        /// <summary>
        /// Constructor estatico de la clase GeneradorDeIDs. Inicializa un objeto de tipo GeneradorDeIDs.
        /// Lee el archivo de Ids y carga el ultimo ID en el sistema.
        /// </summary>
        static GeneradorDeIDs()
        {
            if (!GeneradorDeIDs.LeerArchivoDeIds())
            {
                GeneradorDeIDs.identificadorUnicoTarea = new GeneradorDeIDs();
                GeneradorDeIDs.IdentificadorUnicoTarea.TareaID = 0;
            }
        }

        /// <summary>
        /// Retorna el objeto estatico que contiene el ultimo id de las Tareas.
        /// </summary>
        public static GeneradorDeIDs IdentificadorUnicoTarea
        {
            get
            {
                return GeneradorDeIDs.identificadorUnicoTarea;
            }
            private set
            {
                GeneradorDeIDs.identificadorUnicoTarea = value;
            }
        }

        /// <summary>
        /// Propiedad para Serializacion. Obtiene y setea el id de la ultima Tarea. 
        /// </summary>
        public int TareaID
        {
            get
            {
                return GeneradorDeIDs.tareaId;
            }
            set
            {
                GeneradorDeIDs.tareaId = value;
            }
        }

        /// <summary>
        /// Obtiene un Id Unico para una Tarea
        /// </summary>
        /// <returns>Id Unico para una tarea</returns>
        /// <exception cref="Exception">Error externo.</exception>
        public int ObtenerIdUnicoParaTarea()
        {
            int retorno = ++this.TareaID;

            try
            {
                this.GuardarArchivo();
            }
            catch (Exception) { }

            return retorno;
        }

        /// <summary>
        /// Guarda los ids en un archivo.
        /// </summary>
        /// <exception cref="Exception">Error externo.</exception>
        private bool GuardarArchivo()
        {
            try
            {
                return SerializadorJSON<GeneradorDeIDs>.Guardar(GeneradorDeIDs.rutaRelativaArchivo, GeneradorDeIDs.IdentificadorUnicoTarea);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error externo al sistema al intentar serializar los Ids. Clase GeneradorDeIDs. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Obtiene los datos de IDS que estan respaldados en un archivo, y lo carga al sistema.
        /// </summary>
        /// <returns>True si leyo el archivo sin problemas, caso contrario False.</returns>
        private static bool LeerArchivoDeIds()
        {
            try
            {
                GeneradorDeIDs.IdentificadorUnicoTarea = SerializadorJSON<GeneradorDeIDs>.Leer(GeneradorDeIDs.rutaRelativaArchivo);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
