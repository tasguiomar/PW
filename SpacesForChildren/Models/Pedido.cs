using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public Pai Pai { get; set; }
        public Anuncio Anuncio { get; set; }
        public Resposta Resposta { get; set; }
    }
}