using System;
using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.Managers
{
    /// <summary>
    /// Lớp tạo dữ liệu mẫu cho các quiz
    /// </summary>
    public class SampleDataGenerator
    {
        /// <summary>
        /// Tạo tất cả dữ liệu mẫu
        /// </summary>
        public static void GenerateAllSampleData()
        {
            GenerateQuiz1_CSharpBasics();
            GenerateQuiz2_OOP();
            GenerateQuiz3_DataStructures();
            GenerateQuiz4_Algorithms();
            GenerateQuiz5_Database();
        }

        /// <summary>
        /// Quiz 1: C# Cơ bản (20 câu)
        /// </summary>
        private static void GenerateQuiz1_CSharpBasics()
        {
            Quiz quiz = new Quiz("C# Cơ Bản", "Kiểm tra kiến thức cơ bản về C#");
            quiz.TimeLimit = 30;

            // 15 câu trắc nghiệm
            quiz.AddQuestion(new MultipleChoiceQuestion(
                "C# được phát triển bởi công ty nào?",
                new List<string> { "Oracle", "Microsoft", "Google", "Apple" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "C# được ra mắt năm nào?",
                new List<string> { "1999", "2000", "2001", "2002" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Kiểu dữ liệu nào dùng để lưu số nguyên 32-bit?",
                new List<string> { "byte", "short", "int", "long" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào dùng để khai báo hằng số?",
                new List<string> { "var", "const", "static", "readonly" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Namespace mặc định cho Console là gì?",
                new List<string> { "System.IO", "System", "System.Console", "Microsoft" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Phương thức nào dùng để đọc dữ liệu từ bàn phím?",
                new List<string> { "Console.Write()", "Console.Read()", "Console.ReadLine()", "Console.Input()" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào dùng để tạo đối tượng mới?",
                new List<string> { "create", "new", "make", "object" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Vòng lặp nào kiểm tra điều kiện trước khi thực thi?",
                new List<string> { "do-while", "while", "foreach", "loop" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Toán tử nào dùng để so sánh bằng?",
                new List<string> { "=", "==", "===", "equals" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào dùng để kế thừa lớp?",
                new List<string> { "extends", "inherits", ":", "base" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Access modifier nào cho phép truy cập từ bất kỳ đâu?",
                new List<string> { "private", "protected", "internal", "public" },
                3, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Kiểu dữ liệu nào lưu giá trị true/false?",
                new List<string> { "bit", "boolean", "bool", "flag" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Phương thức nào là điểm vào của chương trình C#?",
                new List<string> { "Start()", "Main()", "Run()", "Begin()" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào dùng để ép kiểu?",
                new List<string> { "convert", "cast", "(type)", "as" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Collection nào không cho phép phần tử trùng lặp?",
                new List<string> { "List", "HashSet", "ArrayList", "Queue" },
                1, 1));

            // 5 câu đúng/sai
            quiz.AddQuestion(new TrueFalseQuestion(
                "C# là ngôn ngữ hướng đối tượng", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "String trong C# là kiểu dữ liệu value type", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "C# hỗ trợ đa kế thừa lớp", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Array trong C# có kích thước cố định", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "C# chạy trên .NET Framework", true, 1));

            QuizManager.Instance.AddQuiz(quiz);
        }

        /// <summary>
        /// Quiz 2: Lập trình hướng đối tượng (20 câu)
        /// </summary>
        private static void GenerateQuiz2_OOP()
        {
            Quiz quiz = new Quiz("Lập Trình Hướng Đối Tượng", "Kiểm tra kiến thức OOP");
            quiz.TimeLimit = 30;

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "OOP có bao nhiêu tính chất cơ bản?",
                new List<string> { "2", "3", "4", "5" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Tính chất nào cho phép che giấu thông tin?",
                new List<string> { "Abstraction", "Encapsulation", "Inheritance", "Polymorphism" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào dùng để khai báo lớp trừu tượng?",
                new List<string> { "virtual", "abstract", "interface", "base" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Interface có thể chứa gì?",
                new List<string> { "Phương thức với body", "Thuộc tính", "Chữ ký phương thức", "Constructor" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào gọi constructor lớp cha?",
                new List<string> { "super", "parent", "base", "this" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Phương thức nào có thể được override?",
                new List<string> { "static", "sealed", "virtual", "private" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Một lớp có thể implement bao nhiêu interface?",
                new List<string> { "0", "1", "Tối đa 5", "Không giới hạn" },
                3, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Constructor có giá trị trả về không?",
                new List<string> { "Có, trả về object", "Có, trả về void", "Không", "Tùy trường hợp" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Từ khóa nào ngăn không cho kế thừa?",
                new List<string> { "final", "sealed", "static", "const" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Property trong C# là gì?",
                new List<string> { "Biến public", "Phương thức", "Getter/Setter", "Constant" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Overloading là gì?",
                new List<string> { "Ghi đè phương thức", "Nạp chồng phương thức", "Kế thừa", "Đóng gói" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Polymorphism là tính chất gì?",
                new List<string> { "Đóng gói", "Kế thừa", "Đa hình", "Trừu tượng" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Destructor trong C# có ký tự đầu là gì?",
                new List<string> { "@", "~", "$", "!" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Static member thuộc về?",
                new List<string> { "Object", "Class", "Instance", "Method" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Access modifier mặc định của class member là?",
                new List<string> { "public", "private", "protected", "internal" },
                1, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Một lớp có thể kế thừa nhiều lớp khác", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Interface có thể chứa implementation", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Abstract class có thể được khởi tạo trực tiếp", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Static method có thể truy cập non-static member", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Constructor có thể được overload", true, 1));

            QuizManager.Instance.AddQuiz(quiz);
        }

        /// <summary>
        /// Quiz 3: Cấu trúc dữ liệu (20 câu)
        /// </summary>
        private static void GenerateQuiz3_DataStructures()
        {
            Quiz quiz = new Quiz("Cấu Trúc Dữ Liệu", "Kiểm tra kiến thức về cấu trúc dữ liệu");
            quiz.TimeLimit = 35;

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Stack hoạt động theo nguyên tắc nào?",
                new List<string> { "FIFO", "LIFO", "Random", "Priority" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Queue hoạt động theo nguyên tắc nào?",
                new List<string> { "FIFO", "LIFO", "Random", "Priority" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Binary Tree có tối đa bao nhiêu con?",
                new List<string> { "1", "2", "3", "Không giới hạn" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Hash Table sử dụng gì để lưu trữ?",
                new List<string> { "Array", "Linked List", "Key-Value", "Tree" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Độ phức tạp tìm kiếm trong Array không sắp xếp?",
                new List<string> { "O(1)", "O(log n)", "O(n)", "O(n²)" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "LinkedList sử dụng gì để liên kết?",
                new List<string> { "Index", "Pointer", "Key", "Address" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Graph có thể chứa?",
                new List<string> { "Chỉ node", "Node và edge", "Chỉ edge", "Tree" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Priority Queue sắp xếp theo?",
                new List<string> { "Thời gian", "Độ ưu tiên", "Kích thước", "Alphabet" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Binary Search Tree yêu cầu gì?",
                new List<string> { "Random", "Sorted", "Balanced", "Complete" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Heap là dạng tree gì?",
                new List<string> { "Binary", "Ternary", "N-ary", "Red-Black" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Dictionary trong C# tương đương với?",
                new List<string> { "Array", "List", "Hash Table", "Stack" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Array có lợi thế gì?",
                new List<string> { "Dynamic size", "Fast access", "No memory", "Auto sort" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Circular Queue khác Queue ở điểm nào?",
                new List<string> { "Vòng tròn", "Hai đầu", "Không giới hạn", "Ưu tiên" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Trie được dùng để lưu gì?",
                new List<string> { "Number", "String", "Object", "Image" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "AVL Tree là gì?",
                new List<string> { "Binary Tree", "Balanced BST", "Heap", "Graph" },
                1, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Array có thể thay đổi kích thước sau khi khởi tạo", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "List trong C# có kích thước động", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Stack cho phép truy cập phần tử ở giữa", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Hash Table có độ phức tạp O(1) khi tìm kiếm", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Tree luôn có root node", true, 1));

            QuizManager.Instance.AddQuiz(quiz);
        }

        /// <summary>
        /// Quiz 4: Thuật toán (20 câu)
        /// </summary>
        private static void GenerateQuiz4_Algorithms()
        {
            Quiz quiz = new Quiz("Thuật Toán", "Kiểm tra kiến thức về thuật toán");
            quiz.TimeLimit = 35;

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Bubble Sort có độ phức tạp trung bình?",
                new List<string> { "O(n)", "O(n log n)", "O(n²)", "O(log n)" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Quick Sort có độ phức tạp tốt nhất?",
                new List<string> { "O(n)", "O(n log n)", "O(n²)", "O(log n)" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Binary Search yêu cầu dữ liệu?",
                new List<string> { "Random", "Sorted", "Unique", "Small" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Merge Sort là thuật toán gì?",
                new List<string> { "Greedy", "Divide & Conquer", "Dynamic", "Backtracking" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "DFS dùng cấu trúc nào?",
                new List<string> { "Queue", "Stack", "Heap", "Tree" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "BFS dùng cấu trúc nào?",
                new List<string> { "Queue", "Stack", "Heap", "Array" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Dijkstra dùng để tìm?",
                new List<string> { "Shortest path", "Max flow", "Min cut", "Cycle" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Greedy algorithm chọn gì?",
                new List<string> { "Random", "Optimal local", "All", "Nothing" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Dynamic Programming lưu gì?",
                new List<string> { "Input", "Subproblem", "Output", "Nothing" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Linear Search có độ phức tạp?",
                new List<string> { "O(1)", "O(log n)", "O(n)", "O(n²)" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Insertion Sort tốt khi nào?",
                new List<string> { "Big data", "Small/nearly sorted", "Random", "Never" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Prim's algorithm dùng cho?",
                new List<string> { "Sorting", "Searching", "MST", "Shortest path" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Kruskal's algorithm dùng?",
                new List<string> { "BFS", "DFS", "Union-Find", "Heap" },
                2, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "A* algorithm là gì?",
                new List<string> { "Search", "Sort", "Graph", "Tree" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Backtracking thường dùng?",
                new List<string> { "Loop", "Recursion", "Iteration", "Goto" },
                1, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Quick Sort là stable sort", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Merge Sort là stable sort", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Binary Search nhanh hơn Linear Search", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Recursion luôn nhanh hơn Iteration", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Heap Sort có độ phức tạp O(n log n)", true, 1));

            QuizManager.Instance.AddQuiz(quiz);
        }

        /// <summary>
        /// Quiz 5: Cơ sở dữ liệu (20 câu)
        /// </summary>
        private static void GenerateQuiz5_Database()
        {
            Quiz quiz = new Quiz("Cơ Sở Dữ Liệu", "Kiểm tra kiến thức về database");
            quiz.TimeLimit = 30;

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "SQL là viết tắt của?",
                new List<string> { "Structured Query Language", "Simple Query Language", "Standard Query Language", "System Query Language" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Lệnh nào dùng để lấy dữ liệu?",
                new List<string> { "GET", "SELECT", "FETCH", "RETRIEVE" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Primary Key có thể NULL không?",
                new List<string> { "Có", "Không", "Tùy trường hợp", "Không biết" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Foreign Key là gì?",
                new List<string> { "Khóa ngoại", "Khóa chính", "Khóa duy nhất", "Khóa phụ" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Lệnh nào thêm dữ liệu mới?",
                new List<string> { "ADD", "INSERT", "CREATE", "PUT" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Lệnh nào cập nhật dữ liệu?",
                new List<string> { "MODIFY", "UPDATE", "CHANGE", "SET" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Lệnh nào xóa dữ liệu?",
                new List<string> { "REMOVE", "DELETE", "DROP", "CLEAR" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "JOIN dùng để làm gì?",
                new List<string> { "Tạo bảng", "Nối bảng", "Xóa bảng", "Sửa bảng" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Index dùng để?",
                new List<string> { "Lưu dữ liệu", "Tăng tốc truy vấn", "Bảo mật", "Backup" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Transaction đảm bảo tính chất gì?",
                new List<string> { "Fast", "ACID", "Simple", "Complex" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Normalization là gì?",
                new List<string> { "Chuẩn hóa", "Tối ưu", "Backup", "Index" },
                0, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "View là gì?",
                new List<string> { "Bảng thật", "Bảng ảo", "Index", "Key" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Trigger kích hoạt khi nào?",
                new List<string> { "Manual", "Auto on event", "Daily", "Never" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "Stored Procedure là gì?",
                new List<string> { "Hàm", "Thủ tục lưu trữ", "Table", "View" },
                1, 1));

            quiz.AddQuestion(new MultipleChoiceQuestion(
                "NoSQL khác SQL ở điểm nào?",
                new List<string> { "Không schema cố định", "Nhanh hơn", "Mới hơn", "Dễ hơn" },
                0, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Primary Key phải unique", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Một bảng có thể có nhiều Primary Key", false, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Foreign Key tham chiếu đến Primary Key", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Index làm chậm thao tác INSERT", true, 1));

            quiz.AddQuestion(new TrueFalseQuestion(
                "Transaction có thể rollback", true, 1));

            QuizManager.Instance.AddQuiz(quiz);
        }
    }
}