using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;
using AngularAPI2_2.Models;
using AngularAPI2_2.Models.ResponseModels;
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
        private readonly ITableService tableService;
        private readonly ApplicationSettings appSettings;
        public TableController( ITableService tableService, IOptions<ApplicationSettings> appSettings)
        {
            this.tableService = tableService;
            this.appSettings = appSettings.Value;
        }
        [Authorize]
        [HttpGet("[action]")]
        public BaseResponse GetAreaWithTables()
        {
            List<AreaWithTables> model = tableService.GetAreaWithTables();
            return new BaseResponse(true, "", model);
        }
    }
}
