using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationPractice
{
    public class Refrigerator
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public string Manufacturer { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, price: {Price} UAH, volume: {Volume} l, manufacturer: {Manufacturer}.";
        }
    }
}
