using Seminar3._3.Models;

namespace Seminar3._3.Abstractions
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetStorages();
        int AddStorage(StorageDto storage);
    }
}
