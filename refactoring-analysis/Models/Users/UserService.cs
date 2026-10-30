
using System.ComponentModel.DataAnnotations;
public class UserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository) => _repository = repository;

    public void RegisterUser(
        int id,
        string name,
        string email,
        INotification notification)
    {

        if (!UserValidation.EmailISValid(email) || !UserValidation.NameIsValid(name)) return;

        // Create user
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email,
            Discount = name.Length > 10 ? 10 : 5 // Business rule
        };

        // Save user
        _repository.Add(user);

        // Send notification
        notification.Send(email, name);

        // Logging
        Console.WriteLine(
            $"LOG: User {name} was registered at {DateTime.Now}");
    }

    public void UpdateEmail(int userId, string newEmail)
    {
        if (!UserValidation.EmailISValid(newEmail)) return;

        var user = _repository.GetById(userId);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.Email = newEmail;

        Console.WriteLine(
            $"LOG: Email for user {user.Name} was changed.");
    }
    public void PrintAllUsers()
    {
        foreach (var user in _repository.GetAll())
        {
            Console.WriteLine(
                $"{user.Id} | {user.Name} | {user.Email} | Discount: {user.Discount}%");
        }
    }




    // Added "for the future", but currently nobody needs it
    // public void GenerateAdvancedAnalyticsReport()
    // {
    //     Console.WriteLine("Generating advanced analytics...");
    //     Console.WriteLine("Calculating user behavior...");
    //     Console.WriteLine("Predicting future purchases...");
    // }
}
