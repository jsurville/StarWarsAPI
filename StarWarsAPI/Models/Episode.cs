using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class Episode
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Adresse { get; set; }
        
    }
}