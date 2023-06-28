using System.ComponentModel.DataAnnotations;

namespace ClientsApiTest.Models
{
    public class Client:IValidatableObject
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25), MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25), MinLength(4)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [Required]
        public string Cuit { get; set; }

        [Required]
        public string Adress { get; set; }

        [Phone]
        public string MobilPhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime RegistryDate { get; set; }

        [Required]
        public bool Active { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(BirthDate > DateTime.Now)
            {
                yield return new ValidationResult("The date of birth cannot be greater than the current date.");
            }

            if(Cuit.Length > 13 && Cuit.Length < 11)
            {
                yield return new ValidationResult("Cuit is not valid.");
            }
        }

    }
}
