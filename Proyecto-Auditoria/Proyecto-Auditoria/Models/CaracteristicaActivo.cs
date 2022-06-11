using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class CaracteristicaActivo
    {
        public int CodigoCaracteristica { get; set; }
        public int? CodigoActivo { get; set; }
        public int? CodigoListadoCaracteristica { get; set; }
        public string? DescripcionCaracteristica { get; set; }

        public virtual Activo? CodigoActivoNavigation { get; set; }
        public virtual ListadoCaracteristicaTipoActivo? CodigoListadoCaracteristicaNavigation { get; set; }
    }
}
