
namespace BooklyBookStoreApp.Application.DTOs.UserDtos;

 public record RegisterUserDto(
     string NameSurname,
     string UserName,
     string Password,
     string Email,
     string PhoneNumber,
     string Adress,
     string City,
     string District);


