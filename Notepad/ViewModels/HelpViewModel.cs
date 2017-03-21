namespace Notepad.ViewModels
{
    using System.Windows.Input;

    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayAbout);
        }

        /// <summary>
        /// Display about dialog window
        /// </summary>
        private void DisplayAbout()
        {
            var helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }
    }
}
