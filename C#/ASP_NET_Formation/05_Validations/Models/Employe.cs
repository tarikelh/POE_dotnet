using System.ComponentModel.DataAnnotations;

namespace _05_Validations.Models
{
    public class Employe
    {
        [Required]
        [Display(Name = " User Name ")]
        public string UserName { get; set; } = String.Empty;
        [Required(ErrorMessage="Mot de passe obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
        [Required(ErrorMessage = "Date de naissance obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Required(ErrorMessage = "Email obligatoire")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email Invalide")]
        public string Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "Evaluation obligatoire")]
        [Range(1,10)]
        public int Evaluation { get; set; }
        [Required(ErrorMessage = "Numéro de téléphone obligatoire")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage ="Numéro invalide")]
        public string NumeroTelephone { get; set; } = String.Empty;
        [Required(ErrorMessage = "Commentaire obligatoire")]
        [DataType(DataType.MultilineText)]
        public string Commentaire { get; set; } = String.Empty;

        [Display(Name = " Upload Avatar ")]
        [CustomAvatarValidationAttribute]
        public IFormFile? Avatar { get; set; }
    }

    public class CustomAvatarValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int maxContentLength = 1024 * 1024; //1 MB
            string[] allowedExtensions = new string[] { /*".jpg", ".jpeg",*/ ".png" };
            
            if(value is not IFormFile file)
            {
                ErrorMessage = "Please upload a file";
                return false;
            }
            if(file.Length > maxContentLength)
            {
                ErrorMessage = $"Your photo is too large, maximum size is {maxContentLength}";
                return false;
            }

            // c/blabla/uploads/file.name.ext

            int last = file.FileName.LastIndexOf('.'); //Retourne l'index de la derniere occurence du caractère '.'
            string extension = file.FileName.Substring(last);
            if (!allowedExtensions.Contains(extension)) //retourne l'extension
            {
                ErrorMessage = $"Please upload a file of type : {String.Join(", ", allowedExtensions)}";
                return false;
            }

            return base.IsValid(value);
        }
    }
}
