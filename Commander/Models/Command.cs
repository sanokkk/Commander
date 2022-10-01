using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage ="Слишком короткое")]
        public string HowTo { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage = "Слишком короткое")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(5, ErrorMessage = "Слишком короткое")]
        public string Platform { get; set; }

    }
}
