using RestaurantReservation.DTOs.TableReservation;

namespace RestaurantReservation.DTOs.Table
{
    public class TableDetailsDTO
    {
        public int TableID { get; set; }
        public int SeatingCapacity { get; set; }
        public bool IsAvailable { get; set; }
        public string RestaurantName { get; set; } // Assuming Restaurant.Name exists
        public ICollection<TableReservationDTO> TableReservations { get; set; }
    }
}
