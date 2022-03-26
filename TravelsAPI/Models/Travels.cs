using System;
using System.Collections.Generic;

#nullable disable

namespace TravelsAPI.Models
{
    public partial class Travels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Contact { get; set; }
        public string Place { get; set; }
       
    }
}
