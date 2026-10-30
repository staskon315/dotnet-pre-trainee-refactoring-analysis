public static class UserValidation
{
    public static bool EmailISValid(string newEmail)
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
    public static bool NameIsValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name is required.");
            return false;
        }
        return true;
    }
}