using System.Collections.Generic;
using Restaurant.BLL.DTOs;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IPortionService
    {
        IEnumerable<PortionDto> GetAllPortions();
    }
}