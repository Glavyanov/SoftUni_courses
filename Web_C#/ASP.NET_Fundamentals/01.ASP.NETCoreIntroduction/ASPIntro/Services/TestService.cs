using ASPIntro.Contracts;
using ASPIntro.Models;

namespace ASPIntro.Services
{
    public class TestService : ITestService
    {
        public string GetProduct(TestModel model) => model.Product;

        public int GetId(TestModel model) => model?.Id ?? 0;
    }
}
