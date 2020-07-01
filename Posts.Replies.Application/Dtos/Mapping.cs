using AutoMapper;
using Posts.Replies.Application.Helpers;
using Posts.Replies.Infrastructure.Entities;

namespace Posts.Replies.Application.Dtos
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Reply, ReplyDto>();

            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<PaginatedList<Reply>, PaginatedListDto<ReplyDto>>()
                .ForMember(d => d.PageIndex, s => s.MapFrom(s => s.PageIndex))
                .ForMember(d => d.TotalPages, s => s.MapFrom(s => s.TotalPages))
                .ForMember(d => d.HasPreviousPage, s => s.MapFrom(s => s.HasPreviousPage))
                .ForMember(d => d.HasNextPage, s => s.MapFrom(s => s.HasNextPage))
                .ForMember(d => d.Data, s => s.MapFrom(s => s));
        }
    }
}