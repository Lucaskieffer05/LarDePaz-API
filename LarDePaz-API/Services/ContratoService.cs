using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Contrato;
using Microsoft.EntityFrameworkCore;

namespace LarDePaz_API.Services
{
    public class ContratoService(APIContext context)
    {
        private readonly APIContext _db = context;

        #region Métodos públicos
        public async Task<BaseResponse<GetAllResponse>> GetAll(GetAllRequest rq)
        {
            var response = new BaseResponse<GetAllResponse>();
            
            var query = _db.Contrato.AsQueryable();

            query = OrderQuery(query, rq);

            response.Data = new GetAllResponse
            {
                Contratos = await query
                    .Skip(rq.Page * rq.PageSize)
                    .Take(rq.PageSize)
                    .Select(x => new GetAllResponse.ContratoDTO
                    {
                        Id = x.Id,
                        CobradorId = x.CobradorId,
                        TitularId = x.TitularId,
                        NombreCoTitular = x.NombreCoTitular,
                        NombreSegundoTitular = x.NombreSegundoTitular,
                        FechaContrato = x.FechaContrato,
                        Saldo = x.Saldo,
                        CantidadParcelas = x.CantidadParcelas,
                        Estado = x.Estado
                    })
                    .ToListAsync()

            };

            return response;
        }

