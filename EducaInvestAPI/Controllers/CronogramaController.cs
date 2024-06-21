using EducaInvestAPI.Data;
using EducaInvestAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaInvestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CronogramaController : ControllerBase
    {
        private readonly DataContext _context;

        public CronogramaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cronograma>>> GetAllCronogramas()
        {
            try
            {
                var cronogramas = await _context.TB_CRONOGRAMAS.ToListAsync();
                return Ok(cronogramas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cronograma>> GetCronograma(int id)
        {
            try
            {
                var cronograma = await _context.TB_CRONOGRAMAS.FindAsync(id);
                if (cronograma is null)
                    return NotFound("Cronograma não encontrado.");

                return Ok(cronograma);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Cronograma>>> AddCronograma(Cronograma cronograma)
        {
            try
            {
                _context.TB_CRONOGRAMAS.Add(cronograma);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_CRONOGRAMAS.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cronograma>>> DeleteCronograma(int id)
        {
            try
            {
                var tbCronograma = await _context.TB_CRONOGRAMAS.FindAsync(id);
                if (tbCronograma is null)
                    return NotFound("Cronograma não encontrado.");

                _context.TB_CRONOGRAMAS.Remove(tbCronograma);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_CRONOGRAMAS.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }


    }
}
