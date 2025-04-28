using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuariosSistemaFinanceiro _InterfaceUsuariosSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _IUsuarioSistemaFinanceiroServico;
        public UsuariosSistemaFinanceiroController(InterfaceUsuariosSistemaFinanceiro InterfaceUsuariosSistemaFinanceiro, IUsuarioSistemaFinanceiroServico IUsuarioSistemaFinanceiroServico)
        {
            _InterfaceUsuariosSistemaFinanceiro = InterfaceUsuariosSistemaFinanceiro;
            _IUsuarioSistemaFinanceiroServico = IUsuarioSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuariosSistema(int idSistema)
        {
            return await _InterfaceUsuariosSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _IUsuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(
                new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true
                });
            }
            catch (Exception) {
                return Task.FromResult(false);
            
            }
            return Task.FromResult(true);            

        }

        [HttpDelete("/api/DeleteUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioNoSistema(int id)
        {
            try
            {
                
                var usuarioSitemaFinanceiro = await _InterfaceUsuariosSistemaFinanceiro.GetEntityById(id);
                await _InterfaceUsuariosSistemaFinanceiro.Delete(usuarioSitemaFinanceiro);
            }   

            catch (Exception)
            {
                return Task.FromResult(false);

            }
            return Task.FromResult(true);

        }

    }
}
