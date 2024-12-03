using System.ComponentModel.DataAnnotations;

namespace DebtManagementApp.Models
{
    public class Debt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Khách hàng là bắt buộc.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Số tiền là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Hạn thanh toán là bắt buộc.")]
        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }
    }

}
