namespace Notepad.ViewModels
{
    using Microsoft.Win32;
    using Notepad.Models;
    using System.IO;
    using System.Windows.Input;

    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand OpenCommand { get; set; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        /// <summary>
        /// Create a new blank document
        /// </summary>
        public void NewFile()
        {
            Document.FileName = "";
            Document.FilePath = "";
            Document.Text = "";
        }

        /// <summary>
        /// Save file
        /// </summary>
        private void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.Text);
        }

        /// <summary>
        /// Save file as a specific type (Only allow .txt)
        /// </summary>
        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                DocFile(saveFileDialog);
                File.WriteAllText(Document.FilePath, Document.Text);
            }
        }

        /// <summary>
        /// Open a file
        /// </summary>
        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == true)
            {
                DocFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DocFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
