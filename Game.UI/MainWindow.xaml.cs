using System.Windows;
using Game.Core;
using Game.Core.Factories;
using Game.Core.Factories.Interfaces;
using Game.Core.GameModels;
using Game.UI.Repositories;
using Game.UI.ViewModels;
using Prism.Events;

namespace Game.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            IEngine gameEngine = new GameEngine();
            IPlayerFactory playerFactory = new PlayerFactory(gameEngine);
            IGameScenarioFactory gameScenarioFactory = new GameScenarioFactory(playerFactory);
            IEventAggregator eventAggregator = new EventAggregator();
            _viewModel = new MainViewModel(
                new TicTacToeGridViewModel(new GridRepository(new TicTacToeGridModel()), gameScenarioFactory, eventAggregator), 
                new TicTacToeControlsViewModel(new ControlsRepository(new TicTacToeControlsModel()), eventAggregator));
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
}
