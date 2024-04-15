using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P007_SuperShopWEB.MVC5.Data.Entities;


namespace P007_SuperShopWEB.MVC5.Data
{
    public class Repository : IRepository
    {
        // Video ASP.NET_MVC_07
        // 02m20s Design Pattern (Normal) 
        // esta classe é que vai aceder ao dataContext
        private readonly DataContext _context;

        // 1 este será o meu construtor
        public Repository(DataContext context)
        {
            _context = context;
        }

        // 2 algo que nos dê todos os produtos - isto é o meu método  - só em memória
        public IEnumerable<Product> GetProducts()
        {
            // 04m25s Dá-me todos os produtos ordenados por nome
            return _context.Products.OrderBy(p => p.Name);
        }

        // 3 algo que nos dê só um dos produtos - isto é o meu método - só em memória
        public Product GetProduct(int id)
        {
            // 05m20s Dá-me só o artigo do id  - só em memória
            return _context.Products.Find(id);
        }

        // 4 adicionar do CRUD - isto é o meu método
        public void AddProduct(Product product)
        {
            // 6m00s Faz o Add do product que entrou como parametro - só em memória
            _context.Products.Add(product);
        }

        // 5 adicionar do CRUD - isto é o meu método update
        public void UpdateProduct(Product product)
        {
            // 7m00s Faz o Update do product que entrou como parametro - só em memória
            _context.Products.Update(product);
        }

        // 6 adicionar do CRUD - isto é o meu método update
        public void RemoveProduct(Product product)
        {
            // 8m00s Faz o Remove do product que entrou como parametro - só em memória
            _context.Products.Remove(product);
        }

        // 7 adicionar do CRUD - para gravar tudo na Base de Dados- isto é o meu método update
        // QUESTAO: porque gravo tudo, não tenho problemas de performance???
        public async Task<bool> SaveAllAsync()
        {
            // 12m só passo ao registo seguinte se gravar pelo menos 1 registo e retorna condição bool = true
            return await _context.SaveChangesAsync() > 0;
        }

        // 8 adicionar do CRUD - só la vai ver se o produto existe, e devlve a condição bool
        public bool ProductExists(int id)
        {
            // 12m37s existe algum produto com este ID??
            return _context.Products.Any(p => p.Id == id);
        }

    }
}
