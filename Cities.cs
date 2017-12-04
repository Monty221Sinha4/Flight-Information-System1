using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightProject2.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int FlightID { get; set; }
    }
}