namespace Notepad.ViewModels
{
    using Notepad.Models;

    public class MainViewModel
    {
        private DocumentModel _document;

        // Manages user input and style formats
        public EditorViewModel Editor { get; set; }
        
        // Manages opening, loading and saving files
        public FileViewModel File { get; set; }
        
        // Manages help information
        public HelpViewModel Help { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            Help = new HelpViewModel();
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
        }
    }
}
