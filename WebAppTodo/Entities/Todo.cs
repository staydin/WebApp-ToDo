using System.ComponentModel.DataAnnotations;

namespace WebAppTodo.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Category { get; set; }


        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}