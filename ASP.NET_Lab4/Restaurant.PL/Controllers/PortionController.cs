using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.PL.ViewModels;

namespace Restaurant.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortionController :ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPortionService _portionService;

        public PortionController(IMapper mapper, IPortionService portionService)
        {
            _mapper = mapper;
            _portionService = portionService;
        }

        [HttpGet("get_portions")]
        public IEnumerable<PortionViewModel> GetAllPortions()
        {
            return _mapper.Map<IEnumerable<PortionViewModel>>(_portionService.GetAllPortions());
        }
    }
}