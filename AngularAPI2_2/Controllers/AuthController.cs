﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularAPI2_2.DbModels;
using AngularAPI2_2.Models;
using AngularAPI2_2.Service;
using AngularAPI2_2.Service.Impl;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static AngularAPI2_2.Controllers.SampleDataController;

namespace AngularAPI2_2.Controllers
{
    /// <summary>
    /// AuthController summary
    /// </summary>
    /// <remarks>
    /// AuthController remarks
    /// </remarks>
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly TestContext context;
        private readonly IUserService userService;
        private IMapper mapper;
        public AuthController(TestContext context, IUserService userService, IMapper mapper)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Registered([FromBody]RegisteredModel model)
        {
            //var a = mapper.Map<User>(model);
            var u = mapper.Map<User>(model);
            u.Password = Utility.Utility.PasswordEncoding(u.Password);
            u.SetupTime = DateTime.Now;
            context.User.Add(u);
            await context.SaveChangesAsync();
            return Ok(new BaseResponse(true, "", null));
        }
        /// <summary>
        /// 登入帳號
        /// </summary>        
        /// <remarks>
        /// remarks 登入帳號
        /// </remarks>
        /// <param name="model">帳號 密碼</param>
        /// <returns>AAA</returns>
        [HttpPost("[action]")]
        public ActionResult Login([FromBody]LoginModel model)
        {
            //using (UserService userService = new UserService(context))
            {
                var user = userService.FindUserByAccount(model.Account);
                if (user != null && userService.CheckPassword(user, model.Password))
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("Account",user.Account),
                        new Claim("UserName",user.UserName),
                        new Claim("Email",user.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new BaseResponse(true, "", token));
                }
                return Ok(new BaseResponse(false, "帳號或密碼錯誤", null));
            }
        }
        [Authorize]
        [HttpGet("[action]")]
        public BaseResponse TestAuthorize()
        {
            var r = new Random();
            return new BaseResponse(true, "TestAuthorize msg" + r.Next(0, 100), null);
        }

        public class RegisteredModel
        {
            public string Account { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        }
        public class LoginModel
        {
            public string Account { get; set; }
            public string Password { get; set; }
        }
    }
}