using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media;

namespace Tetris
{
    public class Game
    {
        private int[,] gameField = new int[13, 10];
        private DispatcherTimer dropTimer;
        private const int CellSize = 30;
        private Canvas _canvas;
        private Figures currentFigure;
        private int currentX;
        private int currentY;
        private Random random;
        private int score = 0;
        public bool IsPaused { get; private set; }
        private SolidColorBrush[,] colorField = new SolidColorBrush[13, 10];

        private List<Figures> FiguresList;
        public Game(Canvas canvas)
        {
            _canvas = canvas;
            random = new Random();

            FiguresList = new List<Figures>()
            {
                new FigureI(),
                new FigureJ(),
                new FigureL(),
                new FigureO(),
                new FigureS(),
                new FigureZ(),
                new FigureT(),
            };

            dropTimer = new DispatcherTimer();
            dropTimer.Interval = TimeSpan.FromSeconds(1);
            dropTimer.Tick += DropFigure;
            dropTimer.Start();

        }
        private void DropFigure(object sender, EventArgs e)
        {
            if (CanMove(currentX, currentY + 1, currentFigure.Shape))
            {
                currentY++;
              
            }
            else
            {
                LockFigure();
                StartNewFigure();
            }

            DrawFigure();
        }
        
        public void StartNewFigure()
        {
            currentFigure = GetRandomFigure();
            currentX = 4;
            currentY = 0;

            //MessageBox.Show($"New figure: {currentFigure.GetType().Name}");

            if (!CanMove(currentX, currentY, currentFigure.Shape))
            {
                GameOver();
            }
            else
            {
                DrawFigure();
            }
        }

        private void LockFigure()
        {
            int[,] shape = currentFigure.Shape;

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if (shape[i, j] == 1)
                    {
                        int x = currentX + j;
                        int y = currentY + i;

                        if (y >= 0 && y < gameField.GetLength(0) && x >= 0 && x < gameField.GetLength(1))
                        {
                            gameField[y, x] = 1;
                            colorField[y,x] = currentFigure.Color;
                        }
                    }
                }
            }

            ClearFullLines();

        }
        private void ClearFullLines()
        {
            for (int i = gameField.GetLength(0) - 1; i >= 0; i--)
            {
                bool isFullLine = true;

                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 0) 
                    {
                        isFullLine = false;
                        break;
                    }
                }

                if (isFullLine)
                {
                    for (int s = i; s > 0; s--)
                    {
                        for (int j = 0; j < gameField.GetLength(1); j++)
                        {
                            gameField[s, j] = gameField[s - 1,j];
                        }
                    }

                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        gameField[0, j] = 0; 
                    }

                    i++;
                }
            }
            DrawGameField();
        }
        public void GameOver()
        {
            dropTimer.Stop();
            MessageBox.Show("Игра окончена!");
        }
        public Figures GetRandomFigure()
        {
            int index = random.Next(FiguresList.Count);
            return FiguresList[index];
        }
        public void StartGame()
        {
            currentFigure = GetRandomFigure();
            currentX = 0;
            currentY = 0;
            
        }
        public void DrawFigure()
        {
            ClearCanvas();
            DrawGameField();

            int[,] shape = currentFigure.Shape;
            SolidColorBrush brush = currentFigure.Color;

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if (shape[i, j] == 1)
                    {
                        System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle
                        {
                            Width = CellSize,
                            Height = CellSize,
                            Fill = brush,
                            Stroke = Brushes.Black
                        };

                        Canvas.SetLeft(rectangle, (currentX + j) * CellSize);
                        Canvas.SetTop(rectangle, (currentY + i) * CellSize);
                        _canvas.Children.Add(rectangle);
                    }
                }
            }
        }

       
        public void ResumeGame()
        {
            IsPaused = false;
            dropTimer.Stop();
        }

        public void PauseGame()
        {
            IsPaused = true;
            dropTimer.Start();
        }
        public void MoveFigure(int x, int y)
        {
            
            if (CanMove(currentX + x, currentY + y, currentFigure.Shape))
            {
                currentX += x;
                currentY += y;
            }
            DrawFigure();
        }

        public void RotateFigure()
        {
            int [,] shape = currentFigure.Shape;
            int rows = shape.GetLength(0);
            int cols = shape.GetLength(1);
            int [,] rotatedShape = new int[cols, rows];

            for (int i = 0; i < rows; i++) // по часовой стрелке
            {
                for (int j = 0; j < cols; j++)
                {
                    rotatedShape[j,rows -1 - i] = shape[i,j];
                }
            }

            if (CanMove(currentX,currentY,rotatedShape))
            {
                currentFigure.Rotate();
                DrawFigure();
            }
            
        }

        public bool CanMove(int x, int y, int[,] shape)
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if (shape[i, j] != 0)
                    {
                        int newX = x + j;
                        int newY = y + i;


                        if (newX < 0 || newX >= gameField.GetLength(1) ||
                            newY < 0 || newY >= gameField.GetLength(0))
                        {
                            return false;
                        }

                        if (newY >= 0 && newY < gameField.GetLength(0) && newX >= 0 && newX < gameField.GetLength(1) && gameField[newY, newX] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void DrawGameField()
        {

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle()
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Fill = gameField[i, j] == 1 ? colorField[i,j] : Brushes.Transparent,
                        Stroke = Brushes.Black
                    };

                    Canvas.SetLeft(rectangle, j * CellSize);
                    Canvas.SetTop(rectangle, i * CellSize);
                    _canvas.Children.Add(rectangle);
                }
            }
        }

        public void ClearGameField()
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = 0;
                }
            }
            ClearCanvas();
        }
        public void ClearCanvas()
        {
            _canvas.Children.Clear();
        }
    }   
}
