using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using traininghub.api.ViewModels;
using Traininghub.Data;

namespace traininghub.api.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<GameViewModel, Game>();
            });
        }
    }
}
