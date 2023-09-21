using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;

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
        ///<summary>
        ///Get All Hotels
        ///</summary>
        ///<returns></returns>
        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelService.GetAllHotels();
        }
        ///<summary>
        ///Get Hotel By Id
        ///</summary>
        ///<returns></returns>
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        ///<summary>
        ///Create an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public Hotel Post(Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }
        ///<summary>
        ///Update an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPut]
        public Hotel Put(Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
        ///<summary>
        ///Dalete the Hotel
        ///</summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);
        }
    }
}