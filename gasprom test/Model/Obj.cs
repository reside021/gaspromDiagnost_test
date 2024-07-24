using gasprom_test.ViewModels;

namespace gasprom_test.Model
{
    public class Obj : BaseViewModel
    {
        private string _name;
        private string _distance;
        private string _angle;
        private string _width;
        private string _hegth;
        private string _isDefect;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public string Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
                OnPropertyChanged("Angle");
            }
        }

        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        public string Hegth
        {
            get { return _hegth; }
            set
            {
                _hegth = value;
                OnPropertyChanged("Hegth");
            }
        }

        public string IsDefect
        {
            get { return _isDefect; }
            set
            {
                _isDefect = value;
                OnPropertyChanged("IsDefect");
            }
        }
    }
}
