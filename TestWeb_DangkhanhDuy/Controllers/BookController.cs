using Microsoft.AspNetCore.Mvc;
using TestWeb_DangkhanhDuy.Models;
using System.Linq;

namespace TestWeb_DangkhanhDuy.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;

            
            if (!_context.Books.Any())
            {
                _context.Books.AddRange(
                    new Book { Title = "C# Cơ bản", Author = "Nguyễn Văn A", Price = 50000, Quantity = 10 },
                    new Book { Title = "ASP.NET Core", Author = "Lê Thị B", Price = 75000, Quantity = 8 },
                    new Book { Title = "SQL Server", Author = "Trần Văn C", Price = 60000, Quantity = 12 },
                    new Book { Title = "HTML CSS", Author = "Phạm Thị D", Price = 40000, Quantity = 15 },
                    new Book { Title = "Javascript", Author = "Đỗ Văn E", Price = 65000, Quantity = 5 }
                );
                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(b);
                _context.SaveChanges();
                TempData["msg"] = "Thêm sách thành công!";
                return RedirectToAction("Index");
            }
            return View(b);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var b = _context.Books.Find(id);
            return b == null ? NotFound() : View(b);
        }

        [HttpPost]
        public IActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(b);
                _context.SaveChanges();
                TempData["msg"] = "Cập nhật sách thành công!";
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public IActionResult Delete(int id)
        {
            var b = _context.Books.Find(id);
            if (b == null) return NotFound();

            _context.Books.Remove(b);
            _context.SaveChanges();
            TempData["msg"] = "Xoá sách thành công!";
            return RedirectToAction("Index");
        }
    }
}
