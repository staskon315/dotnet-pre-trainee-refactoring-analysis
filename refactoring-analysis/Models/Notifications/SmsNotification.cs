class SmsNotification : INotification
{
    public  void Send(string email, string name) => Console.WriteLine($"Sending SMS to user {name}: Welcome!");
}