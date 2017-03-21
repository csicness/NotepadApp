namespace Notepad.Models
{
    using System.Windows;
    using System.Windows.Media;

    public class FormatModel : ObservableObject
    {
        private FontWeight _weight;
        private FontStyle _style;
        private FontFamily _family;
        private TextWrapping _wrapping;
        private bool _isWrapped;
        private double _size;

        public FontWeight Weight
        {
            get { return _weight; }
            set { OnPropertyChanged(ref _weight, value); }
        }

        public FontStyle Style
        {
            get { return _style; }
            set { OnPropertyChanged(ref _style, value); }
        }

        public FontFamily Family
        {
            get { return _family; }
            set { OnPropertyChanged(ref _family, value); }
        }

        public TextWrapping Wrapping
        {
            get { return _wrapping; }
            set
            {
                OnPropertyChanged(ref _wrapping, value);
                IsWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        public bool IsWrapped
        {
            get { return _isWrapped; }
            set { OnPropertyChanged(ref _isWrapped, value); }
        }

        public double Size
        {
            get { return _size; }
            set { OnPropertyChanged(ref _size, value); }
        }
    }
}
