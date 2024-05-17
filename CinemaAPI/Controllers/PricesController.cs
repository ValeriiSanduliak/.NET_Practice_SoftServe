using System.IO;
using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public PricesController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<PriceDTO>>> onGetAsync()
        //{
        //    var prices = await appDbContext
        //        .Prices.Include(p => p.Movie)
        //        .Include(p => p.SeatReservation)
        //        .ToListAsync();

        //    var priceDTOs = prices
        //        .Select(priceDTO => new PriceDTO
        //        {
        //            ScreenwriterId = screenwriter.ScreenwriterId,
        //            ScreenwriterFullName = screenwriter.ScreenwriterFullName,
        //            Movie = price
        //                .Mov.Select(md => new EntityWithMovieList
        //                {
        //                    MovieId = md.MovieId,
        //                    MovieTitle = md.Movie.MovieTitle
        //                })
        //                .ToList()
        //        })
        //        .ToList();

        //    return Ok(priceDTOs);
        //}
        [HttpGet]
        public async Task<ActionResult<List<PriceDTO>>> onGetAsync()
        {
            var prices = await appDbContext
                .Prices.Include(p => p.Movie)
                .Include(p => p.SeatReservation)
                .ToListAsync();

            if (prices == null)
            {
                return NoContent();
            }

            var priceDTOs = prices
                .Select(price => new PriceDTO
                {
                    PriceId = price.PriceId,
                    Price1 = price.Price1,
                    Movie = new EntityWithMovieList
                    {
                        MovieId = price.Movie.MovieId,
                        MovieTitle = price.Movie.MovieTitle
                    },
                    SeatReservation = new SeatReservationDTO
                    {
                        SeatReservationId = price.SeatReservation.SeatReservationId,
                        HallId = price.SeatReservation.HallId,
                        RowNumber = price.SeatReservation.RowNumber,
                        SeatNumber = price.SeatReservation.SeatNumber,
                        IsReserved = price.SeatReservation.IsReserved
                    }
                })
                .ToList();

            return Ok(priceDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceDTO>> onGetAsync(int id)
        {
            var price = await appDbContext
                .Prices.Include(p => p.Movie)
                .Include(p => p.SeatReservation)
                .FirstOrDefaultAsync(p => p.PriceId == id);

            if (price == null)
            {
                return NotFound();
            }

            var priceDTO = new PriceDTO
            {
                PriceId = price.PriceId,
                Price1 = price.Price1,
                Movie = new EntityWithMovieList
                {
                    MovieId = price.Movie.MovieId,
                    MovieTitle = price.Movie.MovieTitle
                },
                SeatReservation = new SeatReservationDTO
                {
                    SeatReservationId = price.SeatReservation.SeatReservationId,
                    HallId = price.SeatReservation.HallId,
                    RowNumber = price.SeatReservation.RowNumber,
                    SeatNumber = price.SeatReservation.SeatNumber,
                    IsReserved = price.SeatReservation.IsReserved
                }
            };

            return Ok(priceDTO);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<PricePostDTO>> onPostAsync(
            [FromBody] PricePostDTO pricePostDTO
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var price = new Price
            {
                Price1 = pricePostDTO.Price,
                MovieId = pricePostDTO.MovieId,
                SeatReservationId = pricePostDTO.SeatReservationId
            };

            appDbContext.Prices.Add(price);
            await appDbContext.SaveChangesAsync();

            //return CreatedAtAction(nameof(onGetAsync), new { id = price.PriceId }, price);
            var createdPrice = await appDbContext.Prices.FindAsync(price.PriceId);

            if (createdPrice != null)
            {
                return StatusCode(201, createdPrice);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<PricePatchDTO>> OnPatchAsync(
            int id,
            [FromBody] PricePatchDTO pricePatchDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingPrice = await appDbContext.Prices.FindAsync(id);
                if (existingPrice == null)
                {
                    return NotFound();
                }

                if (pricePatchDTO.Price != null)
                {
                    existingPrice.Price1 = (int)pricePatchDTO.Price;
                }

                if (pricePatchDTO.MovieId != null)
                {
                    existingPrice.MovieId = (int)pricePatchDTO.MovieId;
                }

                if (pricePatchDTO.SeatReservationId != null)
                {
                    existingPrice.SeatReservationId = (int)pricePatchDTO.SeatReservationId;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingPrice);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict($"Price with id {id} not found.");
            }
        }
    }
}
