using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remind.Dtos;
using Remind.Entities;
using Remind.Helpers;
using Remind.Services;

namespace Remind.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RemindersController(IReminderService reminderService, IMapper mapper, IUserService userService)
        {
            _reminderService = reminderService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = GetUserId();
            var reminders = _reminderService.GetByUser(userId);
            var reminderDtos = _mapper.Map<IList<ReminderDto>>(reminders);
            return Ok(reminderDtos);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ReminderDto reminderDto)
        {
            var userId = GetUserId();
            var reminder = _mapper.Map<Reminder>(reminderDto);

            var user = _userService.GetById(userId);
            reminder.User = user;

            try
            {
                reminder = _reminderService.Create(reminder);

                var createdReminderDto = _mapper.Map<ReminderDto>(reminder);

                return Ok(createdReminderDto);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private int GetUserId()
        {
            var userId = int.Parse(User.Identity.Name);

            return userId;
        }
    }
}
