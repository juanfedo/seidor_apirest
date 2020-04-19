﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seidor_ApiRest.Models;

namespace Seidor_ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadsController : ControllerBase
    {
        private readonly SeidorDbContext _context;

        public CiudadsController(SeidorDbContext context)
        {
            _context = context;
        }

        // GET: api/Ciudads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudad()
        {
            return await _context.Ciudad.ToListAsync();
        }

        // GET: api/Ciudads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudad>> GetCiudad(int id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return ciudad;
        }

        // PUT: api/Ciudads/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudad(int id, Ciudad ciudad)
        {
            if (id != ciudad.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(ciudad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(id))
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

        // POST: api/Ciudads
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ciudad>> PostCiudad(Ciudad ciudad)
        {
            _context.Ciudad.Add(ciudad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCiudad", new { id = ciudad.Codigo }, ciudad);
        }

        // DELETE: api/Ciudads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ciudad>> DeleteCiudad(int id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();

            return ciudad;
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudad.Any(e => e.Codigo == id);
        }
    }
}
