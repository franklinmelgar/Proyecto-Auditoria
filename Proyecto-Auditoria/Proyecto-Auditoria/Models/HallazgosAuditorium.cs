using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class HallazgosAuditorium
    {
        public int CodigoAuditoria { get; set; }
        public string? TituloHallazgo { get; set; }
        public string? DescripcionHallazgo { get; set; }
        public int CodigoHallazgos { get; set; }

        public virtual Auditorium CodigoAuditoriaNavigation { get; set; } = null!;
    }
}
