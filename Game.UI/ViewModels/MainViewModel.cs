namespace Game.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(TicTacToeGridViewModel ticTacToeGridViewModel, TicTacToeControlsViewModel ticTacToeControlsViewModel)
        {
            TicTacToeGridViewModel = ticTacToeGridViewModel;
            TicTacToeControlsViewModel = ticTacToeControlsViewModel;
        }

        public TicTacToeGridViewModel TicTacToeGridViewModel { get;}

        public TicTacToeControlsViewModel TicTacToeControlsViewModel { get; }

        public void Load()
        {
            TicTacToeGridViewModel.Load();
            TicTacToeControlsViewModel.Load();
        }
    }
}
