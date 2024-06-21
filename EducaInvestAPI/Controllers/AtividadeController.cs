using EducaInvestAPI.Data;
using EducaInvestAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaInvestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;

        public AtividadeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Atividade>>> GetAllAtividades()
        {
            try
            {
                var atividades = await _context.TB_ATIVIDADES.ToListAsync();
                return Ok(atividades);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
            try
            {
                var atividade = await _context.TB_ATIVIDADES.FindAsync(id);
                if (atividade is null)
                    return NotFound("Atividade não encontrada.");

                return Ok(atividade);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<List<Atividade>>> AddAtividade(Atividade atividade)
        {
            try
            {
                _context.TB_ATIVIDADES.Add(atividade);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_ATIVIDADES.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Atividade>>> UpdateCronograma(Atividade updatedAtividade)
        {
            try
            {
                var tbAtividade = await _context.TB_ATIVIDADES.FindAsync(updatedAtividade.Id);
                if (tbAtividade is null)
                    return NotFound("Atividade não encontrada.");

                tbAtividade.DescricaoAtividade = updatedAtividade.DescricaoAtividade;
                tbAtividade.StatusAtividade = updatedAtividade.StatusAtividade;
                tbAtividade.DataInicioAtividade = updatedAtividade.DataInicioAtividade;
                tbAtividade.DataTerminoAtividade = updatedAtividade.DataTerminoAtividade;
                tbAtividade.Percentual = updatedAtividade.Percentual;

                _context.TB_ATIVIDADES.Update(tbAtividade);
                await _context.SaveChangesAsync();

                return Ok("Atividade atualizada.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Atividade>>> DeleteAtividade(int id)
        {
            try
            {
                var tbAtividade = await _context.TB_ATIVIDADES.FindAsync(id);
                if (tbAtividade is null)
                    return NotFound("Atividade não encontrada.");

                _context.TB_ATIVIDADES.Remove(tbAtividade);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_ATIVIDADES.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

    }
}
