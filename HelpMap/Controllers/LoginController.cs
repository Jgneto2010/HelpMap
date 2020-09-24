using AutoMapper;
using HelpMap.Configurations;
using HelpMap.CrossCutting.Identity.Models;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models;
using HelpMap.Security;
using HelpMap.ViewModels;
using HelpMap.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelpMap.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGrupoRepository _grupoRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        public LoginController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<AppSettings> appSettings,
            IMapper mapper,
            IGrupoRepository grupoRepository) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _grupoRepository = grupoRepository;
        }


        [HttpPost]
        public async Task<object> LoginGet([FromBody]UserLogin userLogin)
        {

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                var userAplication = await _userManager.FindByNameAsync(userLogin.Email);
                var grupo = _mapper.Map<GrupoViewModel>(_grupoRepository.GetByIdGrupo(userAplication.IdGrupo));
                var token = await GenerateJwt(userLogin.Email);

                var usu = new UserSettingsViewModel()
                {
                    idGrupo = userAplication.IdGrupo,
                    Data = new DataViewModel()
                    {
                        DisplayName = grupo.Nome,
                        Email = userAplication.Email
                    },
                };

                return new
                {
                    user = usu,
                    access_token = token
                };
            }

            return new
            {
                access_token = "Invalid Tokken"
            };
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<ActionResult> CreateUser([FromServices]UserManager<ApplicationUser> _userManager,
                                                   [FromServices] RoleManager<IdentityRole> _roleManager,
                                                   [FromBody] UserRegistration userRegistration)
        {
            if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(Roles.Admin)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {Roles.Admin}.");
                }
            }

            var user = new ApplicationUser
            {
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                IdGrupo = userRegistration.IdGrupo
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, Roles.Admin).Wait();
                return Created($"registerUser/{result}", new { result });
            }
            else
                return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost]
        [Route("LoginToken")]
        public async Task<object> ValidTokenAsync([FromBody]TokenViewModel token)
        {

            var emailToken = await ReadTokeJwt(token.AccessToken);

            if (emailToken == "Token expirado")
            {
                return new
                {
                    error = "Token expirado"
                };
            }

            var userAplication = await _userManager.FindByNameAsync(emailToken);
            var grupo = _mapper.Map<GrupoViewModel>(_grupoRepository.GetByIdGrupo(userAplication.IdGrupo));

            var newToken = await GenerateJwt(emailToken);

            var usu = new UserSettingsViewModel()
            {
                idGrupo = userAplication.IdGrupo,
                Data = new DataViewModel()
                {
                    DisplayName = grupo.Nome,
                    Email = emailToken
                },
            };

            return new
            {
                user = usu,
                access_token = newToken
            };
        }

        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, Roles.Admin)
                    }),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidAt,
                Expires = DateTime.UtcNow.AddDays(7),
                //Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private async Task<string> ReadTokeJwt(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValid = tokenHandler.ReadJwtToken(token);

            if (tokenValid.ValidTo > DateTime.Now)
            {
                var retorno = tokenValid.Payload.Where(x => x.Key == "email").Select(y => y.Value).First();
                return retorno.ToString();
            }

            return "Token expirado";
        }

    }
}
