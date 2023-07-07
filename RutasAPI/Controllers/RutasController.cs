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
    public class RutasController : ControllerBase
    {
        private readonly IRutasRepo rutasRepo;

        public RutasController(IRutasRepo rutasRepo)
        {
            this.rutasRepo = rutasRepo;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaDto>>> GetRutaDto()
        {
            return await rutasRepo.GetAll();
        }

        // PUT: api/Rutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutaDto(int id, RutaDto rutaDto)
        {
            if (id != rutaDto.Id)
            {
                return BadRequest();
            }

            await rutasRepo.Update(rutaDto);

            return NoContent();
        }

        // POST: api/Rutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostRutaDto(RutaDto rutaDto)
        {
            return await rutasRepo.Create(rutaDto);
        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutaDto(int id)
        {
            RutaDto rutaDto = new RutaDto { Id = id };
            await rutasRepo.Delete(rutaDto);

            return NoContent();
        }
    }
}
