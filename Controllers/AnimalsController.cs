using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CreataceousPark.Models;
using CreataceousPark.Helpers;

namespace CreataceousPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly CreataceousParkContext _db;

    public AnimalsController(CreataceousParkContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get()
    {
      return await _db.Animals.ToListAsync();
    }

    // POST api/animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      
      await _db.SaveChangesAsync();

      // make a call to the NYT top stories
      var apiCallTask = ApiHelper.NytApiCall("a8N9RYvKvHtG8rQCQlv2jCJCqNvEbptD");
      var result = apiCallTask.Result;
      
      // deserialize JSON result
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      
      // convert from a JObject to a list of headline objects
      List<Headline> headlineList = JsonConvert.DeserializeObject<List<Headline>>(jsonResponse["results"].ToString());

      foreach (Headline headline in headlineList)
      {
        Headline newHeadline = new Headline(headline.Title, headline.Summary);
        _db.Headlines.Add(newHeadline);
      }

      await _db.SaveChangesAsync();

      // save that response to the database

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
          return NotFound();
      }

      return animal;
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
