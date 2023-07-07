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
    public class AutobusesController : ControllerBase
    {
        private readonly IAutobusRepo autobusRepo;

        public AutobusesController(IAutobusRepo autobusRepo)
        {
            this.autobusRepo = autobusRepo;
        }

        // GET: api/Autobuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutobusDto>>> GetAutobusDto()
        {
            return await autobusRepo.GetAll();
        }

        // PUT: api/Autobuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutobusDto(int id, AutobusDto autobusDto)
        {
            if (id != autobusDto.Id)
            {
                return BadRequest();
            }

            await autobusRepo.Update(autobusDto);

            return NoContent();
        }

        // POST: api/Autobuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostAutobusDto(AutobusDto autobusDto)
        {
            return await autobusRepo.Create(autobusDto);
        }

        // DELETE: api/Autobuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutobusDto(int id)
        {
            AutobusDto autobusDto = new AutobusDto { Id = id };
            await autobusRepo.Delete(autobusDto);

            return NoContent();
        }
    }
}
