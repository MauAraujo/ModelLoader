using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto
{
    public class Textura2D
    {
        private int id;
        private int width, height;

        public int Id { get => id; set => id = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public Textura2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
    }
}
