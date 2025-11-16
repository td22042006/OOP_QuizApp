using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Managers
{
    /// <summary>
    /// Lớp triển khai IDataStore để lưu/đọc dữ liệu XML
    /// Sử dụng XML SERIALIZATION
    /// </summary>
    public class XmlDataStore : IDataStore
    {
        /// <summary>
        /// Lưu dữ liệu quiz ra file XML
        /// </summary>
        public void Save(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    List<Quiz> quizzes = QuizManager.Instance.Quizzes;
                    serializer.Serialize(fs, quizzes);
                }
            }
            catch (IOException ex)
            {
                throw new Exception("Lỗi khi lưu file: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Đọc dữ liệu quiz từ file XML
        /// </summary>
        public void Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File không tồn tại: " + filePath);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    List<Quiz> loaded = (List<Quiz>)serializer.Deserialize(fs);

                    QuizManager.Instance.Quizzes.Clear();

                    foreach (Quiz q in loaded)
                    {
                        QuizManager.Instance.AddQuiz(q);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Không tìm thấy file: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("File XML không hợp lệ: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đọc file: " + ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra file có tồn tại không
        /// </summary>
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Lưu kết quả thi
        /// </summary>
        public void SaveResults(string filePath, List<QuizResult> results)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<QuizResult>));

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, results);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu kết quả: " + ex.Message);
            }
        }

        /// <summary>
        /// Đọc kết quả thi
        /// </summary>
        public List<QuizResult> LoadResults(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<QuizResult>();
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<QuizResult>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return (List<QuizResult>)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đọc kết quả: " + ex.Message);
            }
        }
    }
}