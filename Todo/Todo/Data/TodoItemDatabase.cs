using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Todo
{
	public class TodoItemDatabase
	{
		readonly SQLiteAsyncConnection database;

		public TodoItemDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<TodoItem>().Wait();
		}

		public Task<List<TodoItem>> GetItemAsync()
		{
			return database.Table<TodoItem>().Where(i=> i.DataInclusao == DateTime.Now.Date).ToListAsync();
		}

		public Task<int> SalvarItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeletarItemAsync(TodoItem item)
		{
			return database.DeleteAsync(item);
		}
	}
}

