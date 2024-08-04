using gpbaTestExaple.Interfaces;
using gpbaTestExaple.Models;
using Microsoft.AspNetCore.Mvc;

namespace gpbaTestExaple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        /// <summary>
        /// Метод для добавления нового оффера
        /// </summary>
        /// <param name="offer">Оффер</param>
        /// <returns></returns>
        [HttpPost("offer")]
        public async Task<IActionResult> CreateOffer([FromBody] Offer offer)
        {
            if (offer == null)
            {
                return BadRequest();
            }
            try
            {
                var createdOffer = await _offerService.CreateOfferAsync(offer);
                return Ok(createdOffer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Метод для возврата найденых записей с общем количеством
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchOffers([FromQuery] string query)
        {
            try
            {
                var offers = await _offerService.SearchOffersAsync(query);
                return Ok(new { offers, total = offers.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Метод возвращает 3 популярных поставщика
        /// </summary>
        /// <returns></returns>
        [HttpGet("popular-suppliers")]
        public async Task<IActionResult> GetPopularSuppliers()
        {
            var suppliers = await _offerService.GetPopularSuppliersAsync();
            return Ok(suppliers);
        }
    }
}
