using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tetris;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game gameInstance;
        public MainWindow()
        {
            InitializeComponent();
            gameInstance = new Game(ИгровоеПоле);
            gameInstance.StartGame();
            gameInstance.DrawFigure();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);

            switch (e.Key)
            {
                case Key.Left:
                    try
                    {
                        gameInstance.MoveFigure(-1, 0);
                    }
                    finally
                    {
                        gameInstance.MoveFigure(0, 0);
                    }
                    break;
                case Key.Right:
                    gameInstance.MoveFigure(1, 0);
                    break;
                case Key.Down:
                    gameInstance.MoveFigure(0, 1);
                    break;
                case Key.Up:
                    gameInstance.RotateFigure();
                    break;
            }

        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameInstance.IsPaused)
            {
                gameInstance.ResumeGame();
            }
            else
            {
                gameInstance.PauseGame();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameInstance.IsPaused)
            {
                gameInstance.ResumeGame();
            }
            else
            {
                gameInstance.PauseGame();
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
           if (gameInstance.IsPaused)
            {
                gameInstance.ResumeGame();
            }
           gameInstance.ClearGameField();
           gameInstance.StartNewFigure();
           gameInstance.PauseGame();
        }
    }
}