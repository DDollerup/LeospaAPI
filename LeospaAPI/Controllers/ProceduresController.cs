using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeospaAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LeospaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly DBLeospaContext _context;
        private readonly IWebHostEnvironment _env;

        public ProceduresController(DBLeospaContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Procedures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedure>>> GetProcedures()
        {
            return await _context.Procedures.ToListAsync();
        }

        // GET: api/Procedures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedure>> GetProcedure(long id)
        {
            var procedure = await _context.Procedures.FindAsync(id);

            if (procedure == null)
            {
                return NotFound();
            }

            return procedure;
        }

        // PUT: api/Procedures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedure(long id, Procedure procedure)
        {
            if (id != procedure.Id)
            {
                return BadRequest();
            }

            if (procedure.Image != null)
            {
                var base64array = Convert.FromBase64String(procedure.Image);
                var filePath = _env.WebRootPath + $"/procedures/{Guid.NewGuid()}.jpg";
                System.IO.File.WriteAllBytes(filePath, base64array);
                procedure.Image = Path.GetFileName(filePath);
            }

            _context.Entry(procedure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureExists(id))
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

        // POST: api/Procedures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Procedure>> PostProcedure(Procedure procedure)
        {
            if (procedure.Image != null)
            {
                var base64array = Convert.FromBase64String(procedure.Image);
                var filePath = _env.WebRootPath + $"/procedures/{Guid.NewGuid()}.jpg";
                System.IO.File.WriteAllBytes(filePath, base64array);
                procedure.Image = Path.GetFileName(filePath);
            }

            _context.Procedures.Add(procedure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedure", new { id = procedure.Id }, procedure);
        }

        // DELETE: api/Procedures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Procedure>> DeleteProcedure(long id)
        {
            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }

            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();

            return procedure;
        }

        private bool ProcedureExists(long id)
        {
            return _context.Procedures.Any(e => e.Id == id);
        }
    }
}
