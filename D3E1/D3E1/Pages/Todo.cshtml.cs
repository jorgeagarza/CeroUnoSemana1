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
    public class AddTodoModel : PageModel
    {
        private TodoContext _context { get; set; }
        [BindProperty]
        public Todo Todo { get; set; }

        public AddTodoModel(TodoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Todo = new Todo();
        }

        public void OnGetEdit(int id)
        {
            Todo = _context.Todos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Todo.Id != 0)
            {
                var todo = _context.Todos.Where(x => x.Id == Todo.Id).FirstOrDefault();
                todo.Title = Todo.Title;
                todo.Description = Todo.Description;
                todo.IsCompleted = false;
                todo.CompletedAt = null;
                _context.SaveChanges();
            }
            else
            {
                Todo.CreatedAt = DateTime.Today;
                _context.Todos.Add(Todo);
                _context.SaveChanges();
            }
            return RedirectToPage("index");
        }
    }
}