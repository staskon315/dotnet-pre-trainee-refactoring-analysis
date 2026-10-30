
using System.ComponentModel.DataAnnotations;

public class UserService
{
    private readonly List<User> _users = new();

    public void RegisterUser(
        int id,
        string name,
        string email,
        AbstractNotification notification)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name is required.");
            return;
        }

        if (!EmailISValid(email)) return;

        // Create user
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email,
            Discount = name.Length > 10 ? 10 : 5 // Business rule
        };

        // Save user
        _users.Add(user);

        // Send notification
        notification.Send(email, name);

        // Logging
        Console.WriteLine(
            $"LOG: User {name} was registered at {DateTime.Now}");
    }

    public void UpdateEmail(int userId, string newEmail)
    {

        var user = _users.Find(x => x.Id == userId);

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
        foreach (var user in _users)
        {
            Console.WriteLine(
                $"{user.Id} | {user.Name} | {user.Email} | Discount: {user.Discount}%");
        }
    }
    private bool EmailISValid(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
        {
            Console.WriteLine("Email is required.");
            return false;
        }

        if (!newEmail.Contains("@"))
        {
            Console.WriteLine("Email is invalid.");
            return false;
        }

        return true;
    }

    // Added "for the future", but currently nobody needs it
    // public void GenerateAdvancedAnalyticsReport()
    // {
    //     Console.WriteLine("Generating advanced analytics...");
    //     Console.WriteLine("Calculating user behavior...");
    //     Console.WriteLine("Predicting future purchases...");
    // }
}
