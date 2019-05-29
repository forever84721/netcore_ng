using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI2_2.Models.ResponseModels;
using AngularAPI2_2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI2_2.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FunctionButtonController : ControllerBase
    {
        private readonly IFunctionButtonService functionButtonService;

        public FunctionButtonController(IFunctionButtonService functionButtonService)
        {
            this.functionButtonService = functionButtonService;
        }
        [HttpGet("[action]")]
        public BaseResponse GetFunctionButtons()
        {
            var model = functionButtonService.GetFunctionButtonsByType(FunctionGroupType.Function);
            return new BaseResponse(true, "", model);
        }
    }
}