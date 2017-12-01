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
        public string PaisNome { get; set; }
        public int PaisCc { get; set; }
        public int PaisNif { get; set; }
        public int PaisTelemovel { get; set; }
        public string PaisEmail { get; set; }

        public virtual IList<Pedido> Pedidos { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
    }
}