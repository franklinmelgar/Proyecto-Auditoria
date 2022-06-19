using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class Activo
    {
        public Activo()
        {
            Auditoria = new HashSet<Auditorium>();
            CaracteristicaActivos = new HashSet<CaracteristicaActivo>();
            EventosActivos = new HashSet<EventosActivo>();
        }

        public int CodigoActivo { get; set; }
        public int? CodigoTipoActivo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaAdquisicion { get; set; }
        public decimal? ValorInicial { get; set; }
        public decimal? ValorActual { get; set; }
        public int? Depreciacion { get; set; }
        public int? CodigoUbicacion { get; set; }

        public virtual TipoActivo? CodigoTipoActivoNavigation { get; set; }
        public virtual Ubicacion? CodigoUbicacionNavigation { get; set; }
        public virtual ICollection<Auditorium> Auditoria { get; set; }
        public virtual ICollection<CaracteristicaActivo> CaracteristicaActivos { get; set; }
        public virtual ICollection<EventosActivo> EventosActivos { get; set; }
    }
}
