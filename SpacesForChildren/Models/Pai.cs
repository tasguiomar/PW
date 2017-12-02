using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Pai
    {
        [Key]
        public int PaiID { get; set; }
        [Display(Name = "Nome: ")]
        public string PaisNome { get; set; }
        [Display(Name = "CC:  ")]
        public int PaisCc { get; set; }
        [Display(Name = "NIF: ")]
        public int PaisNif { get; set; }
        [Display(Name = "Telemóvel")]
        public int PaisTelemovel { get; set; }
        [Display(Name = "Email")]
        public string PaisEmail { get; set; }

        public virtual IList<Pedido> Pedidos { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
    }
}