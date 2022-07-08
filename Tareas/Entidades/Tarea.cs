using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarea
    {
        public enum EstadoTarea { Pendiente, Proceso, Finalizado };
        public enum Prioridad { Alta, Media, Baja };

        public static event Action<string, string> OnMensajeError;
        public static event Action<string, string> OnLecturaDeArchivo;

        private const string rutaArchivo = "Tarea/Tareas";
        private static List<Tarea> tareas;
        private static string mensajeError;
        private int idTarea;
        private string contenido;
        private EstadoTarea estadoTarea;
        private Prioridad prioridad;
        private DateTime fechaInicial;
        private DateTime fechaFinal;
        private bool tieneFechaInicial;
        private bool tieneFechaFinal;
        private bool tieneRecordatorio;
        private ColorARGB colorTarea;
        private ColorARGB colorLetra;
        private bool cambioElTemaPorDefecto;

        /// <summary>
        /// Constructor Estatico de la clase.
        /// </summary>
        static Tarea()
        {
            Tarea.tareas = new List<Tarea>();
            Tarea.mensajeError = string.Empty;
        }

        /// <summary>
        /// Constructor para SERIALIZACION JSON.
        /// </summary>
        [JsonConstructor]
        public Tarea()
        {
            this.Contenido = string.Empty;
            this.TieneFechaFinal = false;
            this.tieneFechaInicial = false;
            this.TieneRecordatorio = false;
            this.CambioElTemaPorDefecto = false;
            this.EstadoDeTarea = EstadoTarea.Pendiente;
            this.PrioridadTarea = Prioridad.Baja;
        }

        /// <summary>
        /// Constructor para dar de alta Tareas. Si recibe un ID '0', se le asignara el proximo ID disponible.
        /// </summary>
        /// <param name="idTarea"></param>
        public Tarea(int idTarea) : this()
        {
            this.IdTarea = idTarea;
        }

        internal Tarea(int idTarea, string contenido, EstadoTarea estadoTarea, Prioridad prioridadTarea, DateTime fechaInicial, DateTime fechaFinal, bool tieneFechaInicial, bool tieneFechaFinal, bool tieneRecordatorio, string colorTarea, string colorLetra, bool cambioElTemaPorDefecto)
        {
            this.IdTarea = idTarea;
            this.Contenido = contenido;
            this.EstadoDeTarea = estadoTarea;
            this.FechaInicial = fechaInicial;
            this.FechaFinal = fechaFinal;
            this.TieneFechaInicial = tieneFechaInicial;
            this.TieneFechaFinal = tieneFechaFinal;
            this.TieneRecordatorio = tieneRecordatorio;
            this.ColorTareaString = colorTarea;
            this.ColorLetraString = colorLetra;
            this.PrioridadTarea = prioridadTarea;
            this.CambioElTemaPorDefecto = cambioElTemaPorDefecto;
        }

        [Browsable(false)]
        public DateTime FechaInicial
        {
            get
            {
                if (this.tieneFechaInicial)
                {
                    return this.fechaInicial;
                }
                return DateTime.Now;
            }
            set
            {
                this.fechaInicial = value;
            }
        }             

        [JsonIgnore]
        /// <summary>
        /// Obtiene un valor para la fecha inicial (dia/mes/año), en formato String.
        /// </summary>
        public string FechaInicialString
        {
            get
            {
                if (this.TieneFechaInicial)
                {
                    return this.FechaInicial.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "S/F";
                }
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        /// <summary>
        /// Obtiene un valor para la fecha inicial (dia/mes/año - hora:minutos), en formato String.
        /// </summary>
        public string FechaInicialCompletaString
        {
            get
            {
                if (this.TieneFechaInicial)
                {
                    return this.FechaInicial.ToString("dd/MM/yyyy - hh:mm");
                }
                else
                {
                    return "-";
                }
            }
        }

        [Browsable(false)]
        public DateTime FechaFinal
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.fechaFinal;
                }
                return DateTime.Now;
            }
            set
            {
                this.fechaFinal = value;
            }
        }

        [JsonIgnore]
        /// <summary>
        /// Obtiene un valor para la fecha final (dia/mes/año), en formato String.
        /// </summary>
        public string FechaFinalString
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.FechaFinal.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "S/F";
                }
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        /// <summary>
        /// Obtiene un valor para la fecha final (dia/mes/año - hora:minutos), en formato String.
        /// </summary>
        public string FechaFinalCompletaString
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.FechaFinal.ToString("dd/MM/yyyy - hh:mm");
                }
                else
                {
                    return "-";
                }
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Color ColorTarea
        {
            get
            {
                if(this.colorTarea == null)
                {
                    return Color.White;
                }
                return Color.FromArgb(this.colorTarea.Alfa, this.colorTarea.Rojo, this.colorTarea.Verde, this.colorTarea.Azul);
            }
            set
            {
                this.colorTarea = new ColorARGB(value.A, value.R, value.G, value.B);
            }
        }

        [Browsable(false)]
        public string ColorTareaString
        {
            get
            {
                return ColorARGB.ObtenerCadenaAPartirDeUnColor(this.colorTarea, '-');
            }
            set
            {
                this.colorTarea = ColorARGB.ObtenerColorAPartirDeUnaCadena(value, '-');
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public ColorARGB ColorTareaARGB
        {
            get
            {
                if (this.colorTarea == null)
                {
                    this.colorTarea = new ColorARGB(255, 255, 255, 255);
                }
                return this.colorTarea;
            }
            set
            {
                if (value == null)
                {
                    value = new ColorARGB(255, 255, 255, 255);
                }
                this.colorTarea = value;
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Color ColorLetra
        {
            get
            {
                if (this.colorLetra == null)
                {
                    return Color.Black;
                }
                return Color.FromArgb(this.colorLetra.Alfa, this.colorLetra.Rojo, this.colorLetra.Verde, this.colorLetra.Azul);
            }
            set
            {
                this.colorLetra = new ColorARGB(value.A, value.R, value.G, value.B);
            }
        }

        [Browsable(false)]
        public string ColorLetraString
        {
            get
            {
                return ColorARGB.ObtenerCadenaAPartirDeUnColor(this.colorLetra, '-');
            }
            set
            {
                this.colorLetra = ColorARGB.ObtenerColorAPartirDeUnaCadena(value, '-');
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public ColorARGB ColorLetraARGB
        {
            get
            {
                if (this.colorLetra == null)
                {
                    this.colorLetra = new ColorARGB(0, 0, 0, 0);
                }
                return this.colorLetra;
            }
            set
            {
                if (value == null)
                {
                    value = new ColorARGB(0, 0, 0, 0);
                }
                this.colorLetra = value;
            }
        }

        [Browsable(false)]
        public bool TareaEstaVencida
        {
            get
            {
                return this.EstadoDeTarea != Tarea.EstadoTarea.Finalizado &&
                       this.TieneRecordatorio &&
                       this.TieneFechaFinal &&
                       this.FechaFinal <= DateTime.Now;
            }
        }

        [Browsable(false)]
        public bool TareaEstaPendiente
        {
            get
            {
                return this.EstadoDeTarea == Tarea.EstadoTarea.Pendiente &&
                       this.TieneRecordatorio &&
                       this.TieneFechaFinal &&
                       this.FechaFinal > DateTime.Now;
            }
        }

        public string Contenido { get => this.contenido; set => this.contenido = value; }

        public Prioridad PrioridadTarea { get => prioridad; set => prioridad = value; }

        public EstadoTarea EstadoDeTarea { get => this.estadoTarea; set => this.estadoTarea = value; }

        public bool TieneRecordatorio { get => this.tieneRecordatorio; set => this.tieneRecordatorio = value; }

        [Browsable(false)]
        public bool CambioElTemaPorDefecto { get => cambioElTemaPorDefecto; set => cambioElTemaPorDefecto = value; }

        [Browsable(false)]
        public bool TieneFechaInicial { get => this.tieneFechaInicial; set => this.tieneFechaInicial = value; }

        [Browsable(false)]
        public bool TieneFechaFinal { get => this.tieneFechaFinal; set => this.tieneFechaFinal = value; }
             
        [Browsable(false)]
        public int IdTarea 
        {
            get
            {
                return this.idTarea;
            }
            set
            {
                if(value == 0)
                {
                    this.idTarea = GeneradorDeIDs.IdentificadorUnicoTarea.ObtenerIdUnicoParaTarea();
                }
                else if(value >0)
                {
                    this.idTarea = value;
                }
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public static List<Tarea> Tareas { get => Tarea.tareas; private set => Tarea.tareas = value; }

        /// <summary>
        /// Muestra la informacion de la tarea.
        /// </summary>
        /// <returns>Un string con informacion de la tarea.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tarea: {this.Contenido}");
            sb.AppendLine($"Prioridad: {this.PrioridadTarea}");
            sb.AppendLine($"Fecha inicial: {this.FechaInicialString}");
            sb.AppendLine($"Estado: {this.EstadoDeTarea}");
            sb.AppendLine($"Fecha final: {this.FechaFinalString}");

            return sb.ToString();
        }

        /// <summary>
        /// Clona una tarea
        /// </summary>
        /// <returns></returns>
        public Tarea ClonarTarea()
        {
            return new Tarea(this.IdTarea, this.Contenido, this.EstadoDeTarea, this.PrioridadTarea, this.FechaInicial, 
                this.FechaFinal, this.TieneFechaInicial, this.TieneFechaFinal, this.TieneRecordatorio, 
                this.ColorTareaString, this.ColorLetraString, this.CambioElTemaPorDefecto);
        }

        /// <summary>
        /// Copia la tarea recibida por parametro en la tarea invocadora.
        /// </summary>
        /// <param name="tarea">Tarea a copiar.</param>
        public void CopiarTarea(Tarea tarea)
        {
            if(tarea != null)
            {
                this.IdTarea = tarea.IdTarea;
                this.Contenido = tarea.Contenido;
                this.EstadoDeTarea = tarea.EstadoDeTarea;
                this.FechaInicial = tarea.FechaInicial;
                this.FechaFinal = tarea.FechaFinal;
                this.TieneFechaInicial = tarea.TieneFechaInicial;
                this.TieneFechaFinal = tarea.TieneFechaFinal;
                this.TieneRecordatorio = tarea.TieneRecordatorio;
                this.ColorTareaString = tarea.ColorTareaString;
                this.ColorLetraString = tarea.ColorLetraString;
                this.CambioElTemaPorDefecto = tarea.CambioElTemaPorDefecto;
                this.PrioridadTarea = tarea.PrioridadTarea;
            }
        }

        /// <summary>
        /// Lee todas las tareas de un archivo.
        /// </summary>
        /// <returns>Una lista con todas las tareas leidas. Si ha ocurrido un error al intentar cargarlas, retorna una lista vacia.</returns>
        public static List<Tarea> LeerTareas()
        {
            try
            {
                Tarea.Tareas = SerializadorJSON<List<Tarea>>.Leer(Tarea.rutaArchivo);

                return Tarea.Tareas;
            }
            catch (Exception)
            {
                if (Tarea.OnLecturaDeArchivo != null)
                {
                    Tarea.OnLecturaDeArchivo.Invoke("No se han podido cargar Tareas. Se iniciara una nueva lista de tareas.", "Error al intentar cargar tareas.");
                }
                return Tarea.Tareas;
            }
        }

        /// <summary>
        /// Agrega una tarea a la lista de tareas, previa verificacion 
        /// de que la tarea no sea null y que tampoco exista una tarea con ese mismo Id.
        /// </summary>
        /// <param name="tarea">Tarea a guardar en la lista.</param>
        /// <returns>True si pudo guardar la tarea en la lista, caso contrario False.</returns>
        private static bool AgregarTareaALista(Tarea tarea)
        {
            if (tarea is not null && !tarea.ExisteTareaEnLista())
            {
                Tarea.Tareas.Add(tarea);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Elimina una tarea de la lista de tareas.
        /// </summary>
        /// <returns>True si encontro la tarea y la pudo eliminar, caso contrario False.</returns>
        private bool EliminarTareaDeLista()
        {           
            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                if (this.IdTarea == Tarea.Tareas[i].IdTarea)
                {
                    this.TieneRecordatorio = false;

                    Tarea.Tareas.RemoveAt(i);

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Evalua si una tarea existe en la lista de tareas, por su Id.
        /// </summary>
        /// <returns>True si la tarea ya esta cargada, caso contrario False.</returns>
        private bool ExisteTareaEnLista()
        {
            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                if (Tarea.Tareas[i].IdTarea == this.IdTarea)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Guarda la lista de tareas en el archivo.
        /// </summary>
        private static void GuardarListaDeTareasEnArchivo()
        {
            Task.Run(()=>
            {
                try
                {
                    SerializadorJSON<List<Tarea>>.Guardar(Tarea.rutaArchivo, Tarea.tareas);

                    throw new Exception();
                }
                catch(Exception)
                {
                    if(Tarea.OnMensajeError != null && !string.IsNullOrWhiteSpace(Tarea.mensajeError))
                    {
                        Tarea.OnMensajeError(Tarea.mensajeError, "Aviso: Ha ocurrido un error.");
                    }
                }                  
            });            
        }

        /// <summary>
        /// Guarda una actualizacion de tarea en el archivo.
        /// </summary>
        public void ActualizarTarea()
        {
            Tarea.mensajeError = "Ha ocurrido un error al intentar actualizar la tarea en el archivo.";

            Tarea.GuardarListaDeTareasEnArchivo();   
        }

        /// <summary>
        /// Guarda la tarea en la lista y luego en el Archivo de tareas.
        /// </summary>
        public void GuardarTareaNueva()
        {   
            if (Tarea.AgregarTareaALista(this))
            {
                Tarea.mensajeError = "Ha ocurrido un error al intentar guardar la tarea en el archivo.";

                Tarea.GuardarListaDeTareasEnArchivo();
            }    
        }  

        /// <summary>
        /// Elimina una tarea de la lista y del archivo.
        /// </summary>
        public void EliminarTarea()
        {     
            if(this.EliminarTareaDeLista())
            {
                Tarea.mensajeError = "Ha ocurrido un error al intentar eliminar la tarea en el archivo.";

                Tarea.GuardarListaDeTareasEnArchivo();
            }  
        }        

        /// <summary>
        /// Elimina todas las tareas de la lista y del archivo.
        /// </summary>
        /// <exception cref="Exception">Error.</exception>
        public static void EliminarTodasLasTareasDeBBDD()
        {
            Tarea.Tareas.Clear();

            Tarea.mensajeError = "Ha ocurrido un error al intentar eliminar todas las tarea del archivo.";

            Tarea.GuardarListaDeTareasEnArchivo();
        }
    }
}
