using System;
using System.Collections.Generic;
using System.Text;

namespace TareaS7.Models
{
        public  class persona
    {
        public int id_pan { get; set; }

        public string  tipo_pan { get; set; }
        public string imagen { get; set; }

        public string toJson()
        {

            return "{ \"tipo_pan\": \"" + tipo_pan + "\" , \"id_pan\": \"" + id_pan + "\" , \"imagen\": \"" + imagen + "\"}";

        }
    }
}
