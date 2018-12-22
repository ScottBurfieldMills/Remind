using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Remind.Dtos;
using Remind.Entities;
using Remind.Helpers;
using Remind.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Remind.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IUserSettingsService _userSettingsService;
        private readonly INotificationService _notificationService;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IUserSettingsService userSettingsService,
            INotificationService notificationService)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _userSettingsService = userSettingsService;
            _notificationService = notificationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Id,
                user.Username,
                user.FirstName,
                user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);

            try
            {
                // save 
                user = _userService.Create(user, userDto.Password);

                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}/settings")]
        public IActionResult UpdateSettings(int id, [FromBody] UpdateUserSettingsDto updateUserSettingsDto)
        {
            var user = _userService.GetById(id);
            user.DefaultReminderFrequency = updateUserSettingsDto.DefaultReminderFrequency;

            try
            {
                _userService.Update(user);

                return Ok(updateUserSettingsDto);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}/settings")]
        public IActionResult GetSettings(int id)
        {
            var user = _userService.GetById(id);

            var notificationTypes = _notificationService.GetTypes();
            var notificationTypeDtos = _mapper.Map<List<NotificationTypeDto>>(notificationTypes);

            var userSettingsDto = new UserSettingsDto
            {
                SelectedNotificationTypeId = user.UserNotificationTypeId,
                PossibleNotificationTypes = notificationTypeDtos,
                SelectedReminderFrequencyId = user.DefaultReminderFrequencyId
            };

            return Ok(userSettingsDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
