using System.ComponentModel.DataAnnotations;

namespace ClientsApiTest.Models
{
    /// <summary>
    /// Clase que representa a un cliente.
    /// </summary>
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

        /// <summary>
        /// Método de validación personalizada para la entidad Client.
        /// </summary>
        /// <param name="validationContext">Contexto de validación.</param>
        /// <returns>Una colección de resultados de validación.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar que la fecha de nacimiento no sea mayor que la fecha actual.
            if (BirthDate > DateTime.Now)
            {
                yield return new ValidationResult("The date of birth cannot be greater than the current date.");
            }

            // Validar el formato y longitud del CUIT.
            if (Cuit.Length == 11)
            {
                int pos = 0;
                bool fail = false;
                foreach (var Char in Cuit)
                {
                    if (char.IsDigit(Char))
                    {
                        pos++;
                    }
                    else if(Char == '-' && pos == 2)
                    {
                        pos++;
                    }
                    else if (Char == '-' && pos == 11)
                    {
                        pos++;
                    }
                    else
                    {
                        yield return new ValidationResult("Cuit is not valid.");
                    }

                }
            }
            else
            {
                yield return new ValidationResult("Cuit is not valid.");
            }
        }

    }
}
