
namespace Danchi.Models
{
    public class FormularioAsistencia
    {
        public int IdFormulario { get; set; }
        public int IdResidente { get; set; }
        public string NombreResidente { get; set; }
        public string CorreoResidente { get; set; }
        public string TelefonoResidente { get; set; }
        public string NumApartResidente { get; set;}
        public DateTime Fecha { get; set; }
    }
}
