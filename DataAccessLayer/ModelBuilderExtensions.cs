using DomainLayer.Entities.Locations;
using DomainLayer.Entities.Orders;
using DomainLayer.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            IntializeElementTypes(modelBuilder);
            IntializeElements(modelBuilder);
            IntializeWindows(modelBuilder);
            IntializeStates(modelBuilder);
            IntializeOrders(modelBuilder);
        }

        public static void IntializeElementTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElementType>().HasData(new ElementType { ElementTypeId = 1, ElementTypeName = "Doors", Description = "Door type Elements" });
            modelBuilder.Entity<ElementType>().HasData(new ElementType { ElementTypeId = 2, ElementTypeName = "Windows", Description = "Window type Elements" });
        }

        public static void IntializeElements(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 1, ElementTypeId = 1, Width = 1200 , Height=1850 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 2, ElementTypeId = 2, Width = 800, Height = 1850 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 3, ElementTypeId = 2, Width = 700, Height = 1850 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 4, ElementTypeId = 2, Width = 1500, Height = 2000 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 5, ElementTypeId = 1, Width = 1400, Height = 2200 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 6, ElementTypeId = 2, Width = 600, Height = 2200 });
            modelBuilder.Entity<Element>().HasData(new Element { ElementId = 7, ElementTypeId = 2, Width = 1500, Height = 2000 });
        }

        public static void IntializeWindows(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Window>().HasData(new Window { WindowId = 1, WindowName = "A51" });
            modelBuilder.Entity<Window>().HasData(new Window { WindowId = 2, WindowName = "C Zone 5" });
            modelBuilder.Entity<Window>().HasData(new Window { WindowId = 3, WindowName = "GLB" });
            modelBuilder.Entity<Window>().HasData(new Window { WindowId = 4, WindowName = "OHF" });

            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 1, WindowId = 1, ElementId = 1 });
            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 2, WindowId = 1, ElementId = 2 });
            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 3, WindowId = 1, ElementId = 3 });

            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 4, WindowId = 2, ElementId = 4 });

            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 5, WindowId = 3, ElementId = 5 });
            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 6, WindowId = 3, ElementId = 6 });

            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 7, WindowId = 4, ElementId = 7 });
            modelBuilder.Entity<WindowElement>().HasData(new WindowElement { WindowElementId = 8, WindowId = 4, ElementId = 7 });

        }

        public static void IntializeStates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(new State { StateId = 1, StateName = "NY" });
            modelBuilder.Entity<State>().HasData(new State { StateId = 2, StateName = "CA" });
        }

        public static void IntializeOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 1, OrderName = "New York Building 1", StateId = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 2, OrderName = "California Hotel AJK", StateId = 2 });

            modelBuilder.Entity<OrderWindow>().HasData(new OrderWindow { OrderWindowId = 1, OrderId = 1, WindowId = 1 , WindowQuantity = 4 });
            modelBuilder.Entity<OrderWindow>().HasData(new OrderWindow { OrderWindowId = 2, OrderId = 1, WindowId = 2 , WindowQuantity = 2 });
            modelBuilder.Entity<OrderWindow>().HasData(new OrderWindow { OrderWindowId = 3, OrderId = 2, WindowId = 3 , WindowQuantity = 3 });
            modelBuilder.Entity<OrderWindow>().HasData(new OrderWindow { OrderWindowId = 4, OrderId = 2, WindowId = 4 , WindowQuantity = 10 });
        }
    }
}
