using System;
namespace bellesbarkinbakery.model
{
  public class InventoryItem
  {
    public int Id { get; set; }
    public int SKU { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public int NumberInStock { get; set; }
    public float Price { get; set; }
    public DateTime DateOrdered { get; set; }
  }
}