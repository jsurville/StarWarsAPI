using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class Planete
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Climat { get; set; }
        public string Terrain { get; set; }
    }
}