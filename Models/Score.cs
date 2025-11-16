using System;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp quản lý điểm số
    /// Thể hiện OPERATOR OVERLOADING (nạp chồng toán tử)
    /// </summary>
    public class Score
    {
        private int value;

        /// <summary>
        /// Giá trị điểm
        /// </summary>
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public Score()
        {
            value = 0;
        }

        /// <summary>
        /// Constructor với giá trị
        /// </summary>
        public Score(int val)
        {
            value = val;
        }

        /// <summary>
        /// Nạp chồng toán tử cộng (+)
        /// Cho phép cộng hai đối tượng Score
        /// </summary>
        public static Score operator +(Score s1, Score s2)
        {
            return new Score(s1.Value + s2.Value);
        }

        /// <summary>
        /// Nạp chồng toán tử trừ (-)
        /// </summary>
        public static Score operator -(Score s1, Score s2)
        {
            return new Score(s1.Value - s2.Value);
        }

        /// <summary>
        /// Nạp chồng toán tử tăng (++)
        /// </summary>
        public static Score operator ++(Score s)
        {
            s.Value++;
            return s;
        }

        /// <summary>
        /// Nạp chồng toán tử giảm (--)
        /// </summary>
        public static Score operator --(Score s)
        {
            s.Value--;
            return s;
        }

        /// <summary>
        /// Nạp chồng toán tử so sánh lớn hơn (>)
        /// </summary>
        public static bool operator >(Score s1, Score s2)
        {
            return s1.Value > s2.Value;
        }

        /// <summary>
        /// Nạp chồng toán tử so sánh nhỏ hơn (<)
        /// </summary>
        public static bool operator <(Score s1, Score s2)
        {
            return s1.Value < s2.Value;
        }

        /// <summary>
        /// Override ToString để hiển thị điểm
        /// </summary>
        public override string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        /// Override Equals
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Score))
                return false;

            Score other = (Score)obj;
            return this.Value == other.Value;
        }

        /// <summary>
        /// Override GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}