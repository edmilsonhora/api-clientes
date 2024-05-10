using ESH.Barbearia.ApplicationService.Facades;
using ESH.Barbearia.ApplicationService.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESH_Barbearia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IFacade _facade;
        public ClienteController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpPost("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Salvar(ClienteView view)
        {
            try
            {
                _facade.Clientes.Salvar(view);
                _facade.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterPor/{id:int}")]
        [ProducesResponseType(typeof(ClienteView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPor(int id)
        {
            try
            {
                var view = _facade.Clientes.ObterPor(id);
                return Ok(view);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterTodos")]
        [ProducesResponseType(typeof(List<ClienteView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterTodos()
        {
            try
            {
                var view = _facade.Clientes.ObterTodos();
                return Ok(view);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluirPor/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ExcluirPor(int id)
        {
            try
            {
                _facade.Clientes.Excluir(id);
                _facade.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("clienteJahExiste/{cpf}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult VerificaSeExiste(string cpf)
        {
            try
            {
                var view = _facade.Clientes.VerificaSeClienteJahExiste(cpf);
                return Ok(view);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
