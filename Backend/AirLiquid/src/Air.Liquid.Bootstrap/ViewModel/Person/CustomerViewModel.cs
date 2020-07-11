using System.ComponentModel.DataAnnotations;

namespace Air.Liquide.Bootstrap.ViewModel.Person
{
    public class CustomerViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(45, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public int Age { get; set; }

    }
}
