using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelFinder.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;

        }
        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelService.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        [HttpPost]
        public Hotel Post(Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }
        [HttpPut]
        public Hotel Put(Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);
        }
    }
}