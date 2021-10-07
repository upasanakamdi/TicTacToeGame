using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Game.Core.Enums;
using Game.Core.Events;
using Game.Core.Factories.Interfaces;
using Game.Core.Scenarios;
using Game.Core.Scenarios.Interfaces;
using Game.UI.Repositories;
using Prism.Commands;
using Prism.Events;

namespace Game.UI.ViewModels
{
    public class TicTacToeGridViewModel : ViewModelBase
    {
        private readonly IGridRepostiory _gridRepository;
        private readonly IGameScenarioFactory _gameScenarioFactory;
        private readonly IEventAggregator _eventAggregator;
        private IGameScenario _gameScenario;
        private GameMode _currentGameMode;
        private Player _currentPlayer;
        private bool _playerWon;
        private int _moveCount;

        public TicTacToeGridViewModel(IGridRepostiory gridRepository, IGameScenarioFactory gameScenarioFactory, 
            IEventAggregator eventAggregator)
        {
            _gridRepository = gridRepository;
            _gameScenarioFactory = gameScenarioFactory;
            _eventAggregator = eventAggregator;
            TicTacToeBoard = new ObservableCollection<ObservableCollection<Player>>();
            MakeMoveCommand = new DelegateCommand<int[]>(OnMakeMoveExecute, OnMakeMoveCanExecute);
            _eventAggregator.GetEvent<GridControlSettingsEvent>().Subscribe(LatestGameScenario);
            _eventAggregator.GetEvent<InitialiseNewGridEvent>().Subscribe(Load);
        }

        public ObservableCollection<ObservableCollection<Player>> TicTacToeBoard { get; set; }

        public bool PlayerWon
        {
            get => _playerWon;
            set
            {
                _playerWon = value;
                OnPropertyChanged();
            }
        }

        public ICommand MakeMoveCommand { get; }

        public void Load(bool loadGrid = true)
        {
            PlayerWon = false;
            TicTacToeBoard.Clear();
            foreach (var row in _gridRepository.GetGridData())
            {
                var observableRow = new ObservableCollection<Player>();
                foreach (var column in row)
                {
                    observableRow.Add(column);
                }
                TicTacToeBoard.Add(observableRow);
            }
        }

        public bool OnMakeMoveCanExecute(int[] positions)
        {
            int boardCount = TicTacToeBoard.Count;
            if (!PlayerWon && boardCount > 0 && _moveCount == Math.Pow(TicTacToeBoard.Count, 2))
            {
                _moveCount = 0;
                bool START_NEW_GAME = true;
                _eventAggregator.GetEvent<StartNewGameEvent>().Publish(START_NEW_GAME);
                return START_NEW_GAME;
            }
            return boardCount > 0 && TicTacToeBoard[positions[0]][positions[1]] == Player.Unknown && _currentPlayer != Player.Unknown && 
                   _currentGameMode != GameMode.None;
        }

        public void OnMakeMoveExecute(int[] positions)
        {
            PlayRequest playRequest = new PlayRequest
            { TicTacToeBoard = TicTacToeBoard, XPosition = positions[0], YPosition = positions[1] };
            PlayResponse response = _gameScenario.Execute(playRequest);
            _moveCount++;
            PlayerWon = response.PlayerWon;
            if (PlayerWon)
            {
                _eventAggregator.GetEvent<StartNewGameEvent>().Publish(PlayerWon);
            }
        }

        private void LatestGameScenario(GridControlSettings gridControlSettings)
        {
            _currentPlayer = gridControlSettings.CurrentPlayer;
            _currentGameMode = gridControlSettings.CurrentGameMode;
            _gameScenario = _gameScenarioFactory.Create(_currentGameMode, _currentPlayer);
        }
    }
}
