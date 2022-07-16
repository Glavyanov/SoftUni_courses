using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Customer { get; set; }

        public int ItemId { get; set; }

        public int EmployeeId { get; set; }

        public string OrderType { get; set; }
        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}
