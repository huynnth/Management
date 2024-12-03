using DebtManagementApp.Data;
using DebtManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DebtManagementApp.Controllers
{
    public class CustomersController : Controller

    {
        private readonly DebtDbContext _context;

        public CustomersController(DebtDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();

            return View(customer);
        }
        public IActionResult Delete(string Name)
        {
            var customer = _context.Customers.Find(Name);
            if (customer == null) return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        // Controller Action để xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Name)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == Name);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer); // Xóa đối tượng
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu

            // Chuyển hướng về trang Index của Customer
            return RedirectToAction("Index", new { customerName = customer.Name });

        }


    }
}
