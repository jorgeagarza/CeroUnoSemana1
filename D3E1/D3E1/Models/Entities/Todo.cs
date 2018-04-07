using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D3E1.Models.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Title { get; set; }
        [MinLength(1)]
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
