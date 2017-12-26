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
        [Required]
        [Range(1, 5, ErrorMessage = "O preço deve ser avaliado entre 1 a 5.")]
        [Display(Name = "Preço")]
        public int AvaliacaoPreco { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "A localização deve ser avaliado entre 1 a 5.")]
        [Display(Name = "Localização")]
        public int AvaliacaoLocalizacao { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "O ambiente deve ser avaliado entre 1 a 5.")]
        [Display(Name = "Ambiente")]
        public int AvaliacaoAmbiente { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "A nota geral deve estar entre 1 a 5.")]
        [Display(Name = "Geral")]
        public int AvaliacaoGeral { get; set; }
        [ForeignKey("Pai")]
        public int PaiID { get; set; }
        [ForeignKey("Servico")]
        public int ServicoID { get; set; }

        public virtual Pai Pai { get; set; }
        public virtual Servico Servico { get; set; }
    }
}