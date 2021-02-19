using System;
using System.Collections.Generic;

namespace Italika.Core.Entities
{
    public partial class Productos
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime Fechar { get; set; }
    }
}
