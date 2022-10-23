using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzaDb _db;

    public PizzaRepository(PizzaDb db) => _db = db;

    public async Task<IEnumerable<Pizza>> GetAllAsync() => await _db.Pizzas.ToListAsync();

    public async Task<Pizza?> GetByIdAsync(int id) => await _db.Pizzas.FindAsync(id);

    public async Task<bool> CreateAsync(Pizza pizza)
    {
        await _db.Pizzas.AddAsync(pizza);
        int result = await _db.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Pizza?> UpdateAsync(int id, Pizza pizza)
    {
        Pizza? oldPizza = await _db.Pizzas.FindAsync(id);

        if (oldPizza is null) return null;

        oldPizza.Name = pizza.Name;
        oldPizza.Description = pizza.Description;

        await _db.SaveChangesAsync();

        return pizza;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        Pizza? pizza = await _db.Pizzas.FindAsync(id);

        if (pizza is null) return false;

        _db.Pizzas.Remove(pizza);

        int result = await _db.SaveChangesAsync();

        return result > 0;
    }
}