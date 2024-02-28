using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
   
    private readonly testdbContext _dbContext;

    public ProductController(testdbContext dbContext)
    {
     this._dbContext= dbContext;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var product = this._dbContext.Products.ToList();
        return Ok(product);
       
    }

     [HttpGet("GetById/{Id}")]
    public  IActionResult GetById(int Id)
    {
        var product =  this._dbContext.Products.FirstOrDefault(p=>p.Id==Id);
        return Ok(product);
    }
    
    [HttpDelete("delete/{Id}")]
    public IActionResult  Delete(int Id)
    {
        var product = this._dbContext.Products.FirstOrDefault(p=>p.Id==Id);
        if(product!=null){
            this._dbContext.Remove(product);
            this._dbContext.SaveChanges();
            return Ok(true);

        }
        return Ok(false);
    }

    [HttpPost("create")]
    public IActionResult  Create([FromBody] Product _Product)
    {
        var product = this._dbContext.Products.FirstOrDefault(p=>p.Id==_Product.Id);
        if(product!=null){
           product.Name = _Product.Name;
           product.Price = _Product.Price;
           this._dbContext.SaveChanges();

        }else{
            this._dbContext.Products.Add(_Product);
            this._dbContext.SaveChanges();
        }
        return Ok(true);
    }
}
