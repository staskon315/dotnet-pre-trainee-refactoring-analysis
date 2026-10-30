using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Program
{
    public static void Main()
    {
        var userService = new UserService();

        userService.RegisterUser(
            1,
            "Anna",
            "anna@example.com",
            new EmailNotification());

        userService.RegisterUser(
            2,
            "Christopher",
            "christopher@example.com",
            new SmsNotification());

        userService.UpdateEmail(
            1,
            "anna.new@example.com");

        userService.PrintAllUsers();
    }
}