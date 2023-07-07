using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasAPI.Data;
using Rutas.Domain;
using RutasAPI.Repositories.Interfaces;

namespace RutasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly IConductoresRepo conductoresRepo;

        public ConductoresController(IConductoresRepo conductoresRepo)
        {
            this.conductoresRepo = conductoresRepo;
        }

        // GET: api/Conductores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDto>>> GetConductorDto()
        {
            return await conductoresRepo.GetAll();
        }

        // PUT: api/Conductores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConductorDto(int id, ConductorDto conductorDto)
        {
            if (id != conductorDto.Id)
            {
                return BadRequest();
            }

            await conductoresRepo.Update(conductorDto);

            return NoContent();
        }

        // POST: api/Conductores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostConductorDto(ConductorDto ConductorDto)
        {
            return await conductoresRepo.Create(ConductorDto);
        }

        // DELETE: api/Conductores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConductorDto(int id)
        {
            ConductorDto ConductorDto = new ConductorDto { Id = id };
            await conductoresRepo.Delete(ConductorDto);

            return NoContent();
        }
    }
}
