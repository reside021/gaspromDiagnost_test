
namespace gasprom_test.Inteface
{
    public interface IDialogService
    {
        void ShowMessage(string message);   
        string FilePath { get; set; }   
        bool OpenFileDialog();

        IFileService FileService();
    }
}
