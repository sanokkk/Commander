using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs
{
    public class CommandUpdateDto
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage = "Слишком короткое")]
        public string HowTo { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage = "Слишком короткое")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage = "Слишком короткое")]
        public string Platform { get; set; }
    }
}
