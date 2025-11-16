using System;

namespace QuizApp.Models
{
    /// <summary>
    /// Enum định nghĩa các role trong hệ thống
    /// </summary>
    public enum UserRole
    {
        Student = 0,
        Teacher = 1,
        Admin = 2
    }

    /// <summary>
    /// Lớp đại diện cho người dùng hệ thống
    /// </summary>
    public class User
    {
        // Các property public để XML Serializer không lỗi
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // sử dụng PasswordHash
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Constructor mặc định (quan trọng cho XML Serializer)
        /// </summary>
        public User()
        {
            Id = 0;
            Username = string.Empty;
            PasswordHash = string.Empty;
            FullName = string.Empty;
            Email = string.Empty;
            Role = UserRole.Student;
            IsActive = true;
            CreatedDate = DateTime.Now;
            Phone = string.Empty;
            Address = string.Empty;
        }

        /// <summary>
        /// Constructor đầy đủ
        /// </summary>
        public User(int id, string username, string passwordHash, string fullName, string email, UserRole role, bool isActive)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
            Role = role;
            IsActive = isActive;
            CreatedDate = DateTime.Now;
            Phone = string.Empty;
            Address = string.Empty;
        }

        /// <summary>
        /// Override ToString
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {FullName} ({Role})";
        }
    }
}
