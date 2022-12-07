using pim_desktop.Enums;

namespace pim_desktop.Model
{
    public class AutomovelModel
    {
        public int? Id { get; set; }
        public int? IdCliente { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public string? AnoModelo { get; set; }
        public string? Cor { get; set; }
        public string? Placa { get; set; }
        public string? Renavam { get; set; }
        public string? NumeroMotor { get; set; }
        public string? Crlv { get; set; }
        public Status? Status { get; set; }
    }
}
