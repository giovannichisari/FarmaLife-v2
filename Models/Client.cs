using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadastro_remedios.Models
{
    public class Client
    {
        //cadastro cliente
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string clientDocument { get; set; }
        public string clientZipCode { get; set; }
        public string clientStreet { get; set; }
        public string clientDistrict { get; set; }
        public string clientCity { get; set; }
        public string clientState { get; set; }
        public string clientTelephone { get; set; }
        public string clientEmail { get; set; }
        public string clientStatus { get; set; }


    }
}
