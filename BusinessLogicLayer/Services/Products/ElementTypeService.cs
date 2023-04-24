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
    public class ElementTypeService : GenericService<ElementType> , IElementTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ElementTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, unitOfWork.ElementType)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VElementType>> GetAllElementTypes()
        {
            var elementTypes = await _unitOfWork.ElementType.GetAllAsync();
            var vElementTypes = _mapper.Map<List<ElementType>, List<VElementType>>(elementTypes);

            return vElementTypes;
        }
    }
}
