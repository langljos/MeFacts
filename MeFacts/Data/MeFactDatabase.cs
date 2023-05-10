using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace MeFacts.Data
{
    public class MeFactDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MeFactDatabase()
        {
            object p = InitializeAsync();
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(MeFactData).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(MeFactData)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<MeFactData>> GetItemsAsync()
        {
            return Database.Table<MeFactData>().ToListAsync();
        }

        public Task<MeFactData> GetItemAsync(int id)
        {
            return Database.Table<MeFactData>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MeFactData item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<MeFactData> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(MeFactData item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<MeFactData>();
        }
    }
}
