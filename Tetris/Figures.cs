using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{

  
    public abstract class Figures
    {
        public virtual int[,] Shape { get; }

        public virtual void Rotate()
        {

        }
    }
    public class FigureI : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1, 1, 1, 1 } };
                    case 1: return new int[,] { { 1 }, { 1 }, { 1 }, { 1 } };
                    default: return new int[,] { { 1, 1, 1, 1 } };
                };
            }
        }
        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 2;
        }
    }
    public class FigureJ : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1,0,0},{ 1, 1, 1 } };
                    case 1: return new int[,] { { 0, 1 }, { 0, 1 }, { 1, 1 } };
                    case 2: return new int[,] { { 1,1,1 },{ 0, 0, 1 } };
                    case 3: return new int[,] { {1,1 },{ 1, 0 },{ 1, 0 } };
                    default: return new int[,] { { 1, 0, 0 }, { 1, 1, 1 } };
                };
            }

        }

        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 4;
        }
    }
    public class FigureL : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 0, 0, 1 }, { 1, 1, 1 } };
                    case 1: return new int[,] { { 1, 0 }, { 1, 0 }, { 1, 1 } };
                    case 2: return new int[,] { { 1, 1, 1 }, { 1, 0, 0 } };
                    case 3: return new int[,] { {1,1 },{ 0,1},{0,1 } };
                    default: return new int[,] { { 0, 0, 1 }, { 1, 1, 1 } };
                }
            }
        }

        public override void Rotate()
        {
            rotationState = (rotationState +1 ) % 4;
        }
    }
    public class FigureO : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape => new int[,]
        {
            {1,1 },
            {1,1 }
        };
    }
    public class FigureS : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { {0, 1, 1 },{1,1,0} };
                    case 1: return new int[,] { { 1, 0 }, { 1, 1 },{ 0, 1 } };
                    default: return new int[,] { { 0, 1, 1 }, { 1, 1, 0 } };
                }
            }
        }
        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 2;
        }
    }
    public class FigureZ : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1, 1, 0 }, { 0, 1, 1 } };
                    case 1: return new int[,] { { 0, 1 }, { 1, 1 }, { 1, 0 } };
                    default: return new int[,] { { 1, 1, 0 }, { 0, 1, 1 } };
                }
            }
        }
        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 2;
        }
    }
    public class FigureT : Figures
    {
        private int rotationState = 0;
        public override int[,] Shape 
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1, 1, 1 }, { 0, 1, 0 } };
                    case 1: return new int[,] { { 0, 1 }, { 1, 1 }, { 0, 1 } };
                    case 2: return new int[,] { { 1, 0 }, { 1, 1 } ,{ 1, 0 } };
                    case 3: return new int[,] { { 0, 1, 0 }, { 1, 1, 1 } };
                    default: return new int[,] { { 1, 1, 1 }, { 0, 1, 0 } };
                }
            }
        }
        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 4;
        }
    }

}
