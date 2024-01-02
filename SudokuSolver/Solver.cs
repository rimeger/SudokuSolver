namespace SudokuSolver
{
    public class Solver
    {
        private char[,] _board;
        private int _size;

        public Solver(char[,] board)
        {
            _board = board;
            _size = board.GetLength(0);
        }

        public bool SolveSudoku()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_board[i, j] == '.')
                    {
                        for (char k = '1'; k <= Convert.ToChar(_size + '0'); k++)
                        {
                            if(IsPossible(i, j, k))
                            {
                                _board[i, j] = k;
                                if (SolveSudoku()) {
                                    return true;
                                }
                                else
                                {
                                    _board[i, j] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsPossible(int row, int col, char number)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_board[row, i] == number) {
                    return false;
                }
                if (_board[i, col] == number) { 
                return false;
                }
                if (_board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == number) {
                    return false;
                }
            }
            return true;
        }

        public void PrintSudoku()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
