
public class UserService
{
    private readonly List<User> _users = new();

    public void RegisterUser(
        int id,
        string name,
        string email,
        string notificationType)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name is required.");
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Email is required.");
            return;
        }

        if (!email.Contains("@"))
        {
            Console.WriteLine("Email is invalid.");
            return;
        }

        // Create user
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email
        };

        // Business rule
        if (name.Length > 10)
        {
            user.Discount = 10;
        }
        else
        {
            user.Discount = 5;
        }

        // Save user
        _users.Add(user);

        // Send notification
        if (notificationType == "email")
        {
            Console.WriteLine(
                $"Sending EMAIL to {email}: Welcome, {name}!");
        }
        else if (notificationType == "sms")
        {
            Console.WriteLine(
                $"Sending SMS to user {name}: Welcome!");
        }
        else if (notificationType == "push")
        {
            Console.WriteLine(
                $"Sending PUSH notification to {name}");
        }
        else
        {
            Console.WriteLine("Unknown notification type.");
        }

        // Logging
        Console.WriteLine(
            $"LOG: User {name} was registered at {DateTime.Now}");
    }

    public void UpdateEmail(int userId, string newEmail)
    {
        // Duplicate validation logic
        if (string.IsNullOrWhiteSpace(newEmail))
        {
            Console.WriteLine("Email is required.");
            return;
        }

        if (!newEmail.Contains("@"))
        {
            Console.WriteLine("Email is invalid.");
            return;
        }

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

    // Added "for the future", but currently nobody needs it
    public void GenerateAdvancedAnalyticsReport()
    {
        Console.WriteLine("Generating advanced analytics...");
        Console.WriteLine("Calculating user behavior...");
        Console.WriteLine("Predicting future purchases...");
    }
}
