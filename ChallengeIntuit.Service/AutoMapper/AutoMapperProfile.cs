using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChallengeIntuit.Domain.Models;
using ChallengeIntuit.Domain.DTOs;
using ChallengeIntuit.Domain.DTOs.Request;

namespace ChallengeIntuit.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
        }
    }
}
