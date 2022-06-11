using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class EventosActivo
    {
        public int CodigoEventoActivo { get; set; }
        public string? DescripcionEvento { get; set; }
        public DateTime? FechaEvento { get; set; }
        public int? CodigoActivo { get; set; }

        public virtual Activo? CodigoActivoNavigation { get; set; }
    }
}
