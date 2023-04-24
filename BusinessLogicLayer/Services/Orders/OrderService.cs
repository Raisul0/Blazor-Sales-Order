using AutoMapper;
using BusinessLogicLayer.Interfaces.Orders;
using DataAccessLayer.IRepository;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using DomainLayer.VModels.Orders;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Orders
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.Order)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VOrder>> GetAllOrdersWithWindows()
        {
            var orders = await _unitOfWork.Order.GetAllOrderWithWindows();
            var vOrders = _mapper.Map<List<Order>, List<VOrder>>(orders);

            return vOrders;
        }

        public async Task<VOrder> GetOrderWithWindows(int orderId)
        {
            var order = await _unitOfWork.Order.GetOrderWithWindow(orderId);
            var vOrder = _mapper.Map<Order, VOrder>(order);

            return vOrder;
        }

        public async Task<VOrder> UpdateOrder(VOrder vOrder, List<VWindow> windows)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(vOrder.OrderId);

            if (order != null)
            {
                order.OrderName = vOrder.OrderName;
                order.StateId = vOrder.StateId;

                await _unitOfWork.CompleteAsync();

                var mappedWindows = _mapper.Map<List<VWindow>, List<Window>>(windows);
                var windowElements = await _unitOfWork.Order.AddWindowElements(order, mappedWindows);
                await _unitOfWork.CompleteAsync();


                return vOrder;
            }

            return null;
        }

        public async Task<VOrder> CreateOrder(VOrder vOrder, List<VWindow> windows)
        {
            var order = _mapper.Map<VOrder, Order>(vOrder);
            var result = await _unitOfWork.Order.AddAsync(order);
            await _unitOfWork.CompleteAsync();

            var mappedWindows = _mapper.Map<List<VWindow>, List<Window>>(windows);
            var windowElements = await _unitOfWork.Order.AddWindowElements(result, mappedWindows);
            await _unitOfWork.CompleteAsync();

            vOrder.OrderId = result.OrderId;

            return vOrder;
        }
    }
}
