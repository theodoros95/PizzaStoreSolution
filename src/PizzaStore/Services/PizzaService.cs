using PizzaStore.Models;
using PizzaStore.Repositories;

namespace PizzaStore.Services;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;
    private readonly ILogger<PizzaService> _logger;

    public PizzaService(IPizzaRepository pizzaRepository, ILogger<PizzaService> logger)
    {
        _pizzaRepository = pizzaRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Pizza>> GetAllAsync() => await _pizzaRepository.GetAllAsync();

    public async Task<Pizza?> GetByIdAsync(int id) => await _pizzaRepository.GetByIdAsync(id);

    public async Task<bool> CreateAsync(Pizza pizza) => await _pizzaRepository.CreateAsync(pizza);

    public async Task<Pizza?> UpdateAsync(int id, Pizza pizza)
    {
        _logger.LogInformation("A pizza has been updated");

        return await _pizzaRepository.UpdateAsync(id, pizza);
    }

    public async Task<bool> DeleteByIdAsync(int id) => await _pizzaRepository.DeleteByIdAsync(id);
}