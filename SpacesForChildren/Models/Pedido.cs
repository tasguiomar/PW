using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int Pai { get; set; }
        public int Anuncio { get; set; }
        public int Resposta { get; set; }
    }
}