using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int PaiID { get; set; }
        public int AnuncioID { get; set; }
        public int RespostaID { get; set; }

        public virtual Pai Pai { get; set; }
        public virtual Anuncio Anuncio { get; set; }
        public virtual Resposta Resposta { get; set; }
    }
}