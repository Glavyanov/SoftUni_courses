namespace FastFood.Core.ViewModels.Orders
{
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateItemViewModel> Items { get; set; }

        public List<RegisterEmployeeViewModel> Employees { get; set; }
    }
}
