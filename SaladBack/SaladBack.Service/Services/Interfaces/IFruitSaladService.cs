using SaladBack.Core;
using SaladBack.Core.Models;


namespace SaladBack.Service.Services.Interfaces
{
    public interface IFruitSaladService
    {
        Task<List<FruitSalad>> GetAll();
        Task<FruitSalad> Get(int id);
        Task Create(int fruitId, FruitSalad fruitSalad);
        Task Update(int id, FruitSalad fruitSalad);
        Task Delete(int id);
    }
}
