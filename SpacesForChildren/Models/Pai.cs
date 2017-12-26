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
        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O nome deve conter entre 10 a 150 caracteres.")]
        [Display(Name = "Nome")]
        public string PaisNome { get; set; }
        [Required]
        [RegularExpression(@"\d{8}", ErrorMessage = "Número de cartão de cidadão inválido.")]
        [Display(Name = "CC")]
        public int PaisCc { get; set; }
        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Número de identificação fiscal inválido.")]
        [Display(Name = "NIF")]
        public int PaisNif { get; set; }
        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Número de telemóvel inválido.")]
        [Display(Name = "Telemóvel")]
        public int PaisTelemovel { get; set; }
        [Display(Name = "Email")]
        public string PaisEmail { get; set; }

        public virtual IList<Pedido> Pedidos { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
    }
}