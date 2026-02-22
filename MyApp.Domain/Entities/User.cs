using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string HashPassword { get; private set; }
        public UserRole Role { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected User() { }

        public User(string firstName, string? middleName, string lastName, string email, string hashPassword, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email address is required.");

            if (string.IsNullOrWhiteSpace(hashPassword))
                throw new ArgumentException("Password is required.");

            if (!Enum.IsDefined(typeof(UserRole), role))
                throw new ArgumentException("Invalid user role");

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            HashPassword = hashPassword;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateUser(string firstName, string? middleName, string lastName, string email, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email address is required.");


            if (!Enum.IsDefined(typeof(UserRole), role))
                throw new ArgumentException("Invalid user role");

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }
        public void UpdatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            HashPassword = password;
        }
    }
}
