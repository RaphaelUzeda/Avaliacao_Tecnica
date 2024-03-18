using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Application.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O Nome da empresa é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "O porte da empresa é obrigatório")]
        [DisplayName("Size")]
        public CompanySize Size { get; set; }


    }
}
