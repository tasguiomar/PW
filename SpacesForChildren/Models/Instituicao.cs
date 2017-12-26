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
        [Display(Name = "Tipo")]
        public Tipo InstituicaoTipo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O nome da instituição deve conter entre 10 a 100 caracteres.")]
        [Display(Name = "Nome")]
        public string InstituicaoNome { get; set; }
        [Display(Name = "Email")]
        public string InstituicaoEmail { get; set; }
        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Número de telefone inválido.")]
        [Display(Name = "Telefone")]
        public int InstituicaoTelefone { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", ErrorMessage = "Campo Cidade inválido.")]
        [Display(Name = "Cidade")]
        public string InstituicaoCidade { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O nome da instituição deve conter entre 5 a 200 caracteres.")]
        [Display(Name = "Morada")]
        public string InstituicaoMorada { get; set; }

        public virtual IList<Servico> Servicos { get; set; }
        //public virtual IList<Anuncio> Anuncios { get; set; }
    }
}