class PushNotification : INotification
{
    public  void Send(string email, string name) => Console.WriteLine($"Sending PUSH notification to {name}");
}