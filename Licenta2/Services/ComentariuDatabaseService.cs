using Licenta2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta2.Services
{
    public class ComentariuDatabaseService
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ComentariuDatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Comentariu).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Comentariu)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Comentariu>> GetComentariiAsync()
        {
            return Database.Table<Comentariu>().ToListAsync();
        }

        public Task<List<Comentariu>> GetComentariiForRegiuneMontanaAsync(int regiuneMontanaId)
        {
            // SQL queries are also possible
            return Database.QueryAsync<Comentariu>("SELECT * FROM Comentariu WHERE Comentariu.RegiuneMontanaId = " + regiuneMontanaId);
        }

        public Task<Comentariu> GetComentariuAsync(int id)
        {
            return Database.Table<Comentariu>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveOrUpdateComentariuAsync(Comentariu comentariu)
        {
            if (comentariu.Id != 0)
            {
                return Database.UpdateAsync(comentariu);
            }
            else
            {
                return Database.InsertAsync(comentariu);
            }
        }

        public Task<int> DeleteComentariuAsync(Comentariu comentariu)
        {
            return Database.DeleteAsync(comentariu);
        }

        public Task DeleteComentariiAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Comentariu>("DELETE FROM Comentariu");
        }
    }
}
