using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class Auditorium
    {
        public Auditorium()
        {
            HallazgosAuditoria = new HashSet<HallazgosAuditorium>();
        }

        public int CodigoAuditoria { get; set; }
        public int CodigoActivo { get; set; }
        public string? Titulo { get; set; }
        public string? Responsable { get; set; }
        public string? Objetivo { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual Activo CodigoActivoNavigation { get; set; } = null!;
        public virtual ICollection<HallazgosAuditorium> HallazgosAuditoria { get; set; }
    }
}
