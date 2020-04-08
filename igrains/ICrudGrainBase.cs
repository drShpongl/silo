using System.Threading.Tasks;

namespace igrains
{
    public interface ICrudGrainBase<T> : Orleans.IGrainWithGuidKey
    {
        Task<T> Get();
        Task<bool> Save(T state);
    }
}