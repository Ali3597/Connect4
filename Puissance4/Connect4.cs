using System;
using System.Collections.Generic;
using System.Text;

namespace Puissance4
{
    public class Connect4
    {

        private int? winner;
        public int? Winner => winner;
        public int LineCount
        {
            get { return 6; }
        }
        public int ColCount => 7;


        private char[,] board;

        private bool ended;
        public bool Ended => ended;

        private int playerNumber;

        private int samePawn;

        public int PlayerNumber => playerNumber;






        public Connect4()
        {
            board = new char[LineCount, ColCount];
            initBoard();
            playerNumber = 1;
            ended = false;
            winner = null;
        }
        public void initBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public char GetPawn(int col, int line)
        {
            return board[line, col];
        }
        public void Play(int col)
        {
            if (col < 1 || col > ColCount)
            {
                throw new ArgumentOutOfRangeException("Chosissez bien votre colonne");
            }
            else
            {
                bool played = false;
                int i = LineCount;
                while (!played)
                {
                    i -= 1;
                    if (i < 0)
                    {
                        throw new ArgumentOutOfRangeException("Cette colonne est pleine ");
                    }
                    else
                    {
                        if (board[i, col - 1] == ' ')
                        {
                            played = true;
                        }
                    }
                }
                board[i, col - 1] = WichPawn();
                CheckArouNdIfThereAWin(i, col - 1);
                CheckIfThereADraw();
                playerNumber = SwitchPlayer();
            }

        }

        public char WichPawn()
        {
            if(playerNumber==2){
                return 'o';
            }else{
                return 'x';
            }
        }
        public void CheckIfThereADraw()
        {
            int counter= 0;
            int column = 0;
            while (counter== 0 && column < ColCount)
            {
                if (board[0, column] == ' ')
                {
                    counter+= 1;
                }
                column += 1;
            }
            if (counter== 0)
            {
                ended = true;
                winner = 0;
            }
        }

        public int SwitchPlayer()
        {
            if (playerNumber == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public bool AreYouOfTheBoard(int line, int col)
        {
            if (line < 0 || line >= LineCount || col < 0 || col >= ColCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CanWeWinInOneDirection(int line, int col, int verticalDirection, int horizontalDirection)
        {
            bool oneSide = true;
            bool opositeSide = true;
            int depth = 1;
            samePawn = 0;
            while ((oneSide || opositeSide) && samePawn < 3)
            {
                if (oneSide)
                {
                    oneSide= CheckNextPawn(line + (depth * verticalDirection),col + (depth * horizontalDirection));
                }
                if (opositeSide)
                {
                    opositeSide= CheckNextPawn(line - (depth * verticalDirection),col - (depth * horizontalDirection));
                }
                depth += 1;
            }
            if (samePawn == 3)
            {
                ended = true;
                winner = playerNumber;
            }

        }

        public bool CheckNextPawn(int lineToCheck, int colToCheck )
        {
                    if (!AreYouOfTheBoard(lineToCheck, colToCheck))
                    {
                        if (board[lineToCheck, colToCheck] ==WichPawn())
                        {
                            samePawn += 1;
                            return true;
                        }
                        else
                        {
                           return false;
                        }
                    }
                    else
                    {
                        return  false;
                    }
        }
        public void CheckArouNdIfThereAWin(int line, int col)
        {
            //Array OF vectors in all directions 
            //{1,0} =>VErtical
            //{0,1} => hortizontal
            //{1,-1} => Diagonal (South West to North Est)
            //{1,1} => //Diagonal (South Est to North West)
            int[,] vectors = new int[,] { { 1, 0 }, { 0, 1 }, { 1, -1 }, { 1, 1 } };
            int i = 0;
            while (!ended && i < vectors.GetLength(0))
            {
                CanWeWinInOneDirection(line, col, vectors[i, 0], vectors[i, 1]);
                i += 1;
            }
        }
    }
}
