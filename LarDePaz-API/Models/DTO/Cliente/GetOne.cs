﻿namespace LarDePaz_API.Models.DTO.Cliente
{
    public class GetOneRequest
    {
        public int Id { get; set; }
    }
    
    public class GetOneResponse
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Telefono1 { get; set; } = null!;
        public string? Telefono2 { get; set; }
        public string? Email { get; set; }
        public string? RedSocial { get; set; }
        public List<ContratoDTO> Contratos { get; set; } = [];

        public class ContratoDTO
        {
            public int Id { get; set; }
            public int SaldoExpensas { get; set; }
            public int SaldoCuota { get; set; }
            public int CantidadParcelas { get; set; }
            public string Estado { get; set; } = null!;
        }

    }

}
