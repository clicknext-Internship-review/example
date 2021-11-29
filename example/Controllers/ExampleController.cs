using example.DataBase.Context;
using example.DataBase.Models;
using example.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly ExampleDbContext dbContext;
        public ExampleController(ILogger<ExampleController> logger, ExampleDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            var item = dbContext.actors.OrderBy(x => x.first_name).ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int Id)
        {
            var item = dbContext.actors.Where(w => w.actor_id == Id).FirstOrDefault();
            return Ok($"{item.first_name} - {item.last_name}");
        }

        [HttpPost]
        public IActionResult Insert([FromBody] InsertParam param)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var Transaction = dbContext.Database.BeginTransaction())
            {
                dbContext.actors.Add(new actor()
                {
                    first_name = param.first_name,
                    last_name = param.last_name,
                    last_update = DateTime.Now,
                });
                dbContext.SaveChanges();
                Transaction.Commit();
            }
            return Ok($"Update Success");
        }

        [HttpPost]
        public IActionResult Update([FromBody] UpdateParam param)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var Transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var item = dbContext.actors.Where(w => w.actor_id == param.id).SingleOrDefault();
                    item.first_name = param.first_name;
                    item.last_name = param.last_name; ;
                    dbContext.SaveChanges();
                    Transaction.Commit();
                    return Ok($"Update Success");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    Transaction.Rollback();
                    return Ok($"Update Fail");
                }
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] int Id)
        {
            using (var Transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var item = dbContext.actors.Where(w => w.actor_id == Id).SingleOrDefault();
                    if (item.film_actors.Any())
                        return Ok($"Data is referenced");

                    dbContext.actors.Remove(item);
                    dbContext.SaveChanges();
                    Transaction.Commit();
                    return Ok($"Delete Success");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    Transaction.Rollback();
                    return Ok($"Delete Fail");
                }
            }
        }
    }
}