using System.Collections.Generic;
using System;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class GameManager : Game
{
    private Tile[,] board;
    private int size;
    private Random random;
    public int Score { get; private set; }

    public GameManager(int size)
    {
        this.size = size;
        board = new Tile[size, size];
        random = new Random();
        Score = 0;
    }

    public override void Start()
    {
        AddRandomTile();
        AddRandomTile();
    }

    public override void End()
    {
       
    }

    public void Move(Direction direction)
    {
        ResetMergedFlags();
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;
            case Direction.Down:
                MoveDown();
                break;
            case Direction.Left:
                MoveLeft();
                break;
            case Direction.Right:
                MoveRight();
                break;
        }
        if (!IsGameOver())
        {
            AddRandomTile();
        }
    }

    public bool IsGameOver()
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (board[row, col] == null)
                {
                    return false;
                }
                if (row < size - 1 && board[row + 1, col] != null && board[row, col].Value == board[row + 1, col].Value)
                {
                    return false;
                }
                if (col < size - 1 && board[row, col + 1] != null && board[row, col].Value == board[row, col + 1].Value)
                {
                    return false;
                }
                if (row > 0 && board[row - 1, col] != null && board[row, col].Value == board[row - 1, col].Value)
                {
                    return false;
                }
                if (col > 0 && board[row, col - 1] != null && board[row, col].Value == board[row, col - 1].Value)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void MoveUp()
    {
        for (int col = 0; col < size; col++)
        {
            for (int row = 1; row < size; row++)
            {
                if (board[row, col] != null)
                {
                    int targetRow = row;
                    while (targetRow > 0 && board[targetRow - 1, col] == null)
                    {
                        targetRow--;
                    }

                    if (targetRow > 0 && board[targetRow - 1, col].Value == board[row, col].Value)
                    {
                        board[targetRow - 1, col].Merge(board[row, col]);
                        Score += board[targetRow - 1, col].Value;
                        board[row, col] = null;
                    }
                    else
                    {
                        Tile temp = board[row, col];
                        board[row, col] = null;
                        board[targetRow, col] = temp;
                    }
                }
            }
        }
    }

    private void MoveDown()
    {
        for (int col = 0; col < size; col++)
        {
            for (int row = size - 2; row >= 0; row--)
            {
                if (board[row, col] != null)
                {
                    int targetRow = row;
                    while (targetRow < size - 1 && board[targetRow + 1, col] == null)
                    {
                        targetRow++;
                    }

                    if (targetRow < size - 1 && board[targetRow + 1, col].Value == board[row, col].Value)
                    {
                        board[targetRow + 1, col].Merge(board[row, col]);
                        Score += board[targetRow + 1, col].Value;
                        board[row, col] = null;
                    }
                    else
                    {
                        Tile temp = board[row, col];
                        board[row, col] = null;
                        board[targetRow, col] = temp;
                    }
                }
            }
        }
    }

    private void MoveLeft()
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 1; col < size; col++)
            {
                if (board[row, col] != null)
                {
                    int targetCol = col;
                    while (targetCol > 0 && board[row, targetCol - 1] == null)
                    {
                        targetCol--;
                    }

                    if (targetCol > 0 && board[row, targetCol - 1].Value == board[row, col].Value)
                    {
                        board[row, targetCol - 1].Merge(board[row, col]);
                        Score += board[row, targetCol - 1].Value;
                        board[row, col] = null;
                    }
                    else
                    {
                        Tile temp = board[row, col];
                        board[row, col] = null;
                        board[row, targetCol] = temp;
                    }
                }
            }
        }
    }

    private void MoveRight()
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = size - 2; col >= 0; col--)
            {
                if (board[row, col] != null)
                {
                    int targetCol = col;
                    while (targetCol < size - 1 && board[row, targetCol + 1] == null)
                    {
                        targetCol++;
                    }

                    if (targetCol < size - 1 && board[row, targetCol + 1].Value == board[row, col].Value)
                    {
                        board[row, targetCol + 1].Merge(board[row, col]);
                        Score += board[row, targetCol + 1].Value;
                        board[row, col] = null;
                    }
                    else
                    {
                        Tile temp = board[row, col];
                        board[row, col] = null;
                        board[row, targetCol] = temp;
                    }
                }
            }
        }
    }

    private void ResetMergedFlags()
    {
        foreach (var tile in board)
        {
            if (tile != null)
            {
                tile.Merged = false;
            }
        }
    }

    private void AddRandomTile()
    {
        List<(int, int)> emptyCells = new List<(int, int)>();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (board[row, col] == null)
                {
                    emptyCells.Add((row, col));
                }
            }
        }

        if (emptyCells.Count > 0)
        {
            var (row, col) = emptyCells[random.Next(emptyCells.Count)];
            board[row, col] = new Tile(random.Next(0, 10) == 0 ? 4 : 2);
        }
    }

    public Tile[,] GetBoard()
    {
        return board;
    }
}





