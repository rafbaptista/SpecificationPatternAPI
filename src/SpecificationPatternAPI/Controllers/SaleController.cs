using Microsoft.AspNetCore.Mvc;
using SpecificationPatternAPI.Domain.Contracts.Services;
using SpecificationPatternAPI.Domain.Entities;
using SpecificationPatternAPI.Domain.Specifications;

namespace SpecificationPatternAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;
        private readonly IUserService _userService;

        public SaleController(ILogger<SaleController> logger, ISaleService saleService, IUserService userService)
        {
            _logger = logger;
            _saleService = saleService;
            _userService = userService;
        }

        [HttpGet(template: "sales/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            User user = await _userService.Single(UserSpecifications.ByUserId(userId));
            List<Sale> sales = await _saleService.FindBy(SaleSpecifications.ByUser(user));
            return Ok(sales);
        }

    }
}
