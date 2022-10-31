using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dappercrudapi.Model
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public double Price { get; set; }
    }
}
