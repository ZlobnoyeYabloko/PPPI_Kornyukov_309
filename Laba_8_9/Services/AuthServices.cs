using Laba_7.Models;

namespace Laba_7.Services
{
    public class AuthService : IAuthService
    {
        private static List<Users> usersList = new List<Users>()
        {
            new Users
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                BithDate = new DateTime(1990, 1, 1),
                PasswordHash = "password123",
                LastLoginDate = null,
                FailedLoginAttempts = 0,
                IsBlocked = false
            },
            new Users
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "janesmith@example.com",
                BithDate = new DateTime(1995, 5, 10),
                PasswordHash = "password456",
                LastLoginDate = null,
                FailedLoginAttempts = 0,
                IsBlocked = false
            }
        };

        public Users Register(Users user)
        {
            // Перевірити, чи існує користувач з таким же електронним листом
            var existingUser = usersList.Find(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return null; // Повернути null, якщо користувач вже зареєстрований
            }

            // Додати користувача до списку
            user.Id = usersList.Count + 1;
            usersList.Add(user);

            return user;
        }

        public Users Login(string email, string password)
        {
            // Знайти користувача за email
            var user = usersList.Find(u => u.Email == email);
            if (user == null)
            {
                return null; // Повернути null, якщо користувача не знайдено
            }

            // Перевірити пароль
            if (user.PasswordHash != password)
            {
                user.FailedLoginAttempts++;
                if (user.FailedLoginAttempts >= 3)
                {
                    user.IsBlocked = true;
                }

                return null; // Повернути null, якщо пароль невірний
            }

            // Оновити дату останнього входу та скинути кількість невдалих спроб
            user.LastLoginDate = DateTime.Now;
            user.FailedLoginAttempts = 0;

            return user;
        }
    }
}
