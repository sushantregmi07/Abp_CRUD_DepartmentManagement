using System.Threading.Tasks;

namespace Susant.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
