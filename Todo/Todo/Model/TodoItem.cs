using SQLite;

namespace Todo
{
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Tarefa { get; set; }
		public string Descricao { get; set; }
		public bool Finalizada { get; set; }
	}
}

