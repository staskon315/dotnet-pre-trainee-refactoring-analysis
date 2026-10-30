class SmsNotification : AbstractNotification
{
    public override void Send(string email, string name) => Console.WriteLine($"Sending SMS to user {name}: Welcome!");
}