using MFramework.Services.FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebAppTodo.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DatabaseContext()
        {
            //PM install-package mframewordk.service.FakeData

            if (Database.EnsureCreated())
            {
                string[] categories = new string[] { "work", "business", "edication", "shopping", "personal", "code" };
                for (int i = 0; i < 100; i++)
                {
                    Todo todo = new Todo()
                    {
                        Category = CollectionData.GetElement(categories),
                            Completed = BooleanData.GetBoolean(),
                            CreatedAt = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            Title = TextData.GetSentence()
                    };
                    Todos.Add(todo);
                }
                SaveChanges();
            }
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer
                     ("Server=.;Database=WebAppTodo;Trusted_Connection=true;");
            }
        }
    }

}