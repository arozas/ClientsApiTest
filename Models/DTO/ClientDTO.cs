using System.ComponentModel.DataAnnotations;

namespace ClientsApiTest.Models.DTO
{
    public class ClientDTO
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
    }
}
