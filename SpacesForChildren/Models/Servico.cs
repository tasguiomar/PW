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
        [Required]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve conter entre 10 a 500 caracteres.")]
        [Display(Name = "Descrição")]
        public string ServicosDescricao { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "O preço deve ser superior a 0.")]
        [Display(Name = "Preço")]
        public float ServicosPreco { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Escolha um tipo de serviço válido.")]
        [Display(Name = "Tipo")]
        public TipoServ ServicosTipo { get; set; }
        public int InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public virtual Instituicao Instituicao { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
    }
}

