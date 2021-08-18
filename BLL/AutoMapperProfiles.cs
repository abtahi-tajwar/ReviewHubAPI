using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;

namespace BLL
{
    public class AutoMapperProfiles : Profile
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfiles>());
        }
        public AutoMapperProfiles()
        {
            //Mapper.CreateMap<advertise_categories, AdvertiseCategoryModel>();
            CreateMap<advertise_categories, AdvertiseCategoryModel>();
            CreateMap<advertis, AdvertiseModel>()
                .ForMember(dest => dest.AdvertiseCategory, opt => opt.MapFrom(src => src.advertise_categories.Name))
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.user.Username));
            CreateMap<advertise_comments, AdvertiseCommentModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Username));
            CreateMap<advertise_reacts, AdvertiseReactModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Username));
            CreateMap<advertise_locations, AdvertiseLocationModel>();
            CreateMap<review, ReviewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Username));
            CreateMap<advertis, AdvertiseDetailsModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Username))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(
                    src => AutoMapper.Mapper.Map<ICollection<advertise_comments>, ICollection<AdvertiseCommentModel>>(src.advertise_comments)))
                .ForMember(dest => dest.Reacts, opt => opt.MapFrom(
                    src => AutoMapper.Mapper.Map<ICollection<advertise_reacts>, ICollection<AdvertiseReactModel>>(src.advertise_reacts)))
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(
                    src => AutoMapper.Mapper.Map<ICollection<advertise_locations>, ICollection<AdvertiseLocationModel>>(src.advertise_locations)))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(
                    src => AutoMapper.Mapper.Map<ICollection<review>, ICollection<ReviewModel>>(src.reviews)));

        }
    }
}
