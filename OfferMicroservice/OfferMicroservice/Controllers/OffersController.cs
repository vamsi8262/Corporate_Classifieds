using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferMicroservice.Models;

namespace OfferMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ClassifiedsContext _context;

        public OffersController(ClassifiedsContext context)
        {
            _context = context;
        }



        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOfferDetails(int id)
        {
            var offer = await _context.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        [HttpGet("GetOfferByLikes/{likes}")]
        public IActionResult GetOfferByLikes(int likes)
        {
            var offer = _context.Offer;

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer.ToList());
        }



        // PUT: api/Offers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> EditOffer(int id, int eId, Offer offer)
        {
            if (id != offer.OfferId && eId != offer.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Offers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Offer>> AddOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfferExists(offer.OfferId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Offer created Successfully");
        }


        //[HttpGet]
        //[Route("GetOfferByOpenedDate/{openedDate}")]
        //public async Task<IActionResult> GetOfferByOpenedDateAsync(string openedDate)
        //{
        //    var offer = await _context.Offer.Where<e => e.OpenedDate.ToString().Substring(0, 10) == openedDate>.ToList();

        //    // var offer = from c in offers where c.OpenedDate.ToString("dd-MM-yyyyy") == openedDate select c;
        //    if (offer.Count == 0)
        //    {
        //        return NotFound("The Engaged Date is not found");
        //    }
        //    return Ok(offer); // results in 200 ok status 

        //}




        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.OfferId == id);
        }
    }
}
