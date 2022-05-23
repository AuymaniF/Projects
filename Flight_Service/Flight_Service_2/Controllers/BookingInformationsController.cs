using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flight_Service.Data;
using Flight_Service.Models;

namespace Flight_Service_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingInformationsController : ControllerBase
    {
        private readonly FSContext _context;

        public BookingInformationsController(FSContext context)
        {
            _context = context;
        }

        // GET: api/BookingInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingInformation>>> GetBookings()
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/BookingInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingInformation>> GetBookingInformation(int id)
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            var bookingInformation = await _context.Bookings.FindAsync(id);

            if (bookingInformation == null)
            {
                return NotFound();
            }

            return bookingInformation;
        }

        // PUT: api/BookingInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingInformation(int id, BookingInformation bookingInformation)
        {
            if (id != bookingInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingInformationExists(id))
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

        // POST: api/BookingInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingInformation>> PostBookingInformation(BookingInformation bookingInformation)
        {
          if (_context.Bookings == null)
          {
              return Problem("Entity set 'FSContext.Bookings'  is null.");
          }
            _context.Bookings.Add(bookingInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingInformation", new { id = bookingInformation.Id }, bookingInformation);
        }

        // DELETE: api/BookingInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingInformation(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var bookingInformation = await _context.Bookings.FindAsync(id);
            if (bookingInformation == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(bookingInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingInformationExists(int id)
        {
            return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
