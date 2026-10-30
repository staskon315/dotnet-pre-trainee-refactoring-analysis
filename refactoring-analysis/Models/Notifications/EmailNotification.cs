class EmailNotification : INotification
{
    public  void Send(string email, string name) => Console.WriteLine($"Sending EMAIL to {email}: Welcome, {name}!");
}