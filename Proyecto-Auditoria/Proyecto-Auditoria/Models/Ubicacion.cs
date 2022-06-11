using System;
using System.Collections.Generic;

namespace Proyecto_Auditoria.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Activos = new HashSet<Activo>();
        }

        public int CodigoUbicacion { get; set; }
        public string DescripcionUbicacion { get; set; } = null!;
        public string? CentroCosto { get; set; }
        public int? NumeroEstante { get; set; }
        public string? CuentaGastos { get; set; }
        public string? NombreServidor { get; set; }
        public string? Ciudad { get; set; }

        public virtual ICollection<Activo> Activos { get; set; }
    }
}
