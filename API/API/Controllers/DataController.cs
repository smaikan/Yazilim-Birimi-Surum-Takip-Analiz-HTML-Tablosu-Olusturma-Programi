using System;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController:ControllerBase
    {
        private readonly DataContext _context;
        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.source.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var veri = _context.source.Find(id);
            return veri == null ? NotFound() : Ok(veri);
        }
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var count = _context.source.Count();
            return Ok(count);
        }

        [HttpPost]
        public IActionResult Create(source sources)
        {
            _context.source.Add(sources);
            _context.SaveChanges();
            return Ok(sources);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] source updated)
        {
            var veri = _context.source.Find(id);
            if (veri == null) return NotFound();

            veri.teams = updated.teams;
            veri.version = updated.version;
            veri.updateTime = updated.updateTime;
            veri.type = updated.type;
            veri.description = updated.description;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var veri = _context.source.Find(id);
            if (veri == null) return NotFound();

            _context.source.Remove(veri);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("clear")]
        public IActionResult ClearAll()
        {
            _context.source.RemoveRange(_context.source); 
            _context.SaveChanges();
            return NoContent();
        }

    }
}
