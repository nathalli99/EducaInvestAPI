using EducaInvestAPI.Data;
using EducaInvestAPI.Entities;
using EducaInvestAPI.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaInvestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjetoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // Método apenas para consulta geral de projetos
        public async Task<ActionResult<List<Projeto>>> GetAllProjetos()
        {
            try
            {
                var projetos = await _context.TB_PROJETOS.ToListAsync();
                return Ok(projetos);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar acessar os projetos.Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]  // Metodo para acessar um projeto específico
        public async Task<ActionResult<Projeto>> GetProjeto(int id)
        {
            try
            {
                var projeto = await _context.TB_PROJETOS.FindAsync(id);
                if (projeto == null)
                    return NotFound("Projeto não encontrado.");

                return Ok(projeto);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar recuperar os detalhes do projeto.Por favor, tente novamente mais tarde.");
            }
        }


        [HttpGet("GetByPerfil/{usuarioId}")] // Método para visualização de projetos de acordo com o perfil do usuário || Administrador/Investidor = todos os projetos || Estudante = somente os dele
        public async Task<IActionResult> GetByPerfilAsync(int usuarioId)
        {
            try
            {
                var usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Id == usuarioId);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                List<Projeto> lista;

                if (usuario.Perfil == PerfilUsuarioEnum.Administrador || usuario.Perfil == PerfilUsuarioEnum.Investidor)
                {
                    lista = await _context.TB_PROJETOS.ToListAsync();
                }
                else
                {
                    lista = await _context.TB_PROJETOS
                        .Where(p => p.UsuarioId == usuarioId)
                        .ToListAsync();
                }

                return Ok(lista);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar recuperar os projetos. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("GetProjetosByUsuario/{usuarioId}")] // Método para o usuário estudante/administrador poder visualizar os próprios projetos
        public async Task<ActionResult<List<Projeto>>> GetProjetosByUsuarioId(int usuarioId)
        {
            var projetos = await _context.TB_PROJETOS
                                         .Where(p => p.UsuarioId == usuarioId)
                                         .ToListAsync();

            if (projetos == null || projetos.Count == 0)
            {
                return NotFound("Nenhum projeto encontrado para esta conta.");
            }

            return Ok(projetos);
        }

        [HttpPost("addProjeto")] // Método para estudante e administrador publicar projetos
        public async Task<ActionResult<List<Projeto>>> AddProjeto(Projeto projeto)
        {
            try
            {
                var usuario = await _context.TB_USUARIOS.FindAsync(projeto.UsuarioId);
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                if (usuario.Perfil != PerfilUsuarioEnum.Estudante && usuario.Perfil != PerfilUsuarioEnum.Administrador)
                {
                    return Forbid("Acesso não autorizado.");
                }

                _context.TB_PROJETOS.Add(projeto);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_PROJETOS.ToListAsync());
            }
            catch (Exception)
            {
                return BadRequest("Houve um problema ao adicionar o projeto. Por favor, verifique os dados e tente novamente.");
            }
        }

        [HttpPost("uploadFotoProjeto")] // publicação de foto do projeto, necessário ter publicado os dados do projeto antes
        public async Task<ActionResult> UploadFotoProjeto([FromForm] ICollection<IFormFile> fotoProjeto, int id)
        {
            if (fotoProjeto == null || fotoProjeto.Count == 0)
                return BadRequest();

            var fileProjeto = await _context.TB_PROJETOS.FindAsync(id);
            if (fileProjeto == null)
                return NotFound("Projeto não encontrado.");

            List<byte[]> data = new List<byte[]>();

            foreach (var formFile in fotoProjeto)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(stream);

                        data.Add(stream.ToArray());
                    }
                }
            }

            fileProjeto.FileBytes = data;

            _context.TB_PROJETOS.Update(fileProjeto);
            await _context.SaveChangesAsync();

            return Ok("Foto adicionada com sucesso.");

        }

        [HttpPost("{projetoId}/addColaborador/{usuarioId}")]
        public async Task<ActionResult> AddColaborador(int projetoId, int usuarioId)
        {
            try
            {
                var projeto = await _context.TB_PROJETOS
                    .Include(p => p.Colaboradores)
                    .FirstOrDefaultAsync(p => p.Id == projetoId);

                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado.");
                }

                var usuario = await _context.TB_USUARIOS.FindAsync(usuarioId);
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                if (projeto.Colaboradores.Any(u => u.Id == usuario.Id))
                {
                    return BadRequest("Este usuário já é um colaborador deste projeto.");
                }

                projeto.Colaboradores.Add(usuario);
                await _context.SaveChangesAsync();

                return Ok("Colaborador adicionado com sucesso.");
            }
            catch (Exception)
            {
                return BadRequest("Houve um erro ao tentar adicionar o colaborador.");
            }
        }



        [HttpPut] // Método para atualizar os dados do projeto
        public async Task<ActionResult<List<Projeto>>> UpdateProjeto(Projeto updatedProjeto)
        {
            try
            {
                var tbProjeto = await _context.TB_PROJETOS.FindAsync(updatedProjeto.Id);
                if (tbProjeto == null)
                    return NotFound("Projeto não encontrado.");

                tbProjeto.NomeProjeto = updatedProjeto.NomeProjeto;
                tbProjeto.Subtitulo = updatedProjeto.Subtitulo;
                tbProjeto.DescricaoProjeto = updatedProjeto.DescricaoProjeto;
                tbProjeto.CustoProjeto = updatedProjeto.CustoProjeto;
                tbProjeto.StatusProjeto = updatedProjeto.StatusProjeto;

                _context.TB_PROJETOS.Update(tbProjeto);
                await _context.SaveChangesAsync();

                return Ok(tbProjeto);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar atualizar o projeto. Por favor, tente novamente.");
            }
        }

        [HttpPut("marcarInvestido/{id}")] // Método para marcar um projeto como investido
        public async Task<ActionResult<Projeto>> MarcarInvestido(int id, [FromQuery] bool investido)
        {
            try
            {
                var projeto = await _context.TB_PROJETOS.FindAsync(id);
                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado.");
                }

                projeto.Investido = investido;

                _context.TB_PROJETOS.Update(projeto);
                await _context.SaveChangesAsync();

                return Ok(projeto);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar atualizar o projeto. Por favor, tente novamente.");
            }
        }

        [HttpDelete("{id}")] // Método para excluir um projeto
        public async Task<ActionResult<List<Projeto>>> DeleteProjeto(int id)
        {
            try
            {
                var tbProjeto = await _context.TB_PROJETOS.FindAsync(id);
                if (tbProjeto == null)
                    return NotFound("Projeto não encontrado.");

                _context.TB_PROJETOS.Remove(tbProjeto);
                await _context.SaveChangesAsync();

                return Ok(await _context.TB_PROJETOS.ToListAsync());
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao tentar excluir o projeto. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{projetoId}/removeColaborador/{usuarioId}")]
        public async Task<ActionResult> RemoveColaborador(int projetoId, int usuarioId)
        {
            try
            {
                var projeto = await _context.TB_PROJETOS
                    .Include(p => p.Colaboradores)
                    .FirstOrDefaultAsync(p => p.Id == projetoId);

                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado.");
                }

                var usuario = await _context.TB_USUARIOS.FindAsync(usuarioId);
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                if (!projeto.Colaboradores.Any(u => u.Id == usuario.Id))
                {
                    return BadRequest("Este usuário não é um colaborador deste projeto.");
                }

                projeto.Colaboradores.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok("Colaborador removido com sucesso.");
            }
            catch (Exception)
            {
                return BadRequest("Houve um erro ao tentar remover o colaborador.");
            }
        }

    }

}

