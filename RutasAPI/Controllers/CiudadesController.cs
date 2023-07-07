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
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesRepo ciudadesRepo;

        public CiudadesController(ICiudadesRepo ciudadesRepo)
        {
            this.ciudadesRepo = ciudadesRepo;
        }

        // GET: api/Ciudades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> GetCiudadDto()
        {
            return await ciudadesRepo.GetAll();
        }

        // PUT: api/Ciudades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudadDto(int id, CiudadDto ciudadDto)
        {
            if (id != ciudadDto.Id)
            {
                return BadRequest();
            }

            await ciudadesRepo.Update(ciudadDto);

            return NoContent();
        }

        // POST: api/Ciudades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostCiudadDto(CiudadDto ciudadDto)
        {
            return await ciudadesRepo.Create(ciudadDto);
        }

        // DELETE: api/Ciudades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudadDto(int id)
        {
            CiudadDto ciudadDto = new CiudadDto { Id = id };
            await ciudadesRepo.Delete(ciudadDto);

            return NoContent();
        }
    }
}
