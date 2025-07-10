using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MoviewApi.Persistence.Context;
using MoviewApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _movieContext;
        private readonly UserManager<AppUser> _userManager;

        public CreateUserRegisterCommandHandler(UserManager<AppUser> userManager, MovieContext movieContext)
        {
            _userManager = userManager;
            _movieContext = movieContext;
        }

        public async Task Handle(CreateUserRegisterCommand createUserRegisterCommand)
        {
            AppUser appUser = new AppUser()
            {
                Name = createUserRegisterCommand.Name,
                Surname = createUserRegisterCommand.Surname,
                Email = createUserRegisterCommand.Email,
                PhoneNumber = createUserRegisterCommand.PhoneNumber,
                UserName = createUserRegisterCommand.UserName
            };

            await _userManager.CreateAsync(appUser, createUserRegisterCommand.Password);
        }
    }
}
