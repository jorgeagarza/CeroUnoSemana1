using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D3E1.Models;
using D3E1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace D3E1.Pages
{
    public class IndexModel : PageModel
    {
        private TodoContext _context { get; set; }
        private List<Todo> todos;
        public List<Todo> Todos
        {
            get
            {
                if (todos == null)
                {
                    todos = new List<Todo>();
                    todos.AddRange(_context.Todos.ToList());
                }
                return todos;
            }
        }

        public IndexModel(TodoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetDelete(int id)
        {
            var todo = _context.Todos.Where(x => x.Id == id).FirstOrDefault();
            if(todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return Page();
        }

        public IActionResult OnGetComplete(int id)
        {
            var todo = _context.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (todo != null)
            {
                todo.IsCompleted = true;
                todo.CompletedAt = DateTime.Today;
                _context.SaveChanges();
            }
            return Page();
        }
    }
}
