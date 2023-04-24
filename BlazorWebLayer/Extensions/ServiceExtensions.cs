using BusinessLogicLayer.Interfaces.Locations;
using BusinessLogicLayer.Interfaces.Orders;
using BusinessLogicLayer.Interfaces.Products;
using BusinessLogicLayer.Services.Locations;
using BusinessLogicLayer.Services.Orders;
using BusinessLogicLayer.Services.Products;
using DataAccessLayer.IRepository.Locations;
using DataAccessLayer.IRepository.Orders;
using DataAccessLayer.IRepository.Products;
using DataAccessLayer.Repository.Locations;
using DataAccessLayer.Repository.Orders;
using DataAccessLayer.Repository.Products;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Helper;
using System.Text;

namespace BlazorWebLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterRepositories(this IServiceCollection collection)
        {
            #region Unit Of Work
            collection.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Products
            collection.AddTransient<IElementTypeRepo, ElementTypeRepo>();
            collection.AddTransient<IElementRepo, ElementRepo>();
            collection.AddTransient<IWindowRepo, WindowRepo>();
            #endregion

            #region Orders
            collection.AddTransient<IOrderRepo, OrderRepo>();
            #endregion

            #region Locations
            collection.AddTransient<IStateRepo, StateRepo>();
            #endregion

        }

        public static void RegisterServices(this IServiceCollection collection)
        {
            collection.AddTransient<IElementTypeService, ElementTypeService>();
            collection.AddTransient<IElementService, ElementService>();
            collection.AddTransient<IWindowService, WindowService>();
            collection.AddTransient<IOrderService, OrderService>();
            collection.AddTransient<IStateService, StateService>();
        }

        public static void RegisterBlazorServices(this IServiceCollection collection)
        {
           
        }

        public static void RegisterLogging(this IServiceCollection collection)
        {
            //Register logging
        }

        public static void RegisterAuthentication(this IServiceCollection collection)
        {

        }

        public static void RegisterMapper(this IServiceCollection collection)
        {
            collection.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
        }
    }
}
