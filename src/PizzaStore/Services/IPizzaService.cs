using PizzaStore.Models;

namespace PizzaStore.Services;

public interface IPizzaService
{
    Task<IEnumerable<Pizza>> GetAllAsync();

    Task<Pizza?> GetByIdAsync(int id);

    Task<bool> CreateAsync(Pizza pizza);

    Task<Pizza?> UpdateAsync(int id, Pizza pizza);

    Task<bool> DeleteByIdAsync(int id);
}