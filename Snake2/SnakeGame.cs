using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake2
{
    public enum DireccioSnake
    {
        Dreta,
        Esquerre,
        Avall,
        Amunt
    }

    class SnakeGame
    {
        public const int X_SIZE = 5;
        public const int Y_SIZE = 5;

        Point capSerp = new Point(X_SIZE/2, 0);
        DireccioSnake direccio = DireccioSnake.Dreta;

        public Point CapSerp { get => capSerp; set => capSerp = value; }
        public DireccioSnake Direccio { get => direccio; set => direccio = value; }

        internal void moure(DireccioSnake direccio)
        {
            if (direccio == DireccioSnake.Amunt)
                capSerp.Y--;
            else if (direccio == DireccioSnake.Avall)
                capSerp.Y++;
            else if (direccio == DireccioSnake.Esquerre)
                capSerp.X--;
            else if (direccio == DireccioSnake.Dreta)
                capSerp.X++;
        }
    }
}
