using AutoMapper;
using Cars.Entity.Dtos.Brand;
using Cars.Entity.Dtos.Model;
using Cars.Entity.Dtos.Spesification;
using Cars.Entity.Dtos.TransmissionType;
using Cars.Entity.Dtos.Version;
using Cars.Entity.Dtos.VersionSpesification;
using Cars.Entity.Entities;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Business.Mapper
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
            CreateMap<Brand, BrandDto>()
                .ReverseMap();

            CreateMap<BrandAdd, Brand>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();

            CreateMap<BrandUpdate, Brand>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();


            CreateMap<Model, ModelDto>()
                .ReverseMap();

            CreateMap<ModelAdd, Model>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();
            CreateMap<ModelUpdate, Model>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();


            CreateMap<Spesification, SpesificationDto>()
                .ReverseMap();
            CreateMap<SpesificationAdd, Spesification>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();
            CreateMap<SpesificationUpdate, Spesification>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();


            CreateMap<TransmissionType, TransmissionTypeDto>()
                .ReverseMap();
            CreateMap<TransmissionTypeAdd, TransmissionType>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();
            CreateMap<TransmissionTypeUpdate, TransmissionType>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();


            CreateMap<Version, VersionDto>()
                .ForMember(dest => dest.TransmissionType, src => src.MapFrom(x => x.TransmissionType.Name))
                .ReverseMap();
            CreateMap<VersionAdd, Version>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();
            CreateMap<VersionUpdate, Version>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();

            CreateMap<VersionSpesification, VersionSpesificationDto>()
                .ReverseMap();
            CreateMap<VersionSpesificationAdd, VersionSpesification>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();
            CreateMap<VersionSpesificationUpdate, VersionSpesification>()
                .ForMember(dest => dest.IsActive, src => src.MapFrom(x => true))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(x => false))
                .ReverseMap();

        }
    }
}
