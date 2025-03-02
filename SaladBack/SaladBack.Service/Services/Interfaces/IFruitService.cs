using SaladBack.Core;
using System;


namespace SaladBack.Service.Services.Interfaces
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetAll();
        Task<Fruit> Get();
        Task Add(string name);
        Task Update(string name);
        Task Delete(string name);
    }
}
