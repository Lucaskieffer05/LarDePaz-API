using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static LarDePaz_API.Models.DTO.Contrato.GetOneResponse;

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
                        SaldoExpensas = CalcularSaldoExpensas(x.Expensas),
                        CantidadParcelas = x.Parcelas.Count,
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
                .Include(x => x.Cuotas)
                .Include(x => x.Expensas)
                .Include(x => x.Parcelas)
                .ThenInclude(x => x.Zona)
                .ThenInclude(x => x.Manzana)
                .Select(x => new GetOneResponse // Fix: Use 'new' keyword to create an instance of GetOneResponse
                {
                    Id = x.Id,
                    CobradorId = x.CobradorId,
                    TitularId = x.TitularId,
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
                    SaldoExpensas = CalcularSaldoExpensas(x.Expensas),
                    CantidadCuotas = x.CantidadCuotas,
                    CuotasEmitidas = CuotasEmitidas(x.Cuotas),
                    ImporteTotalCuotas = CalcularImporteTotalCuotas(x.Cuotas),
                    PagoAcumulado = CalcularPagoAcumuladoCuotas(x.Cuotas),
                    SaldoCuotas = CalcularSaldoCuotas(x.Cuotas),
                    CantidadParcelas = x.Parcelas.Count,
                    Estado = x.Estado,
                    GenerarExpensas = x.GenerarExpensas,
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
                    Cuotas = x.Cuotas.Select(c => new GetOneResponse.CuotaDTO
                    {
                        Id = c.Id,
                        NumeroCuota = c.NumeroCuota,
                        FechaEmitida = c.FechaEmitida,
                        FechaVencimiento = c.FechaVencimiento,
                        Importe = c.Importe,
                        ImportePagado = c.ImportePagado,
                        ImporteInteres = c.ImporteInteres,
                        ImporteTotal = c.ImporteInteres + c.Importe,
                        Estado = c.Estado
                    }).ToList(),
                    Expensas = x.Expensas.Select(e => new GetOneResponse.ExpensaDTO
                    {
                        Id = e.Id,
                        FechaDesde = e.FechaDesde,
                        FechaHasta = e.FechaHasta,
                        FechaPago = e.FechaPago,
                        NumPeriodo = e.NumPeriodo,
                        YearPeriodo = e.YearPeriodo,
                        Importe = e.Importe,
                        ImportePagado = e.ImportePagado,
                        Estado = e.Estado
                    }).ToList(),
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

        public async Task<BaseResponse<CreateResponse>> Create(CreateRequest rq)
        {
            var response = new BaseResponse<CreateResponse>();

            // Validaciones
            var validateString = ValidateCreateRequest(rq);
            if (!string.IsNullOrEmpty(validateString))
            {
                return response.SetError(Messages.Error.FieldRequired(validateString));
            }

            // Iniciar transacción
            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                // Crear el contrato
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
                    FechaContrato = DateTime.Now,
                    CantidadCuotas = rq.CantidadCuotas,
                    Estado = "Activo",
                };
                _db.Contrato.Add(contrato);
                await _db.SaveChangesAsync();

                // Crear Cuotas
                var cuotas = new List<Cuota>();
                for (int i = 1; i <= rq.CantidadCuotas; i++)
                {
                    cuotas.Add(new Cuota
                    {
                        NumeroCuota = i.ToString(),
                        FechaEmitida = DateTime.Now,
                        FechaVencimiento = DateTime.Now.AddMonths(i), // Ejemplo: una cuota por mes
                        Importe = rq.PrecioTotalDeCompra / rq.CantidadCuotas, // Asigna el importe de la cuota
                        ImportePagado = 0,
                        ImporteInteres = 0,
                        Estado = "Pendiente",
                        ContratoId = contrato.Id
                    });
                }
                _db.Cuota.AddRange(cuotas);
                await _db.SaveChangesAsync();


                // Confirmar transacción
                await tx.CommitAsync();

                response.Data = new CreateResponse { Id = contrato.Id };
                return response;
            }
            catch (Exception ex)
            {
                // Revertir cambios en caso de error
                await tx.RollbackAsync();
                return response.SetError($"Error al crear el contrato: {ex.Message}");
            }
        }

        public async Task<BaseResponse> Update(UpdateRequest rq)
        {
            var response = new BaseResponse();
            // Validaciones
            var validateString = ValidateUpdateRequest(rq);
            if (!string.IsNullOrEmpty(validateString))
            {
                return response.SetError(Messages.Error.FieldRequired(validateString));
            }

            
            // Obtener el contrato existente
            var contrato = await _db.Contrato
                .Where(x => x.Id == rq.Id)
                .FirstOrDefaultAsync();

            if (contrato == null)
            {
                return response.SetError(Messages.Error.EntitiesNotFound("Contrato"));
            }
            // Actualizar los campos del contrato
            contrato.CobradorId = rq.CobradorId;
            contrato.TitularId = rq.TitularId;
            contrato.NombreCoTitular = rq.NombreCoTitular;
            contrato.DNICoTitular = rq.DNICoTitular;
            contrato.DireccionCoTitular = rq.DireccionCoTitular;
            contrato.LocalidadCoTitular = rq.LocalidadCoTitular;
            contrato.ProvinciaCoTitular = rq.ProvinciaCoTitular;
            contrato.TelefonoCoTitular = rq.TelefonoCoTitular;
            contrato.TelefonoCoTitular2 = rq.TelefonoCoTitular2;
            contrato.EmailCoTitular = rq.EmailCoTitular;
            contrato.RedSocialCoTitular = rq.RedSocialCoTitular;
            contrato.NombreSegundoTitular = rq.NombreSegundoTitular;
            contrato.DNISegundoTitular = rq.DNISegundoTitular;
            contrato.DireccionSegundoTitular = rq.DireccionSegundoTitular;
            contrato.LocalidadSegundoTitular = rq.LocalidadSegundoTitular;
            contrato.ProvinciaSegundoTitular = rq.ProvinciaSegundoTitular;
            contrato.TelefonoSegundoTitular = rq.TelefonoSegundoTitular;
            contrato.TelefonoSegundoTitular2 = rq.TelefonoSegundoTitular2;
            contrato.EmailSegundoTitular = rq.EmailSegundoTitular;
            contrato.RedSocialSegundoTitular = rq.RedSocialSegundoTitular;
            contrato.LugarPago = rq.LugarPago;
            contrato.DireccionPago = rq.DireccionPago;
            contrato.LocalidadPago = rq.LocalidadPago;
            contrato.ProvinciaPago = rq.ProvinciaPago;
            contrato.Tarjeta = rq.Tarjeta;

            try
            {
                _db.Contrato.Update(contrato);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return response.SetError(Messages.Error.Exception());
            }

            response.Message = Messages.CRUD.EntityUpdated("Contrato");
            return response;
        }

        #endregion


        #region Métodos privados
        private static IQueryable<Contrato> OrderQuery(IQueryable<Contrato> query, PaginateRequest rq)
        {
            return rq.ColumnSort switch
            {
                "estado" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.Estado) : query.OrderByDescending(x => x.Estado),
                "nombreapellido" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.Titular.NombreApellido) : query.OrderByDescending(x => x.Titular.NombreApellido),
                "createdAt" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.CreatedAt),
            };
        }
        private string ValidateCreateRequest(CreateRequest rq)
        {
            if (rq.TitularId <= 0)
            {
                return "Cobrador";
            }
            if (string.IsNullOrEmpty(rq.NombreCoTitular))
            {
                return "Nombre del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.DNICoTitular))
            {
                return "DNI del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.DireccionCoTitular))
            {
                return "Dirección del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.LocalidadCoTitular))
            {
                return "Localidad del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.ProvinciaCoTitular))
            {
                return "Provincia del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.TelefonoCoTitular))
            {
                return "Teléfono del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.LugarPago))
            {
                return "Lugar de Pago";
            }
            if (string.IsNullOrEmpty(rq.DireccionPago))
            {
                return "Dirección de Pago";
            }
            if (string.IsNullOrEmpty(rq.LocalidadPago))
            {
                return "Localidad de Pago";
            }
            if (string.IsNullOrEmpty(rq.ProvinciaPago))
            {
                return "Provincia de Pago";
            }

            // Si todas las validaciones pasan, devolver una cadena vacía
            return string.Empty;
        }
        private string ValidateUpdateRequest(UpdateRequest rq) {
            if (rq.TitularId <= 0)
            {
                return "Cobrador";
            }
            if (string.IsNullOrEmpty(rq.NombreCoTitular))
            {
                return "Nombre del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.DNICoTitular))
            {
                return "DNI del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.DireccionCoTitular))
            {
                return "Dirección del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.LocalidadCoTitular))
            {
                return "Localidad del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.ProvinciaCoTitular))
            {
                return "Provincia del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.TelefonoCoTitular))
            {
                return "Teléfono del CoTitular";
            }
            if (string.IsNullOrEmpty(rq.LugarPago))
            {
                return "Lugar de Pago";
            }
            if (string.IsNullOrEmpty(rq.DireccionPago))
            {
                return "Dirección de Pago";
            }
            if (string.IsNullOrEmpty(rq.LocalidadPago))
            {
                return "Localidad de Pago";
            }
            if (string.IsNullOrEmpty(rq.ProvinciaPago))
            {
                return "Provincia de Pago";
            }

            // Si todas las validaciones pasan, devolver una cadena vacía
            return string.Empty;
        }
        private int CalcularSaldoExpensas(List<Expensa> expensas)
        {
            return expensas.Sum(e => e.Importe) - expensas.Sum(e => e.ImportePagado);
        }
        private int CalcularSaldoCuotas(List<Cuota> cuotas)
        {
            return cuotas.Count(e => e.Estado == "Pendiente") > 0 ? cuotas.Sum(e => e.Importe + e.ImporteInteres) - cuotas.Sum(e => e.ImportePagado) : 0;
        }
        private int CuotasEmitidas(List<Cuota> cuotas)
        {
            return cuotas.Count(c => c.Estado == "Emitida");
        }
        private int CalcularPagoAcumuladoCuotas(List<Cuota> cuotas)
        {
            return cuotas.Sum(c => c.ImportePagado);
        }
        private int CalcularImporteTotalCuotas (List<Cuota> cuotas)
        {
            return cuotas.Sum(c => c.Importe + c.ImporteInteres);
        }
        private List<Cuota> CrearCuotas(int cantidadCuotas, int precioTotalDeCompra, int contratoId)
        {
            var cuotas = new List<Cuota>();
            for (int i = 1; i <= cantidadCuotas; i++)
            {
                cuotas.Add(new Cuota
                {
                    NumeroCuota = i.ToString(),
                    FechaEmitida = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddMonths(i), // Ejemplo: una cuota por mes
                    Importe = precioTotalDeCompra / cantidadCuotas, // Asigna el importe de la cuota
                    ImportePagado = 0,
                    ImporteInteres = 0,
                    Estado = "Pendiente",
                    ContratoId = contratoId
                });
            }
            return cuotas;
        }
        #endregion
    }
}
