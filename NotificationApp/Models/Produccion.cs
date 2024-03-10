using System.ComponentModel.DataAnnotations;

namespace NotificationApp.Models
{
    public class Produccion
    {
        [Key]
        public int Id { get; set; }

        public int Referencia { get; set; }

        public required string? Operario { get; set; }
        public int? CantidadBuenas { get; set; }

        public int CantidadMalas { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        [Required(ErrorMessage = "Fecha Hora Fin es obligatorio")]
        public DateTime FechaHoraFin { get; set; }

        public int? GastosAdicionales { get; set; }

        public required string? Observacion { get; set; }
    }
}
