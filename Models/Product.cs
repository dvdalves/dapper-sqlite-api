﻿namespace CRUD_DapperSqlite.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public required string Description { get; set; }
}
