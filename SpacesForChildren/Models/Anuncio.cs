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
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O titulo deve conter entre 10 a 100 caracteres.")]
        [Display(Name = "Titulo")]
        public string AnuncioTitulo { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve conter entre 10 a 500 caracteres.")]
        [Display(Name = "Descricao")]
        public string AnuncioDescricao { get; set; }
        [Required(ErrorMessage = "A data é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime? AnuncioData { get; set; }
        [ForeignKey("Servico")]
        public int ServicoID { get; set; }

        public virtual Servico Servico { get; set; }
        public virtual IList<Pedido> Pedido { get; set; }
    }
}