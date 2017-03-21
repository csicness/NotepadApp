namespace Notepad.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using Notepad.Models;

    public class EditorViewModel
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new RelayCommand(OpenStyleDialogue);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        /// <summary>
        /// Open the dialog that allows formatting font style, size and weight
        /// </summary>
        private void OpenStyleDialogue()
        {
            var formatDialog = new FormatDialog();
            formatDialog.DataContext = Format;
            formatDialog.ShowDialog();
        }

        /// <summary>
        /// Enable / Disable text wrapping
        /// </summary>
        private void ToggleWrap()
        {
            if (Format.Wrapping == TextWrapping.Wrap)
            {
                Format.Wrapping = TextWrapping.NoWrap;
            }
            else
            {
                Format.Wrapping = TextWrapping.Wrap;
            }
        }
    }
}
