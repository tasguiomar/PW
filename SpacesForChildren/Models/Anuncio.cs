using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Anuncio 
    {
        [Key]
        public int AnuncioID { get; set; }
        [Display(Name = "Titulo: ")]
        public string AnuncioTitulo { get; set; }
        [Display(Name = "Descricao: ")]
        public string AnuncioDescricao { get; set; }
        [Display(Name = "Data: ")]
        public DateTime? AnuncioData { get; set; }
        [ForeignKey("Instituicao")]
        public int InstituicaoID { get; set; }
        [ForeignKey("Servico")]
        public int ServicoID { get; set; }

        public virtual Instituicao Instituicao { get; set; }
        public virtual Servico Servico { get; set; }
        public virtual IList<Pedido> Pedido { get; set; }
    }
}