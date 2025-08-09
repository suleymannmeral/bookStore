using AutoMapper;
using BooklyBookStoreApp.Application.DTOs.BookDtos;
using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.DTOs.OrderDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;


namespace BooklyBookStoreApp.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CreatedOrderDto> CreateOrderAsync(string userId)
        {
            // 1. Kullanıcının sepetini ve içindeki kitap + kategori ilişkilerini yükle
            var basket = await _repositoryManager.Basket
                .FindByCondition(b => b.UserId == userId, true)
                .Include(b => b.BasketItems)
                    .ThenInclude(i => i.Book)
                        .ThenInclude(bk => bk.Category)
                .FirstOrDefaultAsync();

            if (basket == null || !basket.BasketItems.Any())
                throw new Exception("Sepetiniz boş.");

            // 2. Order entity'sini oluştur (DTO'dan değil, burada doğrudan entity kuruyoruz)
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = basket.BasketItems.Sum(i => i.Book.Price * i.Quantity),
                OrderBooks = basket.BasketItems.Select(i => new OrderBook
                {
                    BookId = i.BookId,
                    Quantity = i.Quantity
                }).ToList()
            };

            // 3. Order'ı ekle ve kaydet
            _repositoryManager.Order.Create(order);
            await _repositoryManager.Save();

            // 4. Order'ı yeniden yükle, ilişkileri dahil et (Book ve Category)  
            var createdOrder = await _repositoryManager.Order
                .FindByCondition(o => o.Id == order.Id, false)
                .Include(o => o.OrderBooks)
                    .ThenInclude(ob => ob.Book)
                        .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();

            // 5. Sepeti temizle ve kaydet (istersen transaction kullanabilirsin)
            basket.BasketItems.Clear();
            await _repositoryManager.Save();

            // 6. AutoMapper ile entity'yi DTO'ya dönüştür ve döndür
            return _mapper.Map<CreatedOrderDto>(createdOrder);
        }


        public Task DeleteCategoryAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAllOrdersByUserIdDto>> GetAllOrdersByUserIdAsync(bool trackChanges,string userid)
        {
            var orders = await _repositoryManager.Order
        .GetAllOrdersByUserId(trackChanges, userid)
        .Include(o => o.OrderBooks)
            .ThenInclude(ob => ob.Book)
                .ThenInclude(b => b.Category)
        .ToListAsync();

            return _mapper.Map<IEnumerable<GetAllOrdersByUserIdDto>>(orders);

        }

        public Task<GetOneCategoryByIdDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto, bool trackChanges)
        {
            throw new NotImplementedException();
        }

     
    }
}
