using System;
using System.Collections.Generic;

namespace Seidor_ApiRest.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Vendedor = new HashSet<Vendedor>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
