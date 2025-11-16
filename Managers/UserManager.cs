using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using QuizApp.Models;
using System.IO;
using System.Xml.Serialization;

namespace QuizApp.Managers
{
    public sealed class UserManager
    {
        private static readonly UserManager instance = new UserManager();
        private List<User> users;
        private User currentUser;
        private string userFile = "users.xml"; // file lưu user

        private UserManager()
        {
            users = new List<User>();
            currentUser = null;

            LoadUsers(); // load từ file XML nếu có

            // Nếu chưa có admin, tạo admin mặc định
            if (FindUserByUsername("admin") == null)
            {
                User adminUser = new User
                {
                    Id = GetNextUserId(),
                    Username = "admin",
                    PasswordHash = HashPassword("admin123"),
                    FullName = "Administrator",
                    Email = "admin@example.com",
                    Role = UserRole.Admin,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };
                users.Add(adminUser);
                SaveUsers();
            }
        }

        public static UserManager Instance => instance;
        public List<User> Users => users;
        public User CurrentUser { get => currentUser; set => currentUser = value; }

        private int GetNextUserId()
        {
            int maxId = 0;
            for (int i = 0; i < users.Count; i++)
                if (users[i].Id > maxId) maxId = users[i].Id;
            return maxId + 1;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        // ==================== CRUD user ====================
        public bool AddUser(User user)
        {
            if (user == null || FindUserByUsername(user.Username) != null)
                return false;

            users.Add(user);
            SaveUsers(); // ✅ lưu ngay
            return true;
        }

        public bool RemoveUser(int userId)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == userId)
                {
                    users.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }


        public bool UpdateUser(User user)
        {
            User existingUser = FindUserById(user.Id);
            if (existingUser == null) return false;

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.Address = user.Address;
            existingUser.Role = user.Role;
            existingUser.IsActive = user.IsActive;

            SaveUsers(); // ✅ lưu ngay
            return true;
        }

        public bool CreateUserByAdmin(string username, string password, string fullName, string email, UserRole role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            if (FindUserByUsername(username) != null || FindUserByEmail(email) != null)
                return false;

            User newUser = new User
            {
                Id = GetNextUserId(),
                Username = username,
                PasswordHash = HashPassword(password),
                FullName = fullName,
                Email = email,
                Role = role,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            return AddUser(newUser); // AddUser sẽ lưu XML
        }

        public User FindUserByUsername(string username)
        {
            return users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public User FindUserById(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public User FindUserByEmail(string email)
        {
            return users.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool RegisterUser(string username, string password, string fullName, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;
            if (FindUserByUsername(username) != null || FindUserByEmail(email) != null) return false;

            User newUser = new User
            {
                Id = GetNextUserId(),
                Username = username,
                PasswordHash = HashPassword(password),
                FullName = fullName,
                Email = email,
                Role = UserRole.Student,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            return AddUser(newUser); // AddUser sẽ lưu XML
        }

        public bool Login(string username, string password)
        {
            User user = FindUserByUsername(username);
            if (user != null && user.IsActive && VerifyPassword(password, user.PasswordHash))
            {
                currentUser = user;
                return true;
            }
            return false;
        }

        public void Logout()
        {
            currentUser = null;
        }

        public bool ToggleUserStatus(int userId)
        {
            User user = FindUserById(userId);
            if (user != null)
            {
                user.IsActive = !user.IsActive;
                SaveUsers(); // ✅ lưu ngay
                return true;
            }
            return false;
        }

        // ==================== XML ====================
        public void SaveUsers()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream(userFile, FileMode.Create))
                {
                    serializer.Serialize(fs, users);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu User: " + ex.Message);
            }
        }

        public void LoadUsers()
        {
            if (!File.Exists(userFile)) return;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream(userFile, FileMode.Open))
                {
                    users = (List<User>)serializer.Deserialize(fs);
                }
            }
            catch
            {
                users = new List<User>(); // nếu lỗi XML, tạo danh sách trống
            }
        }
        public int GetUserCountByRole(UserRole role)
        {
            int count = 0;
            for (int i = 0; i < users.Count; i++)
            {
                User u = users[i];
                if (u.Role == role)
                {
                    count++;
                }
            }
            return count;
        }

        public void ClearAllUsers()
        {
            users.Clear();

            // Tạo lại admin mặc định
            User adminUser = new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = HashPassword("admin123"),
                FullName = "Administrator",
                Email = "admin@example.com",
                Role = UserRole.Admin,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            users.Add(adminUser);

            SaveUsers();
        }
        public void ReassignUserIds()
        {
            // Sắp xếp user theo Id cũ để giữ thứ tự
            users.Sort((a, b) => a.Id.CompareTo(b.Id));

            // Cập nhật Id mới 1..n
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Id = i + 1;
            }

            SaveUsers(); 
        }
    }

}
