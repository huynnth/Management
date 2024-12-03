using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DebtManagementApp.Data;
using DebtManagementApp.Models;

namespace DebtManagementApp.Controllers
{
    public class DebtsController : Controller
    {
        private readonly DebtDbContext _context;

        public DebtsController(DebtDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string customerName)
        {
            // Lấy danh sách công nợ của khách hàng
            var debts = _context.Debts
                .Where(d => d.CustomerName == customerName) // Lọc công nợ theo CustomerName
                .ToList();

            // Truyền dữ liệu qua ViewBag
            ViewBag.CustomerName = customerName;
            return View(debts);
        }



        public IActionResult Create(string customerName)
        {
            // Truyền danh sách khách hàng vào View
            ViewBag.CustomerName = customerName;
            return View();
        }



        [HttpPost]
        public IActionResult Create(Debt debt)
        {
            if (ModelState.IsValid)
            { 
                _context.Debts.Add(debt);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { customerName = debt.CustomerName });
            }

            return View(debt);
        }



        [HttpGet("Debts/MarkAsPaid/{customerName}")]
        public async Task<IActionResult> MarkAsPaid(string customerName)
        {
            // Giải mã URL để đảm bảo xử lý được các ký tự đặc biệt
            var decodedCustomerName = Uri.UnescapeDataString(customerName);

            // Tìm khoản nợ của khách hàng
            var debt = await _context.Debts.FirstOrDefaultAsync(d => d.CustomerName == decodedCustomerName);

            if (debt == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy
            }

            // Đánh dấu là đã thanh toán
            debt.IsPaid = true;

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Chuyển hướng lại trang danh sách công nợ
            return RedirectToAction(nameof(Index), new { customerName = debt.CustomerName });
        }


    public IActionResult Edit(int id)
        {
            var debt = _context.Debts.Find(id);
            if (debt == null) return NotFound();

            return View(debt);
        }

        [HttpPost]
        public IActionResult Edit(Debt debt)
        {
            if (ModelState.IsValid)
            {
                _context.Debts.Update(debt);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { customerId = debt.CustomerName });
            }
            return View(debt);
        }

    }
}
