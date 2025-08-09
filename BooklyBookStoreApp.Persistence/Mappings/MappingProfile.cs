using AutoMapper;
using BooklyBookStoreApp.Application.DTOs.BasketDtos;
using BooklyBookStoreApp.Application.DTOs.BookDtos;
using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.DTOs.Favorites;
using BooklyBookStoreApp.Application.DTOs.FavoritesDtos;
using BooklyBookStoreApp.Application.DTOs.OrderDtos;
using BooklyBookStoreApp.Application.DTOs.UserDtos;
using BooklyBookStoreApp.Domain.Entitites;

namespace BooklyBookStoreApp.Persistence.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookDto, Book>().ReverseMap();

        CreateMap<UpdateBookDto, Book>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();

        CreateMap<GetOneBookWithCategoryNameDto, Book>().ReverseMap()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<GetAllBooksWithCategoryNameDto, Book>().ReverseMap()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<GetOneCategoryByIdDto, CategoryDto>().ReverseMap();
        CreateMap<GetAllCategoriesDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();


        CreateMap<RegisterUserDto, User>().ReverseMap();


        CreateMap<CreateFavoriteDto,Favorites>().ReverseMap();
        CreateMap<Favorites, FavoriteDto>().ReverseMap();
        CreateMap<Favorites, GetAllFavoritesByUsernameWithBookDetailsDto>()
    .ForMember(dest => dest.FavoriteId, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookID))
    .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
    .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Book.PictureURl))
    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Book.Price))
    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt));


        CreateMap<BasketItem, BasketItemDto>()
           .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
           .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price));

        CreateMap<Basket, BasketDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.BasketItems))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
                src.BasketItems.Sum(item => item.Quantity * item.Book.Price)));



        CreateMap<Order, CreatedOrderDto>()
       .ConstructUsing(o => new CreatedOrderDto(
           o.Id,
           o.TotalPrice,
           o.OrderDate,
           o.OrderBooks.Select(ob => new OrderBookDto(
               ob.Book.Id,
               ob.Book.Title,
               ob.Book.Price,
               ob.Book.Category.Name,
               ob.Quantity
           )).ToList()
       ));

        CreateMap<OrderBook, OrderBookDto>()
            .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Book.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Book.Price))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Book.Category.Name));

    }
}
