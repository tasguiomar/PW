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
        [Key]
        public int PedidoID { get; set; }
        public int PaiID { get; set; }
        public int AnuncioID { get; set; }
        public int RespostaID { get; set; }

        [ForeignKey("PaiID")]
        public virtual Pai Pai { get; set; }
        [ForeignKey("AnuncioID")]
        public virtual Anuncio Anuncio { get; set; }
        [ForeignKey("RespostaID")]
        public virtual Resposta Resposta { get; set; }
    }
}