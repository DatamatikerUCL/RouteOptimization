using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using RelateITWorking.ExtensionClasses;
using RelateITWorking.Models;
using SQLite;

namespace RelateITWorking
{
    public class DatabaseAccess
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {

            return new SQLiteAsyncConnection(DatabaseConn.DatabasePath, DatabaseConn.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseAccess()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(DatabaseAccess).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(DatabaseAccess)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public Task<List<User>> GetItemsAsync()
        {
            return Database.Table<User>().ToListAsync();
        }

        public Task<List<User>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<User>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<User> GetItemAsync(int id)
        {
            return Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(User item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(User item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
