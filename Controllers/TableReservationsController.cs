﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Data;
using RestaurantReservation.DTOs;
using RestaurantReservation.DTOs.TableReservation;
using RestaurantReservation.Models;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableReservationsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TableReservationsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TableReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableReservationDetailsDTO>>> GetTableReservations()
        {
            var reservations = await _context.TableReservations
                .Include(tr => tr.Table)
                .ThenInclude(t => t.Restaurant)
                .Select(tr => new TableReservationDetailsDTO
                {
                    TableReservationID = tr.TableReservationID,
                    TableID = tr.TableID,
                    RestaurantID = tr.RestaurantID,
                    Username = tr.Username,
                    ReservationDate = tr.ReservationDate,
                    StartTime = tr.StartTime,
                    EndTime = tr.EndTime,
                    PartySize = tr.PartySize,
                    SpecialRequests = tr.SpecialRequests
                })
                .ToListAsync();

            return Ok(reservations);
        }

        // GET: api/TableReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableReservationDetailsDTO>> GetTableReservation(int id)
        {
            var reservation = await _context.TableReservations
                .Include(tr => tr.Table)
                .ThenInclude(t => t.Restaurant)
                .Where(tr => tr.TableReservationID == id)
                .Select(tr => new TableReservationDetailsDTO
                {
                    TableReservationID = tr.TableReservationID,
                    TableID = tr.TableID,
                    RestaurantID = tr.RestaurantID,
                    Username = tr.Username,
                    ReservationDate = tr.ReservationDate,
                    StartTime = tr.StartTime,
                    EndTime = tr.EndTime,
                    PartySize = tr.PartySize,
                    SpecialRequests = tr.SpecialRequests
                })
                .FirstOrDefaultAsync();

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/TableReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableReservation(int id, TableReservationUpdateDTO updateDTO)
        {
            var reservation = await _context.TableReservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.TableID = updateDTO.TableID;
            reservation.RestaurantID = updateDTO.RestaurantID;
            reservation.ReservationDate = updateDTO.ReservationDate;
            reservation.StartTime = updateDTO.StartTime;
            reservation.EndTime = updateDTO.EndTime;
            reservation.PartySize = updateDTO.PartySize;
            reservation.SpecialRequests = updateDTO.SpecialRequests;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableReservationExists(id))
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

        // POST: api/TableReservations
        [HttpPost]
        public async Task<ActionResult<TableReservation>> PostTableReservation(TableReservationCreateDTO createDTO)
        {
            var tableReservation = new TableReservation
            {
                TableID = createDTO.TableID,
                UserID = createDTO.UserID,
                Username = createDTO.Username,
                RestaurantID = createDTO.RestaurantID,
                ReservationDate = createDTO.ReservationDate,
                StartTime = createDTO.StartTime,
                EndTime = createDTO.EndTime,
                PartySize = createDTO.PartySize,
                SpecialRequests = createDTO.SpecialRequests
            };

            _context.TableReservations.Add(tableReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTableReservation), new { id = tableReservation.TableReservationID }, tableReservation);
        }

        // DELETE: api/TableReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableReservation(int id)
        {
            var reservation = await _context.TableReservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.TableReservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableReservationExists(int id)
        {
            return _context.TableReservations.Any(e => e.TableReservationID == id);
        }
    }
}