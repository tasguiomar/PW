using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Anuncio 
    {
        public int AnuncioID { get; set; }
        public string AnuncioTitulo { get; set; }
        public string AnuncioDescricao { get; set; }
        public DateTime? AnuncioData { get; set; }
        public int InstituicaoID { get; set; }
        public int ServicoID { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public virtual Servico Servico { get; set; }
        public virtual IList<Pedido> Pedido { get; set; }
    }
}