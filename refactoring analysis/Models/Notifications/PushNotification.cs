class PushNotification : AbstractNotification
{
    public override void Send(string email, string name) => Console.WriteLine($"Sending PUSH notification to {name}");
}