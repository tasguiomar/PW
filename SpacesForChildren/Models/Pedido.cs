using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{

    public enum Resp { Sim = 1, Não = 2, Espera = 3 };

    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        [Display(Name = "Pai: ")]
        public int PaiID { get; set; }
        [Display(Name = "Anúncio: ")]
        public int AnuncioID { get; set; }
        [Display(Name = "Resposta: ")]
        public Resp Resposta { get; set; }

        [ForeignKey("PaiID")]
        public virtual Pai Pai { get; set; }
        [ForeignKey("AnuncioID")]
        public virtual Anuncio Anuncio { get; set; }
    }
}