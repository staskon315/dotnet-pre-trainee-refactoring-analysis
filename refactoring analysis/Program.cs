using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var userService = new UserService();

        userService.RegisterUser(
            1,
            "Anna",
            "anna@example.com",
            "email");

        userService.RegisterUser(
            2,
            "Christopher",
            "christopher@example.com",
            "sms");

        userService.UpdateEmail(
            1,
            "anna.new@example.com");

        userService.PrintAllUsers();
    }
}