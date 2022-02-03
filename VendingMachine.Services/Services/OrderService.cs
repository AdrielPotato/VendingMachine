using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Services.Classes;
using VendingMachine.Services.DTO;
using VendingMachine.Services.Interfaces.Services;

namespace VendingMachine.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }
        public async Task<Order> GetByIdAsync(int Id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(Id);
        }

        public async Task<Order> AddOrderAsync(CreateOrderDto createOrderDto)
        {
            Order _newOrder = new Order() {
                DateCreated = DateTime.Now,
                ProductId = createOrderDto.ProductId,
                ProductName = createOrderDto.ProductName,
                ProductPrice = createOrderDto.ProductPrice
        };
            //_newOrder = _mapper.Map<CreateOrderDto, Order>(createOrderDto);

            //_newOrder.DateCreated = DateTime.Now;

            //Add new record
            if (!await _unitOfWork.Orders.CreateAsync(_newOrder))
            {
                return _newOrder;
            }

            return _newOrder;
        }

        public async Task<bool> DeleteOrderAsync(int Id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(Id);
            if (order != null)
            {
                return await _unitOfWork.Orders.Remove(order);
            }

            return false;
        }

        public Task<Product> GetProductByOrderIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
