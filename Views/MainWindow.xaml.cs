using System.Windows.Input;
using System.Windows;
using Tetris.ViewModels;

namespace Tetris.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var canvas = ИгровоеПоле;
            DataContext = new MainViewModel(canvas);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;

            switch (e.Key)
            {
                case Key.Left:
                    viewModel.MoveLeftCommand.Execute(null);
                    break;
                case Key.Right:
                    viewModel.MoveRightCommand.Execute(null);
                    break;
                case Key.Down:
                    viewModel.MoveDownCommand.Execute(null);
                    break;
                case Key.Up:
                    viewModel.RotateCommand.Execute(null);
                    break;
            }

            base.OnKeyDown(e);
        }
    }
}
