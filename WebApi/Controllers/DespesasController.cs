using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly InterfaceDespesa _InterfaceDespesa;
        private readonly IDespesaServico _IDespesaServico;
        public DespesasController(InterfaceDespesa InterfaceDespesa, IDespesaServico IDespesaServico) 
        {
            _InterfaceDespesa = InterfaceDespesa;
            _IDespesaServico = IDespesaServico;


        }
        [HttpGet("/api/ListarDepesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDepesasUsuario(string emailUsuario)
        {
            return await _InterfaceDespesa.ListarDepesasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _IDespesaServico.AdicionarDespesa(despesa);

            return despesa;

        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _IDespesaServico.AtualizarDespesa(despesa);

            return despesa;

        }

        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _InterfaceDespesa.GetEntityById(id); 

        }

        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var despesa = await _InterfaceDespesa.GetEntityById(id);
                await _InterfaceDespesa.Delete(despesa);
            }
            catch (Exception) {
                return false;
            
            }
            return true;

        }


        [HttpGet("/api/CarregarGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            return await _IDespesaServico.CarregarGraficos(emailUsuario);

        }
    }
}
