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
    public class AutobusRutasController : ControllerBase
    {
        private readonly IAutobusRutaRepo autobusRutaRepo;

        public AutobusRutasController(IAutobusRutaRepo autobusRutaRepo)
        {
            this.autobusRutaRepo = autobusRutaRepo;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutobusRutaDto>>> GetAutobusRutaDto()
        {
            return await autobusRutaRepo.GetAll();
        }

        // PUT: api/Rutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutobusRutaDto(int id, AutobusRutaDto autobusRutaDto)
        {
            if (id != autobusRutaDto.Id)
            {
                return BadRequest();
            }

            await autobusRutaRepo.Update(autobusRutaDto);

            return NoContent();
        }

        // POST: api/Rutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostAutobusRutaDto(AutobusRutaDto autobusRutaDto)
        {
            return await autobusRutaRepo.Create(autobusRutaDto);
        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutobusRutaDto(int id)
        {
            AutobusRutaDto autobusRutaDto = new AutobusRutaDto { Id = id };
            await autobusRutaRepo.Delete(autobusRutaDto);

            return NoContent();
        }
    }
}
