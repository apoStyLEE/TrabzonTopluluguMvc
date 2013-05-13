using System.ComponentModel.DataAnnotations;

namespace TrabzonToplulugu.Models.FormModel
{
    public class MemberFormModel
    {
        [Required(ErrorMessage = "Bu alan boş olamaz")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}