        public async Task<BaseResponse<GetOneResponse>> GetOne(GetOneRequest rq)
        {
            var response = new BaseResponse<GetOneResponse>();

            var contrato = await _db.Contrato
                .AsNoTracking()
                .Where(x => x.Id == rq.Id)
                .Include(x => x.Titular)
                .Include(x => x.Cobrador)
                .Include(x => x.ContratoCuotaHistorial)
                .ThenInclude(x => x.Cuotas)
                .Include(x => x.ContratoExpensasHistorial)
                .ThenInclude(x => x.Expensas)
                .Include(x => x.Parcelas)
                .ThenInclude(x => x.Zona)
                .ThenInclude(x => x.Manzana)
                .Select(x => new GetOneResponse // Fix: Use 'new' keyword to create an instance of GetOneResponse
                {
                    Id = x.Id,
                    CobradorId = x.CobradorId,
                    TitularId = x.TitularId,
                    ContratoCuotaHistorialId = x.ContratoCuotaHistorialId,
                    ContratoExpensasHistorialId = x.ContratoExpensasHistorialId,
                    NombreCoTitular = x.NombreCoTitular,
                    DNICoTitular = x.DNICoTitular,
                    DireccionCoTitular = x.DireccionCoTitular,
                    LocalidadCoTitular = x.LocalidadCoTitular,
                    ProvinciaCoTitular = x.ProvinciaCoTitular,
                    TelefonoCoTitular = x.TelefonoCoTitular,
                    TelefonoCoTitular2 = x.TelefonoCoTitular2,
                    EmailCoTitular = x.EmailCoTitular,
                    RedSocialCoTitular = x.RedSocialCoTitular,
                    NombreSegundoTitular = x.NombreSegundoTitular,
                    DNISegundoTitular = x.DNISegundoTitular,
                    DireccionSegundoTitular = x.DireccionSegundoTitular,
                    LocalidadSegundoTitular = x.LocalidadSegundoTitular,
                    ProvinciaSegundoTitular = x.ProvinciaSegundoTitular,
                    TelefonoSegundoTitular = x.TelefonoSegundoTitular,
                    TelefonoSegundoTitular2 = x.TelefonoSegundoTitular2,
                    EmailSegundoTitular = x.EmailSegundoTitular,
                    RedSocialSegundoTitular = x.RedSocialSegundoTitular,
                    LugarPago = x.LugarPago,
                    DireccionPago = x.DireccionPago,
                    LocalidadPago = x.LocalidadPago,
                    ProvinciaPago = x.ProvinciaPago,
                    Tarjeta = x.Tarjeta,
                    FechaContrato = x.FechaContrato,
                    Saldo = x.Saldo,
                    CantidadCuotas = x.CantidadCuotas,
                    CuotasEmitidas = x.CuotasEmitidas,
                    PagoAcumulado = x.PagoAcumulado,
                    CantidadParcelas = x.CantidadParcelas,
                    Estado = x.Estado,
                    Titular = new GetOneResponse.ClienteDTO
                    {
                        Id = x.Titular.Id,
                        NombreApellido = x.Titular.NombreApellido,
                        DNI = x.Titular.DNI,
                        Direccion = x.Titular.Direccion,
                        Localidad = x.Titular.Localidad,
                        Provincia = x.Titular.Provincia,
                        Telefono1 = x.Titular.Telefono1,
                        Telefono2 = x.Titular.Telefono2,
                        Email = x.Titular.Email,
                        RedSocial = x.Titular.RedSocial
                    },
                    Cobrador = x.Cobrador == null ? null : new GetOneResponse.CobradorDTO
                    {
                        Id = x.Cobrador.Id,
                        NombreApellido = x.Cobrador.NombreApellido,
                        DNI = x.Cobrador.DNI,
                        Telefono = x.Cobrador.Telefono,
                        ZonaDeCobro = x.Cobrador.ZonaDeCobro
                    },
                    ContratoCuotaHistorial = new GetOneResponse.ContratoCuotaHistorialDTO
                    {
                        Id = x.ContratoCuotaHistorial.Id,
                        ImporteTotalPagado = x.ContratoCuotaHistorial.ImporteTotalPagado,
                        ImporteTotalCuota = x.ContratoCuotaHistorial.ImporteTotalCuota,
                        Saldo = x.ContratoCuotaHistorial.Saldo,
                        Cuotas = x.ContratoCuotaHistorial.Cuotas.Select(c => new GetOneResponse.ContratoCuotaHistorialDTO.CuotaDTO
                        {
                            Id = c.Id,
                            NumeroCuota = c.NumeroCuota,
                            FechaEmitida = c.FechaEmitida,
                            FechaVencimiento = c.FechaVencimiento,
                            FechaPago = c.FechaPago,
                            Importe = c.Importe,
                            importePagado = c.importePagado,
                            ImporteInteres = c.ImporteInteres,
                            ImporteTotal = c.ImporteTotal,
                            Estado = c.Estado
                        }).ToList()
                    },
                    ContratoExpensasHistorial = new GetOneResponse.ContratoExpensasHistorialDTO
                    {
                        Id = x.ContratoExpensasHistorial.Id,
                        ImporteTotalPagado = x.ContratoExpensasHistorial.ImporteTotalPagado,
                        ImporteTotalExpensa = x.ContratoExpensasHistorial.ImporteTotalExpensa,
                        Saldo = x.ContratoExpensasHistorial.Saldo,
                        Expensas = x.ContratoExpensasHistorial.Expensas.Select(e => new GetOneResponse.ContratoExpensasHistorialDTO.ExpensaDTO
                        {
                            Id = e.Id,
                            NumPeriodo = e.NumPeriodo,
                            YearPeriodo = e.YearPeriodo,
                            Importe = e.Importe,
                            ImportePagado = e.ImportePagado,
                            FechaDesde = e.FechaDesde,
                            FechaHasta = e.FechaHasta,
                            FechaPago = e.FechaPago,
                            Estado = e.Estado
                        }).ToList()
                    },
                    Parcelas = x.Parcelas.Select(p => new GetOneResponse.ParcelaDTO
                    {
                        Id = p.Id,
                        Fila = p.Fila,
                        Columna = p.Columna,
                        Zona = new GetOneResponse.ParcelaDTO.ZonaDTO
                        {
                            Numero = p.Zona.Numero,
                            NombreDescriptivo = p.Zona.NombreDescriptivo,
                            Manzana = new GetOneResponse.ParcelaDTO.ZonaDTO.MonzanaDTO
                            {
                                Nombre = p.Zona.Manzana.Nombre,
                                Descripcion = p.Zona.Manzana.Descripcion
                            }
                        }
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (contrato == null)
            {
                return response.SetError("Contrato no encontrado");
            }

            response.Data = contrato;
            return response;
        }

        public async Task<BaseResponse<CreateResponse> Create(CreateRequest rq)
        {
            // TO-DO HACER TODO ESTE EL PROCESO DE CREACION DE UN CONTRATO
            // 1. CREAR TODAS LAS ENTIDADES, HISTORIALES, ETC
            // 2. CREAR EL CONTRATO

            var response = new BaseResponse<CreateResponse>();
            var contrato = new Contrato
            {
                CobradorId = rq.CobradorId,
                TitularId = rq.TitularId,
                NombreCoTitular = rq.NombreCoTitular,
                DNICoTitular = rq.DNICoTitular,
                DireccionCoTitular = rq.DireccionCoTitular,
                LocalidadCoTitular = rq.LocalidadCoTitular,
                ProvinciaCoTitular = rq.ProvinciaCoTitular,
                TelefonoCoTitular = rq.TelefonoCoTitular,
                TelefonoCoTitular2 = rq.TelefonoCoTitular2,
                EmailCoTitular = rq.EmailCoTitular,
                RedSocialCoTitular = rq.RedSocialCoTitular,
                NombreSegundoTitular = rq.NombreSegundoTitular,
                DNISegundoTitular = rq.DNISegundoTitular,
                DireccionSegundoTitular = rq.DireccionSegundoTitular,
                LocalidadSegundoTitular = rq.LocalidadSegundoTitular,
                ProvinciaSegundoTitular = rq.ProvinciaSegundoTitular,
                TelefonoSegundoTitular = rq.TelefonoSegundoTitular,
                TelefonoSegundoTitular2 = rq.TelefonoSegundoTitular2,
                EmailSegundoTitular = rq.EmailSegundoTitular,
                RedSocialSegundoTitular = rq.RedSocialSegundoTitular,
                LugarPago = rq.LugarPago,
                DireccionPago = rq.DireccionPago,
                LocalidadPago = rq.LocalidadPago,
                ProvinciaPago = rq.ProvinciaPago,
                Tarjeta = rq.Tarjeta,
                FechaContrato = DateTime.Now, // Asignar la fecha actual
                Saldo = 0, // Inicializar el saldo a 0
                CantidadCuotas = 0, // Inicializar la cantidad de cuotas a 0
                CuotasEmitidas = 0, // Inicializar las cuotas emitidas a 0
                PagoAcumulado = 0, // Inicializar el pago acumulado a 0
                CantidadParcelas = 0, // Inicializar la cantidad de parcelas a 0
                Estado = "Activo" // Asignar un estado inicial
            };
            _db.Contrato.Add(contrato);
            await _db.SaveChangesAsync();
            return response;
        }


        #endregion



        private static IQueryable<Contrato> OrderQuery(IQueryable<Contrato> query, PaginateRequest rq)
        {
            return rq.ColumnSort switch
            {
                "estado" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.Estado) : query.OrderByDescending(x => x.Estado),
                "saldo" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.Saldo) : query.OrderByDescending(x => x.Saldo),
                "createdAt" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.CreatedAt),
            };
        }

    }
}
