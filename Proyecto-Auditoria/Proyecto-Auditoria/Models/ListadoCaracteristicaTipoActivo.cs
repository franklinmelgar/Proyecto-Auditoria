using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class ListadoCaracteristicaTipoActivo
    {
        public ListadoCaracteristicaTipoActivo()
        {
            CaracteristicaActivos = new HashSet<CaracteristicaActivo>();
        }

        public int CodigoListadoCaracteristica { get; set; }
        public int? CodigoTipoActivo { get; set; }
        public string? DescripcionCaracteristica { get; set; }

        public virtual TipoActivo? CodigoTipoActivoNavigation { get; set; }
        public virtual ICollection<CaracteristicaActivo> CaracteristicaActivos { get; set; }
    }
}
