using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Entities.Locations;
using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using DomainLayer.VModels.Locations;
using DomainLayer.VModels.Orders;
using DomainLayer.VModels.Products;

namespace DomainLayer.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<VElementType, ElementType>().ReverseMap();

            CreateMap<VElement, Element>().ReverseMap();
            CreateMap<Element, VElement>().ForMember( ve=> ve.ElementTypeName , opt => opt.MapFrom(e=>e.ElementType.ElementTypeName));

            CreateMap<VWindow, Window>().ReverseMap();
            CreateMap<Window, VWindow>().ForMember(vw => vw.TotalSubElements, opt => opt.MapFrom(w => w.Elements.Count));

            CreateMap<VOrder, Order>().ReverseMap();
            CreateMap<Order, VOrder>().ForMember(vo => vo.StateName, opt => opt.MapFrom(o => o.State.StateName));

            CreateMap<VState, State>().ReverseMap();
        }
    }
}
