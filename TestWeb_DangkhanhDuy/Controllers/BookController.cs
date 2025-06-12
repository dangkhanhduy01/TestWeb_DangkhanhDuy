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
                    new Book { TenSach = "C# Cơ bản", TacGia = "Nguyễn Văn A", GiaBia = 50000, SoLuong = 10 },
                    new Book { TenSach = "ASP.NET Core", TacGia = "Lê Thị B", GiaBia = 75000, SoLuong = 8 },
                    new Book { TenSach = "SQL Server", TacGia = "Trần Văn C", GiaBia = 60000, SoLuong = 12 },
                    new Book { TenSach = "HTML CSS", TacGia = "Phạm Thị D", GiaBia = 40000, SoLuong = 15 },
                    new Book { TenSach = "Javascript", TacGia = "Đỗ Văn E", GiaBia = 65000, SoLuong = 5 }
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
