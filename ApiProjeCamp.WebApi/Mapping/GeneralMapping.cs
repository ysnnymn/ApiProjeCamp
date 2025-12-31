using ApiProjeCamp.WebApi.Dtos.ContactDtos;
using ApiProjeCamp.WebApi.Dtos.FeatureDtos;
using ApiProjeCamp.WebApi.Dtos.MessageDtos;
using ApiProjeCamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjeCamp.WebApi.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        CreateMap<Feature,ResultFeatureDto>().ReverseMap();
        CreateMap<Feature,CreateFeatureDto>().ReverseMap();
        CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();
        
        CreateMap<Message,ResultMessageDto>().ReverseMap();
        CreateMap<Message,CreateMessageDto>().ReverseMap();
        CreateMap<Message,UpdateMessageDto>().ReverseMap();
        CreateMap<Message,GetByIdMessageDto>().ReverseMap();
    }
}