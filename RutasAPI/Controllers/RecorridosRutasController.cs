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
    public class RecorridosRutasController : ControllerBase
    {
        private readonly IRecorridosRutaRepo recorridosRutaRepo;

        public RecorridosRutasController(IRecorridosRutaRepo recorridosRutaRepo)
        {
            this.recorridosRutaRepo = recorridosRutaRepo;
        }

        // GET: api/RecorridoRuta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecorridoRutaDto>>> GetRecorridoRutaDto(int idRuta)
        {
            return (await recorridosRutaRepo.GetAll()).Where(d=> d.IdRuta == idRuta).ToList();
        }

        // PUT: api/RecorridoRuta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecorridoRutaDto(int id, RecorridoRutaDto recorridoRutaDto)
        {
            if (id != recorridoRutaDto.Id)
            {
                return BadRequest();
            }

            await recorridosRutaRepo.Update(recorridoRutaDto);

            return NoContent();
        }

        // POST: api/RecorridoRuta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostRecorridoRutaDto(RecorridoRutaDto recorridoRutaDto)
        {
            return await recorridosRutaRepo.Create(recorridoRutaDto);
        }

        // DELETE: api/RecorridoRuta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecorridoRutaDto(int id)
        {
            RecorridoRutaDto recorridoRutaDto = new RecorridoRutaDto { Id = id };
            await recorridosRutaRepo.Delete(recorridoRutaDto);

            return NoContent();
        }
    }
}
