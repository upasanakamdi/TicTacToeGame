using System.Collections.ObjectModel;
using System.Windows.Input;
using Game.Core.Enums;
using Game.Core.Events;
using Game.Core.Scenarios.Interfaces;
using Game.UI.Repositories;
using Prism.Commands;
using Prism.Events;

namespace Game.UI.ViewModels
{
    public class TicTacToeControlsViewModel : ViewModelBase
    {
        private Player _player;
        private GameMode _gameMode;
        private readonly IControlsRepository _controlsRepository;
        private readonly IEventAggregator _eventAggregator;
        private IGameScenario _gameScenario;
        private bool _startNewGame;

        public TicTacToeControlsViewModel(IControlsRepository controlsRepository, IEventAggregator eventAggregator)
        {
            _controlsRepository = controlsRepository;
            _eventAggregator = eventAggregator;
            _startNewGame = true;
            GameModes = new ObservableCollection<GameMode>();
            Players = new ObservableCollection<Player>();
            StartGameCommand = new DelegateCommand(OnStartGameExecute, OnStartGameCanExecute);
            _eventAggregator.GetEvent<StartNewGameEvent>().Subscribe(OnStartNewGame);
        }

        public ObservableCollection<GameMode> GameModes { get; }

        public ObservableCollection<Player> Players { get; }

        public GameMode SelectedGameMode
        {
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                OnPropertyChanged();
                ((DelegateCommand)StartGameCommand).RaiseCanExecuteChanged();
            }
        }

        public Player SelectedPlayer
        {
            get { return _player; }
            set
            {
                _player = value;
                OnPropertyChanged();
                ((DelegateCommand)StartGameCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand StartGameCommand { get; }

        public bool StartNewGame
        {
            get => _startNewGame;
            set
            {
                _startNewGame = value;
                OnPropertyChanged();
                ((DelegateCommand)StartGameCommand).RaiseCanExecuteChanged();
            }
        }

        private bool OnStartGameCanExecute()
        {
            return SelectedGameMode != GameMode.None && SelectedPlayer != Player.Unknown && StartNewGame;
        }

        public void Load()
        {
            foreach (var gameMode in _controlsRepository.GetGameModes())
            {
                GameModes.Add(gameMode);
            }

            foreach (var player in _controlsRepository.GetPlayers())
            {
                Players.Add(player);
            }
        }

        private void OnStartGameExecute()
        {
            StartNewGame = false;
            _eventAggregator.GetEvent<InitialiseNewGridEvent>().Publish(true);
            _eventAggregator.GetEvent<GridControlSettingsEvent>().Publish(new GridControlSettings()
            { CurrentPlayer = _player, CurrentGameMode = _gameMode });
        }

        private void OnStartNewGame(bool startNewGame)
        {
            StartNewGame = startNewGame;
        }
    }
}
