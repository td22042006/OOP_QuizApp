using System;

namespace QuizApp.Interfaces
{
    /// <summary>
    /// Interface định nghĩa các phương thức lưu/đọc dữ liệu
    /// Thể hiện tính TRỪU TƯỢNG qua Interface
    /// </summary>
    public interface IDataStore
    {
        /// <summary>
        /// Lưu dữ liệu vào file
        /// </summary>
        /// <param name="filePath">Đường dẫn file</param>
        void Save(string filePath);

        /// <summary>
        /// Đọc dữ liệu từ file
        /// </summary>
        /// <param name="filePath">Đường dẫn file</param>
        void Load(string filePath);

        /// <summary>
        /// Kiểm tra file có tồn tại không
        /// </summary>
        /// <param name="filePath">Đường dẫn file</param>
        /// <returns>True nếu tồn tại</returns>
        bool FileExists(string filePath);
    }
}