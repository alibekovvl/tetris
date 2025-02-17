using System.Windows.Media;

namespace Tetris.Models
{


    public abstract class Figures
    {
        private static Random random = new Random();
        public virtual int[,] Shape { get; }

        public SolidColorBrush Color { get; set; }
        public Figures()
        {
            Color = GetBrushesColor();
        }
        public Color[] colors = new Color[]
        {
            Colors.Red,
            Colors.Blue,
            Colors.Green,
            Colors.Yellow,
            Colors.Orange,
            Colors.Pink,
            Colors.Purple,
        };
        public SolidColorBrush GetBrushesColor()
        {
            int index = random.Next(colors.Length);
            return new SolidColorBrush(colors[index]);

        }
        public virtual void Rotate()
        {

        }
    }
    public class FigureI : Figures
    {
        private int rotationState = 0;
        public FigureI()
        {
            Color = GetBrushesColor();
        }
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
        public FigureJ()
        {
            Color = GetBrushesColor();
        }
        public override int[,] Shape
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1, 0, 0 }, { 1, 1, 1 } };
                    case 1: return new int[,] { { 0, 1 }, { 0, 1 }, { 1, 1 } };
                    case 2: return new int[,] { { 1, 1, 1 }, { 0, 0, 1 } };
                    case 3: return new int[,] { { 1, 1 }, { 1, 0 }, { 1, 0 } };
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
        public FigureL()
        {
            Color = GetBrushesColor();
        }
        public override int[,] Shape
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 0, 0, 1 }, { 1, 1, 1 } };
                    case 1: return new int[,] { { 1, 0 }, { 1, 0 }, { 1, 1 } };
                    case 2: return new int[,] { { 1, 1, 1 }, { 1, 0, 0 } };
                    case 3: return new int[,] { { 1, 1 }, { 0, 1 }, { 0, 1 } };
                    default: return new int[,] { { 0, 0, 1 }, { 1, 1, 1 } };
                }
            }
        }

        public override void Rotate()
        {
            rotationState = (rotationState + 1) % 4;
        }
    }
    public class FigureO : Figures
    {
        private int rotationState = 0;
        public FigureO()
        {
            Color = GetBrushesColor();
        }
        public override int[,] Shape => new int[,]
        {
            {1,1 },
            {1,1 }
        };
    }
    public class FigureS : Figures
    {
        private int rotationState = 0;
        public FigureS()
        {
            Color = GetBrushesColor();
        }
        public override int[,] Shape
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 0, 1, 1 }, { 1, 1, 0 } };
                    case 1: return new int[,] { { 1, 0 }, { 1, 1 }, { 0, 1 } };
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
        public FigureZ()
        {
            Color = GetBrushesColor();
        }
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
        public FigureT()
        {
            Color = GetBrushesColor();
        }
        public override int[,] Shape
        {
            get
            {
                switch (rotationState)
                {
                    case 0: return new int[,] { { 1, 1, 1 }, { 0, 1, 0 } };
                    case 1: return new int[,] { { 0, 1 }, { 1, 1 }, { 0, 1 } };
                    case 2: return new int[,] { { 1, 0 }, { 1, 1 }, { 1, 0 } };
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
