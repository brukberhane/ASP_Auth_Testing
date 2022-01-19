
using System.ComponentModel.DataAnnotations;

namespace AUTH2_TEST.Models
{

    public class User
    {
      public int Id { get; set; }
      [Display(Name = "Username: ")]
      public string Username { get; set; }
      [Display(Name = "Password: ")]
      public string Password { get; set; }
      public string Role { get; set; } 
      public string Type { get; set; }
    }

}