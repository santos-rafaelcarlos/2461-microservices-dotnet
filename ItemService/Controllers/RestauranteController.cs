using AutoMapper;
using ItemService.Data;
using ItemService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers;

[Route ("api/item/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase {
    private readonly IItemRepository _repository;
    private readonly IMapper _mapper;

    public RestauranteController (IItemRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RestauranteReadDto>> GetRestaurantes () {
        var restaurantes = _repository.GetAllRestaurantes ();

        return Ok (_mapper.Map<IEnumerable<RestauranteReadDto>> (restaurantes));
    }

    [HttpPost]
    public IActionResult RecebeRestaurante (RestauranteReadDto dto) {
        return Ok (dto);
    }

    [HttpPost]
    public IActionResult TestInboundConnection () {
        return Ok ("Conex�o ok!");
    }
}