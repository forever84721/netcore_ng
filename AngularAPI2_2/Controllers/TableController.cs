using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;
using AngularAPI2_2.Models;
using AngularAPI2_2.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AngularAPI2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly TestContext context;
        private readonly IUserService userService;
        private IMapper mapper;
        private readonly ApplicationSettings appSettings;
        public TableController(TestContext context, IUserService userService, IMapper mapper, IOptions<ApplicationSettings> appSettings)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }
        [Authorize]
        [HttpGet("[action]")]
        public BaseResponse GetArea()
        {
            var Areas = context.Area.ToList();
            return new BaseResponse(true, "", Areas);
        }

    }
}
