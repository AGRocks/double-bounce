using AutoMapper;
using System;
using traininghub.api.ViewModels;
using Traininghub.Data;

namespace traininghub.api.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Game, GameViewModel>()
                   .ForMember(dest => dest.OrganizerName,
                              opts => opts.MapFrom(src => src.Organizer.FullName))
                   .ForMember(dest => dest.VenueName,
                              opts => opts.MapFrom(src => src.Venue.Name))
                   .ForMember(dest => dest.Sport,
                              opts => opts.MapFrom(src => Enum.GetName(typeof(Sport), src.Sport)))
                   .ForMember(dest => dest.SkillLevel, 
                              opts => opts.MapFrom(src => Enum.GetName(typeof(SkillLevel), src.SkillLevel)));
                cfg.CreateMap<GameViewModel, Game>();

                cfg.CreateMap<Challenge, ChallengeViewModel>()
                   .ForMember(dest => dest.UserName,
                              opts => opts.MapFrom(src => src.User.FullName));
                cfg.CreateMap<ChallengeViewModel, Challenge>();
            });
        }
    }
}
