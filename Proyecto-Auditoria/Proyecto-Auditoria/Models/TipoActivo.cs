using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class TipoActivo
    {
        public TipoActivo()
        {
            Activos = new HashSet<Activo>();
            ListadoCaracteristicaTipoActivos = new HashSet<ListadoCaracteristicaTipoActivo>();
        }

        public int CodigoTipoActivo { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Activo> Activos { get; set; }
        public virtual ICollection<ListadoCaracteristicaTipoActivo> ListadoCaracteristicaTipoActivos { get; set; }
    }
}
