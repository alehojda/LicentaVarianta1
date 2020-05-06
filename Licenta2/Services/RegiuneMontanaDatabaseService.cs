using Licenta2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta2.Services
{
        public class RegiuneMontanaDatabaseService
        {

            static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
            {
                return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            });

            static SQLiteAsyncConnection Database => lazyInitializer.Value;
            static bool initialized = false;

            public RegiuneMontanaDatabaseService()
            {
                InitializeAsync().SafeFireAndForget(false);
            }

            async Task InitializeAsync()
            {
                if (!initialized)
                {
                    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RegiuneMontana).Name))
                    {
                        await Database.CreateTablesAsync(CreateFlags.None, typeof(RegiuneMontana)).ConfigureAwait(false);
                        initialized = true;
                    }
                }
            }

            public Task<List<RegiuneMontana>> GetRegiuniMontaneAsync()
            {
                return Database.Table<RegiuneMontana>().ToListAsync();
            }

            /*public Task<List<RegiuneMontana>> GetItemsNotDoneAsync()
            {
                // SQL queries are also possible
                return Database.QueryAsync<RegiuneMontana>("SELECT * FROM [Item] WHERE [Done] = 0");
            }
            */

            public Task<RegiuneMontana> GetRegiuneMontanaAsync(int id)
            {
                return Database.Table<RegiuneMontana>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }

            public Task<int> SaveOrUpdateRegiuneMontanaAsync(RegiuneMontana regiuneMontana)
            {
                if (regiuneMontana.Id != 0)
                {
                    return Database.UpdateAsync(regiuneMontana);
                }
                else
                {
                    return Database.InsertAsync(regiuneMontana);
                }
            }

            public Task<int> DeleteRegiuneMontanaAsync(RegiuneMontana regiuneMontana)
            {
                return Database.DeleteAsync(regiuneMontana);
            }

        public Task DeleteRegiuniMontaneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Comentariu>("DELETE FROM RegiuneMontana");
        }
    }

    
}
