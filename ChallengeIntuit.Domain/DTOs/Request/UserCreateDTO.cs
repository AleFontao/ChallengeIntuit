using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIntuit.Domain.DTOs.Request
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        [RegularExpression(@"^\d{2}-\d{8}-\d$", ErrorMessage = "El CUIT debe tener el formato XX-XXXXXXXX-X")]
        public string CUIT { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Formato de email invalido")]
        public string Email { get; set; }
    }
}
