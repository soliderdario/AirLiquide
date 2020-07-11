using System;
using System.ComponentModel.DataAnnotations;
using Air.Liquide.Domain.Type;

namespace Air.Liquide.Bootstrap.ViewModel
{
    public class BaseViewModel
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public Guid Id { get; set; }
    }
}
