using System.ComponentModel;
using System.Windows.Input;
using Tetris.Models;
using System.Windows;
using System.Windows.Controls;

namespace Tetris.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Game _game;
        private int _score;
        private bool _isPaused;

        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }
        public ICommand RotateCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand RestartCommand { get; }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                _isPaused = value;
                OnPropertyChanged(nameof(IsPaused));
            }
        }

        public MainViewModel(Canvas canvas)
        {
            _game = new Game(canvas);
            _game.StartGame();

            // Инициализация команд
            MoveLeftCommand = new RelayCommand(_ => _game.MoveFigure(-1, 0));
            MoveRightCommand = new RelayCommand(_ => _game.MoveFigure(1, 0));
            RotateCommand = new RelayCommand(_ => _game.RotateFigure());
            MoveDownCommand = new RelayCommand(_ => _game.MoveFigure(0, 1));
            PauseCommand = new RelayCommand(_ => TogglePause());
            RestartCommand = new RelayCommand(_ => RestartGame());
        }

        private void TogglePause()
        {
            if (IsPaused)
                _game.ResumeGame();
            else
                _game.PauseGame();

            IsPaused = !IsPaused;
        }

        private void RestartGame()
        {
            _game.ClearGameField();
            _game.StartNewFigure();
            IsPaused = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}