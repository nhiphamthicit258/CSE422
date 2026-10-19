namespace CSE422_Lab1.Problems
{
    internal class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);
            int sign = (dividend < 0) != (divisor < 0) ? -1 : 1;

            int quotient = 0;

            while (a >= b)
            {
                long value = b;
                int multiple = 1;

                while (a >= (value << 1))
                {
                    value <<= 1;
                    multiple <<= 1;
                }

                a -= value;
                quotient += multiple;
            }

            return sign * quotient;
        }
    }
}
/*Ví dụ 10 / 3:
- (3 * 2 = 6), trừ 6 khỏi 10, còn 4.
- (3 * 1 = 3), trừ 3 khỏi 4, còn 1.
- Tổng số lần chia được là (2 + 1 = 3).
Code dùng dịch bit << để nhân đôi nhanh, không sử dụng toán tử *, /, % trong thuật toán.
long được dùng để tránh tràn số khi xử lý giá trị int.MinValue.*/