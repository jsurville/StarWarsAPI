using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class Perso
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BirdthDate { get; set; }
        public int Mass { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}