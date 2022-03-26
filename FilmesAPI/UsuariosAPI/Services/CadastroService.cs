using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, EmailService emailService,
            UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDTO createDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDTO);
            CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(usuario);
            var resultadoIdentity = _userManager
                .CreateAsync(identityUser, createDTO.Password).Result;

            _userManager.AddToRoleAsync(identityUser, "regular");

            if (resultadoIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new [] {identityUser.Email},
                    "Link de Ativação",
                    identityUser.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário.");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(
                user => user.Id == request.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(
                identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário.");
        }
    }
}
