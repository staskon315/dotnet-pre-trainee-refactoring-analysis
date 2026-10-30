class EmailNotification : AbstractNotification
{
    public override void Send(string email, string name) => Console.WriteLine($"Sending EMAIL to {email}: Welcome, {name}!");
}