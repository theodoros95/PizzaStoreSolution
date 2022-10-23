using Microsoft.AspNetCore.Mvc;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore.Controllers;

[ApiController]
[Route("pizza")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService) => _pizzaService = pizzaService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Pizza> pizzas = await _pizzaService.GetAllAsync();

        return Ok(pizzas);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        Pizza? pizza = await _pizzaService.GetByIdAsync(id);

        return pizza is null ? NotFound() : Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        bool created = await _pizzaService.CreateAsync(pizza);

        if (!created) return BadRequest();

        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        Pizza? updatedPizza = await _pizzaService.UpdateAsync(id, pizza);

        return updatedPizza is null ? NotFound() : NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        bool deleted = await _pizzaService.DeleteByIdAsync(id);

        if (!deleted) return NotFound();

        return Ok();
    }
}