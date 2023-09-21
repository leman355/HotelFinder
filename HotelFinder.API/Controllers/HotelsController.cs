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
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }
        ///<summary>
        ///Get Hotel By Id
        ///</summary>
        ///<returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }
        ///<summary>
        ///Create an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction(nameof(Get), new { id = createdHotel.Id }, createdHotel);   //201 + data
        }
        ///<summary>
        ///Update an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPut]
        public IActionResult Put(Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 + data
            }
            return NotFound(); //404
        }
        ///<summary>
        ///Dalete the Hotel
        ///</summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound(); //404
        }
    }
}