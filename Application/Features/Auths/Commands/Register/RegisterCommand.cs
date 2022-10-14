using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }


        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
        {
            private readonly AuthBusinnessRules _authBusinnessRules;
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;

            public RegisterCommandHandler(IAuthService authService, IUserRepository userRepository)
            {
                _authService = authService;
                _userRepository = userRepository;
            }

            public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
               // await _authBusinnessRules.EmailCanNotBeDublicatedWhenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                User newUser = new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
                await _userRepository.AddAsync(newUser);
                AccessToken accessToken = await _authService.CreateAccessToken(newUser);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(newUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

                return new()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                };
            }
        }
    }
}
