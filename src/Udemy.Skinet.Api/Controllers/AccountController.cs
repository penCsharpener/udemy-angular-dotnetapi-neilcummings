﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.Skinet.Api.Dtos;
using Udemy.Skinet.Api.Errors;
using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Api.Controllers {
    public class AccountController : BaseApiController {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) {
                return Unauthorized(new ApiResponse(System.Net.HttpStatusCode.Unauthorized));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) {
                return Unauthorized(new ApiResponse(System.Net.HttpStatusCode.Unauthorized));
            }

            return new UserDto {
                Email = user.Email,
                Token = "this is the token",
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {
            var user = new AppUser {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) {
                return BadRequest(new ApiResponse(System.Net.HttpStatusCode.BadRequest));
            }

            return new UserDto {
                DisplayName = user.DisplayName,
                Token = "this will be a token",
                Email = user.Email
            };
        }
    }
}