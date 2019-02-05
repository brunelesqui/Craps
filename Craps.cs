using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps
{
    public class Craps
    {
        private int dice1;
        private int dice2;
        private int point;
        private Status gameStatus;

        public enum Status
        {
            START,
            CONTINUE,
            WIN,
            LOSE,
            CRAPS
        };

        private enum Dices
        {
            TWO    = 2,
            THREE  = 3,
            SEVEN  = 7,
            ELEVEN = 11,
            TWELVE = 12
        };

        public int Dice1
        {
            get
            {
                return dice1;
            }
        }

        public int Dice2
        {
            get
            {
                return dice2;
            }
        }

        public int Point
        {
            get
            {
                return point;
            }
        }

        public Craps()
        {
            Reset();
        }

        public void Reset ()
        {
            gameStatus = Status.START;
            dice1 = 0;
            dice2 = 0;
            point = 0;
        }

        public Status ThrowDice ()
        {
            Random randomNumber = new Random();

            dice1 = randomNumber.Next(1, 7);
            dice2 = randomNumber.Next(1, 7);

            return Check();
        }

        private Status Check ()
        {
            if(gameStatus == Status.START)
            {
                switch((Dices) (dice1 + dice2))
                {
                    case Dices.SEVEN:
                    case Dices.ELEVEN:
                        gameStatus = Status.WIN;
                        break;
                    case Dices.TWO:
                    case Dices.THREE:
                    case Dices.TWELVE:
                        gameStatus = Status.CRAPS;
                        break;
                    default:
                        gameStatus = Status.CONTINUE;
                        point = dice1 + dice2;
                        break;
                }
            }
            else
            {
                if ((dice1 + dice2) == point)
                    gameStatus = Status.WIN;
                else if ((dice1 + dice2) == (int)Dices.SEVEN)
                    gameStatus = Status.LOSE;
            }

            return gameStatus;
        }
    }
}
