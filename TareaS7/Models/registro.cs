using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TareaS7.Models
{
    public class registro
    {
        public string nombre_cliente {  get; set; }
        public string email { get; set; }
        public string pass { get; set; }

        public int active { get; set; }

        public int id_rol { get; set; }

        public string toJson()
        {

            return "{ \"nombre_cliente\": \"" + nombre_cliente + "\" , \"email\": \"" + email + "\", \"pass\": \" " + pass + "\"  }";

        }
    }
}
