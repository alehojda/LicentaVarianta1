using Licenta2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta2.Services
{
    public class UtilizatorDatabaseService
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UtilizatorDatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Utilizator).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Utilizator)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Utilizator>> GetUtilizatoriAsync()
        {
            return Database.Table<Utilizator>().ToListAsync();
        }

        /*public Task<List<Utilizator>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Utilizator>("SELECT * FROM [Item] WHERE [Done] = 0");
        }
        */

        public Task<Utilizator> GetUtilizatorAsync(int id)
        {
            return Database.Table<Utilizator>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveOrUpdateUtilizatorAsync(Utilizator Utilizator)
        {
            if (Utilizator.Id != 0)
            {
                return Database.UpdateAsync(Utilizator);
            }
            else
            {
                return Database.InsertAsync(Utilizator);
            }
        }

        public Task<int> DeleteUtilizatorAsync(Utilizator Utilizator)
        {
            return Database.DeleteAsync(Utilizator);
        }

        public Task DeleteUtilizatoriAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Utilizator>("DELETE FROM Utilizator");
        }

        public Task<Utilizator> GetUtilizatorByEmail(string Email)
        {
            return Database.Table<Utilizator>().Where(i => i.Email == Email).FirstOrDefaultAsync();
        }
    }
}
