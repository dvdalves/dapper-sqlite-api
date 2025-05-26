using CRUD_DapperSqlite.Data;
using CRUD_DapperSqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DapperSqlite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(Context context) : ControllerBase
{

    /// <summary>
    /// Retrieve all products.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        try
        {
            var products = await context.GetProductsAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving products: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieve a specific product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        try
        {
            var product = await context.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving product: {ex.Message}");
        }
    }

    /// <summary>
    /// Create a new product.
    /// </summary>
    /// <param name="product">The product to create.</param>
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        try
        {
            var newProduct = await context.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error creating product: {ex.Message}");
        }
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="product">The updated product data.</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        try
        {
            if (id != product.Id)
            {
                return BadRequest("Provided product ID does not match the ID of the product to be updated.");
            }

            await context.UpdateProductAsync(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error updating product: {ex.Message}");
        }
    }

    /// <summary>
    /// Delete a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var product = await context.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            await context.DeleteProductAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting product: {ex.Message}");
        }
    }
}
