using gasprom_test.ViewModels;

namespace gasprom_test.Model
{
    public class RectObj : BaseViewModel
    {
        private double _left;
        private double _top;
        private double _width;
        private double _height;

        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged("Left");
            }
        }
        public double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                OnPropertyChanged("Top");
            }
        }
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public RectObj()
        {
            _left = 0;
            _top = 0;
            _width = 0;
            _height = 0;
        }
    }
}
