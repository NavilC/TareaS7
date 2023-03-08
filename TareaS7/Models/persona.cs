using System;
using System.Collections.Generic;
using System.Text;

namespace TareaS7.Models
{
        public  class persona
    {
        public int id_detalle_pedido { get; set; }

        public int  id_pan { get; set; }

        //public string nombre_cliente { get; set; }

        //public string direccion { get; set; }

        public string toJson()
        {

            return "{ \"id_detalle_pedido\": \"" + id_detalle_pedido + "\" , \"id_pan\": \"" + id_pan + "\"}";

        }
    }
}
