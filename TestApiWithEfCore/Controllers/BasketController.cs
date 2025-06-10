using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiWithEfCore.NewFolder;
using TestApiWithEfCore.Repo;

namespace TestApiWithEfCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
    }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketDto basket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var basketmodel = _mapper.Map<BasketModel>(basket);


            await _unitOfWork.Baskets.AddAsync(basketmodel);
            await _unitOfWork.CompleteAsync();

            return Ok(basket);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket(Guid id)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(id);

            if (basket == null)
                return NotFound();

            return Ok(basket);
        }
    }

}
