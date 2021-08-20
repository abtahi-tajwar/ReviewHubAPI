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
        public string basePath = "https://localhost:44317/";
        public string advertise_imagePath = "Uploads/Products/";
        public string advertise_category_imagePath = "Uploads/Advertise_Category/";
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfiles>());
        }
        public AutoMapperProfiles()
        {
            //Mapper.CreateMap<advertise_categories, AdvertiseCategoryModel>();
            CreateMap<advertise_categories, AdvertiseCategoryModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => this.basePath + this.advertise_category_imagePath + src.Image));
            CreateMap<AdvertiseCreateModel, advertis>();
            CreateMap<advertis, AdvertiseModel>()
                .ForMember(dest => dest.AdvertiseCategory, opt => opt.MapFrom(src => src.advertise_categories.Name))
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.user.Username))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => this.basePath + this.advertise_imagePath + src.Image));
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

            CreateMap<featured_advertises, FeaturedAdvertiseModel>()                
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.advertis.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.advertis.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => this.basePath + this.advertise_imagePath + src.advertis.Image))
                .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => src.advertis.Created_at))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.advertis.ExpirationDate))
                .ForMember(dest => dest.Views, opt => opt.MapFrom(src => src.advertis.Views))
                .ForMember(dest => dest.AdvertiseCategory, opt => opt.MapFrom(src => src.advertis.advertise_categories.Name))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.advertis.UserId))
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.advertis.user.Username))
                .ForMember(dest => dest.FeaturedText, opt => opt.MapFrom(src => src.Text));
            CreateMap<FeaturedAdvertiseCreateModel, featured_advertises>();

        }
    }
}
