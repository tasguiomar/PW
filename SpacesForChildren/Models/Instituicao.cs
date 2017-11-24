using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum Tipo { Pública, Privada, IPSS };

    public class Instituicao
    {
        public int InstituicaoID { get; set; }
        public Tipo InstituicaoTipo { get; set; }
        public string InstituicaoNome { get; set; }
        public string InstituicaoEmail { get; set; }
        public int InstituicaoTelefone { get; set; }
        public string InstituicaoCidade { get; set; }
        public string InstituicaoMorada { get; set; }

        public virtual IList<Servico> Servicos { get; set; }
        public virtual IList<Anuncio> Anuncios { get; set; }
        public virtual IList<Resposta> Respostas { get; set; }
    }
}