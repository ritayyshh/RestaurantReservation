﻿namespace RestaurantReservation.DTOs.TableReservation
{
    public class TableReservationUpdateDTO
    {
        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PartySize { get; set; }
        public string SpecialRequests { get; set; } = string.Empty;
    }
}