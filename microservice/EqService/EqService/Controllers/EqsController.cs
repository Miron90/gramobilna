using EqService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EqService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EqsController : ControllerBase
    {
        private readonly UpgradesContext _context;

        public EqsController(UpgradesContext context)
        {
            _context = context;
        }
        // GET: api/<EqsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eq>>> GetUpgrades()
        {
            return await _context.Eqs.ToListAsync();
        }

        // POST api/<EqsController>
        [HttpPost]
        public void Post([FromBody] Eq body)
        {
            _context.Eqs.Add(body);
            _context.SaveChanges();
        }

        // PUT api/<EqsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Eq body)
        {
            Eq eq = _context.Eqs.Single(p => p.Id == body.Id);
            eq.Hpmulti = body.Hpmulti;
            eq.Lvl = body.Lvl;
            eq.Attmulti = body.Attmulti;
            _context.Eqs.Update(body);
            _context.SaveChanges();
        }

        // DELETE api/<EqsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Eqs.Remove(_context.Eqs.Single(p=>p.Id==id));
            _context.SaveChanges();
        }
    }
}
