using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._02._2023_hw
{
    internal class Matrix
    {
        int[,] matrix = null;
        public int[,] Content { get => matrix; }
        public void Input()
        {
            string buffer;
            int w, h;

            Console.Write("Enter w: ");
            buffer = Console.ReadLine();
            w = int.Parse(buffer);

            Console.Write("Enter h: ");
            buffer = Console.ReadLine();
            h = int.Parse(buffer);

            matrix = new int[w, h];
            for (int y = 0; y < h; y++)
            {
                Console.Write($"Enter line{y + 1}: ");
                buffer = Console.ReadLine();
                string[] nums = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < w; x++) matrix[x, h] = int.Parse(nums[x]);
            }
        }
        public void Output() => Console.WriteLine(this.ToString());
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    sb.Append(matrix[x, y] + ' ');
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        public static Matrix operator+ (Matrix m1, Matrix m2)
        {
            if (m1.Content.GetLength(0) != m2.Content.GetLength(0) ||
                m1.Content.GetLength(1) != m2.Content.GetLength(1))
                throw new Exception("Matrices must be the same size");

            Matrix res = new Matrix();
            res.matrix = new int[m1.Content.GetLength(0), m1.Content.GetLength(1)];
            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                {
                    res.matrix[x, y] = m1.Content[x, y] + m2.Content[x, y];
                }
            return res;
        }
        public static Matrix operator- (Matrix m1, Matrix m2)
        {
            if (m1.Content.GetLength(0) != m2.Content.GetLength(0) ||
                m1.Content.GetLength(1) != m2.Content.GetLength(1))
                throw new Exception("Matrices must be the same size");

            Matrix res = new Matrix();
            res.matrix = new int[m1.Content.GetLength(0), m1.Content.GetLength(1)];
            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                {
                    res.matrix[x, y] = m1.Content[x, y] - m2.Content[x, y];
                }
            return res;
        }
        public static Matrix operator* (Matrix m1, Matrix m2)
        {
            if (m1.Content.GetLength(0) != m2.Content.GetLength(0) ||
                m1.Content.GetLength(1) != m2.Content.GetLength(1))
                throw new Exception("Matrices must be the same size");

            Matrix res = new Matrix();
            res.matrix = new int[m1.Content.GetLength(0), m1.Content.GetLength(1)];
            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                {
                    res.matrix[x, y] = m1.Content[x, y] * m2.Content[x, y];
                }
            return res;
        }
        public static Matrix operator* (Matrix m1, int n)
        {
            Matrix res = new Matrix();
            res.matrix = new int[m1.Content.GetLength(0), m1.Content.GetLength(1)];
            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                {
                    res.matrix[x, y] = m1.Content[x, y] * n;
                }
            return res;
        }
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1.Content.GetLength(0) != m2.Content.GetLength(0) ||
                m1.Content.GetLength(1) != m2.Content.GetLength(1))
                throw new Exception("Matrices must be the same size");

            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                    if (m1.Content[x, y] != m2.Content[x, y]) return false;
            return true;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            if (m1.Content.GetLength(0) != m2.Content.GetLength(0) ||
                m1.Content.GetLength(1) != m2.Content.GetLength(1))
                throw new Exception("Matrices must be the same size");

            for (int y = 0; y < m1.Content.GetLength(0); y++)
                for (int x = 0; x < m1.Content.GetLength(1); x++)
                    if (m1.Content[x, y] == m2.Content[x, y]) return false;
            return true;
        }
        public int this[int i1, int i2]
        {
            get => matrix[i1, i2];
            set => matrix[i1, i2] = value;
        }
    }
}
