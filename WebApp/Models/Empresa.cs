using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Empresa
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "O nome da empresa deve ser informado.")]
        public string Nome { get; set; }
        [Url]
        [Display(Name = "Web Site")]
        public string Site { get; set; }
        [Required]
        [Display(Name = "Quantidade de Funcionários")]
        [Range(0, int.MaxValue, ErrorMessage = "O numero de funcionário.")]
        public int QuantidadeFuncionarios { get; set; }
    }
}
