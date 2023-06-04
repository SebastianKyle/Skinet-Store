using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Entities.OrderAggregate;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.Domain.Specifications;
using Skinet.Core.ServiceContracts.OrderServices;
using Skinet.Core.ServiceContracts.PaymentServices;

namespace Skinet.Core.Services.OrderServices
{
  public class OrderService : IOrderService
  {
    private readonly IBasketRepository _basketRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentService _paymentService;

    public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork, IPaymentService paymentService)
    {
      _basketRepo = basketRepo;
      _unitOfWork = unitOfWork;
      _paymentService = paymentService;
    }

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
      // Get basket from basket repo
			var basket = await _basketRepo.GetBasketAsync(basketId);

      // Get items from product repo
			var items = new List<OrderItem>();
			foreach (var item in basket.Items) 
			{
				var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
				var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.ProductName, productItem.PictureUrl);
				var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
				items.Add(orderItem);
			}

      // Get delivery method
			var dmMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

      // Calculate subtotal
			var subTotal = items.Sum(i => i.Price * i.Quantity);

      // Check if order exists
      var spec = new OrderByPaymentIntentIdSpecification(basket.PaymentIntentId);
      var existingOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
      if (existingOrder != null) 
      {
        _unitOfWork.Repository<Order>().Delete(existingOrder);
        await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
      }

      // Create order
			var order = new Order(items, buyerEmail, shippingAddress, dmMethod, subTotal, basket.PaymentIntentId);
      _unitOfWork.Repository<Order>().Add(order);
			
      // save to db
      var result = await _unitOfWork.Complete();
      if (result <= 0) {
        return null;
      }

      // return order

			return order;
    }

    public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
      return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
      var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
      return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
    }

    public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
      var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
      return await _unitOfWork.Repository<Order>().ListAsync(spec);
    }
  }
}