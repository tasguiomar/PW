using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum TipoServ { Creche=1, Transporte=2, Natação=3, Música=4, Infantário=5, Berçário=6, CTL=7, Dança=8, Teatro=9, Outro=10 };

    public class Servico
    {
        [Key]
        public int ServicoID { get; set; }
        [Display(Name = "Descrição: ")]
        public string ServicosDescricao { get; set; }
        [Display(Name = "Preço: ")]
        public float ServicosPreco { get; set; }
        [Display(Name = "Tipo: ")]
        public TipoServ ServicosTipo { get; set; }
        public int InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public virtual Instituicao Instituicao { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
    }
}

