using System;
using System.Collections.Generic;

namespace Seidor_ApiRest.Models
{
    public partial class Vendedor
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int? CodigoCiudad { get; set; }

        public virtual Ciudad CodigoCiudadNavigation { get; set; }
    }
}
