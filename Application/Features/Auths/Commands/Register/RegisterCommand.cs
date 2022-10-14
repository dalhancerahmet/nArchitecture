using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Core.Security.Dtos;
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
        public string Email { get; set; }
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAdress { get; set; }


        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
        {
            private readonly AuthBusinnessRules _authBusinnessRules;

            public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinnessRules.EmailCanNotBeDublicatedWhenRegistered(request.Email);
            }
        }
    }
}
