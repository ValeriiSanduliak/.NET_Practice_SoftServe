using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public bool IsReserved { get; set; }

    public bool? IsActive { get; set; }

    public string? Token { get; set; }

    public string? UserRole { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public User() { }

    public User(string name, string email, string password, string role)
    {
        UserName = name;
        UserEmail = email;
        UserPassword = password;
        UserRole = role;
    }
}

public class LoginUser
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class RegisterUser
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
