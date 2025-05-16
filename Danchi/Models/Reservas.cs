namespace Danchi.Models
{
    public class Reservas
    {
        public int IdReservas { get; set; }
        public int IdResidente { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; } 

        public int NumInvitados { get; set; }
        public string Estado { get; set; }
    }
}
