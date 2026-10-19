namespace CSE422_Lab1.Problems
{
    internal class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (Search(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Search(char[][] board, string word,
                            int row, int col, int index)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (row < 0 || row >= board.Length ||
                col < 0 || col >= board[row].Length ||
                board[row][col] != word[index])
            {
                return false;
            }

            char temp = board[row][col];
            board[row][col] = '#';

            bool found =
                Search(board, word, row - 1, col, index + 1) ||
                Search(board, word, row + 1, col, index + 1) ||
                Search(board, word, row, col - 1, index + 1) ||
                Search(board, word, row, col + 1, index + 1);

            board[row][col] = temp;

            return found;
        }
    }
}

/*Thuật toán sử dụng Backtracking (quay lui):
1. Tìm chữ đầu tiên của từ.
2. Thử đi lên, xuống, trái, phải để tìm chữ tiếp theo.
3. Đánh dấu ô đã đi bằng '#' để không sử dụng lại.
4. Nếu không tìm được, quay lui và thử hướng khác.*/