using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum Tipo { Pública, Privada, IPSS };

    public class Instituicao
    {

        [Key]
        public int InstituicaoID { get; set; }
        [Display(Name = "Tipo: ")]
        public Tipo InstituicaoTipo { get; set; }
        [Display(Name = "Nome: ")]
        public string InstituicaoNome { get; set; }
        [Display(Name = "Email: ")]
        public string InstituicaoEmail { get; set; }
        [Display(Name = "Telefone: ")]
        public int InstituicaoTelefone { get; set; }
        [Display(Name = "Cidade: ")]
        public string InstituicaoCidade { get; set; }
        [Display(Name = "Morada: ")]
        public string InstituicaoMorada { get; set; }

        public virtual IList<Servico> Servicos { get; set; }
        //public virtual IList<Anuncio> Anuncios { get; set; }
    }
}