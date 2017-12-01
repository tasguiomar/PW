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
        public string AnuncioTitulo { get; set; }
        public string AnuncioDescricao { get; set; }
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