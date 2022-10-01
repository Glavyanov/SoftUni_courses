using ASPIntro.Models;

namespace ASPIntro.Contracts
{
    public interface ITestService
    {
        string GetProduct(TestModel model);

        int GetId(TestModel model);
    }
}
