using gasprom_test.Model;

namespace gasprom_test.Inteface
{
    public interface IFileService
    {
        List<Obj> Open(string path);
        void Save(string path, List<Obj> objects);

    }
}
