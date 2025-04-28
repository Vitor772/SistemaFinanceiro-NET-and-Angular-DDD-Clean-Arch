using System.Text;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.email) ||
                string.IsNullOrWhiteSpace(login.senha) ||
                string.IsNullOrWhiteSpace(login.cpf))
            {
                return Ok("Falta algubs dados");
            }

            var user = new ApplicationUser
            {
                Email = login.email,
                UserName = login.email,
                CPF = login.cpf,
            };

            var result = await _userManager.CreateAsync(user, login.senha);

            if(result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var reponse_Retorn = await _userManager.ConfirmEmailAsync(user, code);
            
            if(reponse_Retorn.Succeeded)
            {
                return Ok("Usuário Adionado!");
            }
            else
            {
                return Ok("erro ao confirmar cadastro de usuário!");
            }
        }

    }
}
