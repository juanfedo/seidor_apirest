using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seidor_ApiRest.Models;

namespace Seidor_ApiRest.Controllers
{

    /// <summary>
    /// scaffold-dbcontext "Server=DESKTOP-V6B378J\SQLEXPRESS;Database=seidor;Uid=sa;Pwd=patojo;" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models -context SeidorDbContext
    /// </summary>


    [Route("api/[controller]")]
    [ApiController]
    public class VendedorsController : ControllerBase
    {
        private readonly SeidorDbContext _context;

        public VendedorsController(SeidorDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedor()
        {            
            return await _context.Vendedor.ToListAsync();
        }

        // GET: api/Vendedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);            

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        // PUT: api/Vendedors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, Vendedor vendedor)
        {
            if (id != vendedor.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        // POST: api/Vendedors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.Codigo }, vendedor);
        }

        // DELETE: api/Vendedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendedor>> DeleteVendedor(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();

            return vendedor;
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedor.Any(e => e.Codigo == id);
        }
    }
}
