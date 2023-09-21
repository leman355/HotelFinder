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
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }
        ///<summary>
        ///<param name="id"></param>
        ///Get Hotel By Id
        ///</summary>
        ///<returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data

            }
            return NotFound(); //404
        }

        ///<summary>
        ///Create an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel(Hotel hotel)
        {
            var createdHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction(nameof(Get), new { id = createdHotel.Id }, createdHotel);   //201 + data
        }
        ///<summary>
        ///Update an Hotel
        ///</summary>
        ///<returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel(Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel)); //200 + data
            }
            return NotFound(); //404
        }
        ///<summary>
        ///Dalete the Hotel
        ///</summary>
        ///<returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound(); //404
        }
    }
}