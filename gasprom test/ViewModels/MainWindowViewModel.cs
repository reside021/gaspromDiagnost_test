using System.Collections.ObjectModel;
using gasprom_test.Model;
using gasprom_test.Inteface;
using gasprom_test.Service;

namespace gasprom_test.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Obj _selectedObj;
        private RectObj _rect;

        private IFileService _fileService;
        private IDialogService _dialogService;

        public ObservableCollection<Obj> Objects { get; set; }

        public Obj SelectedObj
        {
            get { return  _selectedObj; }
            set
            {
                _selectedObj = value;
                NewRectangle(value);
                OnPropertyChanged("SelectedObj");
            }
        }

        void NewRectangle(Obj obj)
        {
            if (obj == null)
            {
                Rect = new RectObj();
            } 
            else
            {
                Rect = new RectObj
                {
                    Left = GetNum(obj.Distance),
                    Top = GetNum(obj.Angle),
                    Width = GetNum(obj.Width),
                    Height = GetNum(obj.Hegth)
                };
            }

               
        }

        double GetNum(string input)
        {
            if (double.TryParse(input, out double result))
            {
                return result * 10;
            }
            return 0;
        }

        public RectObj Rect
        {
            get { return _rect; }
            set
            {
                _rect = value;
                OnPropertyChanged("Rect");
            }
        }

        private CommandService _openCommand;
        public CommandService OpenCommand
        {
            get
            {
                return _openCommand ??
                  (_openCommand = new CommandService(obj =>
                  {
                      try
                      {
                          if (_dialogService.OpenFileDialog() == true)
                          {
                              _fileService = _dialogService.FileService();
                              var phones = _fileService.Open(_dialogService.FilePath);
                              Objects.Clear();
                              foreach (var p in phones)
                                  Objects.Add(p);
                              _dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private CommandService saveCommand;
        public CommandService SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new CommandService(obj =>
                  {
                      try
                      {
                          if (Objects.Count == 0) return;
                          _fileService.Save(_dialogService.FilePath, Objects.ToList());
                          _dialogService.ShowMessage("Файл сохранен");
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Objects = new ObservableCollection<Obj>();  
        }
    }
}
