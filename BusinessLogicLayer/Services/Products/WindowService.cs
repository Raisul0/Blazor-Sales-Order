using AutoMapper;
using BusinessLogicLayer.Interfaces.Products;
using DataAccessLayer.IRepository.Products;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Entities.Products;
using DomainLayer.VModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Products
{
    public class WindowService : GenericService<Window> , IWindowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WindowService(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.Window)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VWindow>> GetAllWindowsWithElements()
        {
            var windows = await _unitOfWork.Window.GetAllWindowsWithElements();
            var vWindows = _mapper.Map<List<Window>, List<VWindow>>(windows);

            return vWindows;
        }

        public async Task<VWindow> GetWindowWithElements(int windowId)
        {
            var window = await _unitOfWork.Window.GetWindowWithElements(windowId);
            var vWindow = _mapper.Map<Window, VWindow>(window);

            return vWindow;
        }
        public int GetWindowQuantity(int orderId, int windowId)
        {
            return _unitOfWork.Window.GetWindowQuantity(orderId, windowId);
        }

        public async Task<VWindow> UpdateWindow(VWindow vWindow,List<VElement> elements)
        {
            var window = await _unitOfWork.Window.GetByIdAsync(vWindow.WindowId);

            if (window != null)
            {
                window.WindowName = vWindow.WindowName;
                await _unitOfWork.CompleteAsync();


                var mappedElements = _mapper.Map<List<VElement>, List<Element>>(elements);
                var windowElements = await _unitOfWork.Window.AddWindowElements(window, mappedElements);
                await _unitOfWork.CompleteAsync();

                return vWindow;
            }

            return null;
        }

        public async Task<VWindow> CreateWindow(VWindow vWindow,List<VElement> elements)
        {
            var window = _mapper.Map<VWindow, Window>(vWindow);
            var result = await _unitOfWork.Window.AddAsync(window);
            await _unitOfWork.CompleteAsync();

            var mappedElements = _mapper.Map<List<VElement>, List<Element>>(elements);
            var windowElements = await _unitOfWork.Window.AddWindowElements(result, mappedElements);
            await _unitOfWork.CompleteAsync();


            vWindow.WindowId = result.WindowId;

            return vWindow;
        }

    }
}
