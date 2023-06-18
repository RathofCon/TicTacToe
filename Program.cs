using System;

public class Program
{
    static int[,] board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    const int playerX = 1;
    const int playerO = 2;
    static bool winner = false;
    //static int playersMove = X;
    static int numberOfMatches = 0;
    static int totalRows = 0;
    static int totalColumns = 0;
    static int currentRow = 0;
    static int currentColumn = 0;

    // 1 = x, 2 = O

    static void SetPlayersMove(int row, int column, int playersMove)
    {
        winner = false;
        numberOfMatches = 0;
        currentRow = 0;
        currentColumn = 0;
        if (!(row > totalRows || column > totalColumns))
        {
            if (board[row, column] != 0)
            {
                Console.WriteLine("invalid move");
            }
            else
            {
                board[row, column] = playersMove;
            }
        }
        else
        {
            Console.WriteLine("invalid move");
        }
    }

    static bool TestPlayerMoveAcrossRow(int row, int column, int playersMove)
    {
        if (currentRow < totalRows && currentColumn < totalColumns && !winner)
        {

            if (board[currentRow, currentColumn] == playersMove)
            {
                winner = (++numberOfMatches == 3);
            }
            if (!winner)
            {
                winner = TestPlayerMoveAcrossRow(currentRow, ++currentColumn, playersMove);
            }
        }
        else
        {
            currentRow = 0;
            currentColumn = 0;
        }
        return winner;

    }

    static bool TestPlayerMoveDownRow(int row, int column, int playersMove)
    {
        currentColumn = column;
        if (currentRow < totalRows && currentColumn < totalColumns && !winner)
        {
            if (board[currentRow, currentColumn] == playersMove)
            {
                winner = (++numberOfMatches == 3);
            }

            if (!winner)
            {
                winner = TestPlayerMoveDownRow(++currentRow, currentColumn, playersMove);
            }
        }
        else
        {
            currentRow = 0;
            currentColumn = 0;
        }
        return winner;

    }


    static bool TestPlayerMoveDiagDown(int row, int column, int playersMove)
    {
        if (currentRow < totalRows && currentColumn < totalColumns && !winner)
        {
            if (board[currentRow, currentColumn] == playersMove)
            {
                winner = (++numberOfMatches == 3);
            }

            if (!winner)
            {
                winner = TestPlayerMoveDiagDown(++currentRow, ++currentColumn, playersMove);
            }
        }
        else
        {
            currentRow = 0;
            currentColumn = 0;
        }
        return winner;

    }


    static bool TestPlayerMoveDiagUp(int row, int column, int playersMove)
    {
        if ((currentRow < totalRows && currentRow >= 0) && (currentColumn < totalColumns && currentColumn > -0) && !winner)
        {
            if (board[currentRow, currentColumn] == playersMove)
            {
                winner = (++numberOfMatches == 3);
            }

            if (!winner)
            {
                winner = TestPlayerMoveDiagUp(--currentRow, --currentColumn, playersMove);
            }
        }
        else
        {
            currentRow = 0;
            currentColumn = 0;
        }
        return winner;

    }


    static bool TestPlayersMove(int row, int column, int playersMove)
    {

        winner = TestPlayerMoveDownRow(row, column, playersMove);
        if (!winner)
        {
            numberOfMatches = 0;
            winner = TestPlayerMoveAcrossRow(row, column, playersMove);
        }

        if (!winner)
        {
            currentRow = 0;
            currentColumn = 0;
            numberOfMatches = 0;
            winner = TestPlayerMoveDiagDown(row, column, playersMove);
        }

        if (!winner)
        {
            currentRow = totalRows - 1;
            currentColumn = totalColumns - 1;
            numberOfMatches = 0;
            winner = TestPlayerMoveDiagUp(row, column, playersMove);
        }
        return winner;
    }


    public static void Main()
    {
        int row = 0;
        int column = 0;

        totalRows = board.GetLength(0);
        totalColumns = board.Length / board.GetLength(0);

        Console.WriteLine("Game 1 - Xs across a single row");
        // X  X  X
        // .  .  .
        // .  .  .

        SetPlayersMove(row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(row, ++column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        // this is player's 2 move for O, which takes the last column of the 1st row
        SetPlayersMove(0, 2, playerO); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerO);
        Console.WriteLine((winner ? "You are a winner" : "You did not win"));

        // player 1 tries to put an X in the last column of 1st row, an invalid move
        SetPlayersMove(row, ++column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine("Game 1: " + (winner ? "You are a winner" : "You did not win"));

        Console.WriteLine("Game 2 - Xs down a single column");
        // ., X, .
        // .  X  .
        // .  X  .

        // set up for a new game
        board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        winner = false;
        column = 1;
        row = 0;


        SetPlayersMove(row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(++row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(++row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);

        Console.WriteLine("Game 2: " + (winner ? "You are a winner" : "You did not win"));


        Console.WriteLine("Game 3 - Xs diag top left to bottom right");
        // X  .   X
        // .  X   . 
        // .  .  X

        // set up for a new game
        board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        winner = false;
        column = 0;
        row = 0;

        SetPlayersMove(row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(++row, ++column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(++row, ++column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine("Game 3: " + (winner ? "You are a winner" : "You did not win"));


        Console.WriteLine("Game 4 - Xs diag bottom left to top right");
        // .  .  X
        // .  X  .
        // X  .  .

        // set up for a new game
        board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        winner = false;

        column = totalColumns - 1;
        row = totalRows - 1;

        Console.WriteLine("row: " + row + " column: " + column);

        SetPlayersMove(row, column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(--row, --column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine(winner ? "You are a winner" : "You did not win");

        SetPlayersMove(--row, --column, playerX); // 1 = X, 2 = O
        winner = TestPlayersMove(row, column, playerX);
        Console.WriteLine("Game 4: " + (winner ? "You are a winner" : "You did not win"));
    }
}