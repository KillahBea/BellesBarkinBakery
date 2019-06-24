using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bellesbarkinbakery.model;

namespace bellesbarkinbakery.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    // GET api/items
    [HttpGet]

    public ActionResult<List<InventoryItem>> Get()
    {
      var db = new DatabaseContext();
      var rv = db.Items;
      return rv.ToList();
    }
    [HttpGet("{Name}")]
    public ActionResult<InventoryItem> GetItem(string Name)
    {
      var db = new DatabaseContext();
      var rv = db.Items.FirstOrDefault(f => f.Name == Name);
      return rv;
    }

    [HttpPost]
    public ActionResult<InventoryItem> AddItem([FromBody] InventoryItem Items)
    {
      var db = new DatabaseContext();
      db.Items.Add(Items);
      db.SaveChanges();
      return Items;
    }


    [HttpPut]
    public ActionResult<InventoryItem> UpdateItem(int Id, [FromBody] InventoryItem Items)
    {
      var db = new DatabaseContext();
      var rv = db.Items.FirstOrDefault(f => f.Id == Id);
      rv.SKU = Items.SKU;
      rv.Name = Items.Name;
      rv.ShortDescription = Items.ShortDescription;
      rv.NumberInStock = Items.NumberInStock;
      rv.Price = Items.Price;
      rv.DateOrdered = Items.DateOrdered;
      db.SaveChanges();
      return Items;
    }
    [HttpDelete]
    public ActionResult<InventoryItem> DeleteItem(int Id)
    {
      var db = new DatabaseContext();
      var product = db.Items.FirstOrDefault(f => f.Id == Id);
      if (product == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(product);
        db.SaveChanges();
        return Ok();
      }

    }
    [HttpGet("{Id}")]
    public ActionResult<List<InventoryItem>> StockCount(int Id, [FromBody] InventoryItem Items)
    {
      var db = new DatabaseContext();
      var rv = db.Items.Where(w => w.NumberInStock == 0);
      return rv.ToList();
    }
    [HttpGet("{SKU}")]
    public ActionResult<InventoryItem> GetSKU(int SKU)
    {
      var db = new DatabaseContext();
      var rv = db.Items.FirstOrDefault(f => f.SKU == SKU);
      return rv;
    }
  }
}