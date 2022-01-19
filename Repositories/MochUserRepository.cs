using AUTH2_TEST.Models;

namespace AUTH2_TEST.Repositories
{

  public static class MochUserRepository
  {
    public static User Get(String username, string password)
    {
      var users = new List<User>();
      users.Add(new User { Id = 1, Username = "bruk", Password = "bruk", Role = "tester", Type = Constants.UserTypes.Student });
			users.Add(new User { Id = 1, Username = "bruk", Password = "blec1", Role = "employee", Type = Constants.UserTypes.Lecturer });
			users.Add(new User { Id = 1, Username = "bruk", Password = "breg1", Role = "manager", Type = Constants.UserTypes.Registrar });
			users.Add(new User { Id = 1, Username = "borc", Password = "blec2", Role = "employee", Type = Constants.UserTypes.Lecturer });
			return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
    }
  }
  
}