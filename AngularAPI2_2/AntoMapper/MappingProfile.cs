using AngularAPI2_2.DbModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AngularAPI2_2.Controllers.AuthController;

namespace AngularAPI2_2.AntoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, RegisteredModel>();
            CreateMap<RegisteredModel, User>();
        }
    }
}
