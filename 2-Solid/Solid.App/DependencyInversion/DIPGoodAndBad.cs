
namespace Solid.App.DependencyInversion.GoodAndBad
{
    public class ProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }
    public class ProductRepositoryFromSqlServer : IRepository
    {
        public List<string> GetAll()
        {
            return new() { "SqlServer Kalem1", "SqlServer Kalem2" };
        }
    }
    public class ProductRepositoryFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new() { "Oracle Kalem1", "Oracle Kalem2" };
        }
    }
    public interface IRepository
    {
        List<string> GetAll();
    }
}
