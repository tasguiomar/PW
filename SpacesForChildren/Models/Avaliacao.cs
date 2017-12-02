using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Avaliacao
    {
        [Key]
        public int AvaliacaoID { get; set; }
        [Display(Name = "Preço: ")]
        public int AvaliacaoPreco { get; set; }
        [Display(Name = "Localização: ")]
        public int AvaliacaoLocalizacao { get; set; }
        [Display(Name = "Ambiente:")]
        public int AvaliacaoAmbiente { get; set; }
        [Display(Name = "Geral: ")]
        public int AvaliacaoGeral { get; set; }
        [ForeignKey("Pai")]
        public int PaiID { get; set; }
        [ForeignKey("Servico")]
        public int ServicoID { get; set; }

        public virtual Pai Pai { get; set; }
        public virtual Servico Servico { get; set; }
    }
}