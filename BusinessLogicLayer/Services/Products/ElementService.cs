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
    public class ElementService : GenericService<Element> , IElementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ElementService(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.Element)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VElement>> GetAllElements()
        {
            var elements = await _unitOfWork.Element.GetAllAsync();
            var vElements = _mapper.Map<List<Element>, List<VElement>>(elements);

            return vElements;
        }

        public async Task<List<VElement>> GetAllElementsWithElementType()
        {
            var elements = await _unitOfWork.Element.GetAllWithRelationalObjects("ElementType");
            var vElements = _mapper.Map<List<Element>, List<VElement>>(elements);

            return vElements;
        }

        public int GetSubElementCount(int windowId,int elementId)
        {
            return _unitOfWork.Element.GetSubElementCount(windowId, elementId);
        }

        public async Task<VElement> GetElementWithElementType(int elementId)
        {
            var element = await _unitOfWork.Element.GetWithRelationalObjects(x=> x.ElementId == elementId,nameof(ElementType));
            var vElement = _mapper.Map<Element, VElement>(element);

            return vElement;
        }

        public async Task<VElement> UpdateElement(VElement vElement)
        {
            var element = await _unitOfWork.Element.GetByIdAsync(vElement.ElementId);

            if (element != null)
            {
                element.ElementTypeId = vElement.ElementTypeId;
                element.Width = vElement.Width;
                element.Height = vElement.Height;

                await _unitOfWork.CompleteAsync();
                return vElement;
            }

            return null;
        }

        public async Task<VElement> CreateElement(VElement vElement)
        {
            var element = _mapper.Map< VElement, Element>(vElement);
            var result = await _unitOfWork.Element.AddAsync(element);
            await _unitOfWork.CompleteAsync();

            vElement.ElementId= result.ElementId;

            return vElement;
        }
    }
}
