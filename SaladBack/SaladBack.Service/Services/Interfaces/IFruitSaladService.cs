using SaladBack.Core;
using SaladBack.Core.Models;


namespace SaladBack.Service.Services.Interfaces
{
    public interface IFruitSaladService
    {
        Task<List<FruitSalad>> GetAll();
        Task<FruitSalad> Get(int id);
    }
}
