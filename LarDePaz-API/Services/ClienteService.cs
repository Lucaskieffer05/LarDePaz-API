using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models;
using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Cliente;
using Microsoft.EntityFrameworkCore;
namespace LarDePaz_API.Services
{
    public class ClienteService(APIContext context)
    {
        private readonly APIContext _db = context;

        #region Métodos públicos (CRUD)
        public async Task<BaseResponse<GetAllResponse>> GetAll(GetAllRequest rq)
        {
            var response = new BaseResponse<GetAllResponse>();

            var query = _db.Cliente.AsQueryable();

            query = OrderQuery(query, rq);

            response.Data = new GetAllResponse
            {
                Clientes = await query
                    .Skip(rq.Page * rq.PageSize)
                    .Take(rq.PageSize)
                    .Select(x => new GetAllResponse.Item
                    {
                        Id = x.Id,
                        NombreApellido = x.NombreApellido,
                        DNI = x.DNI,
                        Direccion = x.Direccion,
                        Localidad = x.Localidad,
                        Provincia = x.Provincia,
                        Telefone = x.Telefono1,
                        CreatedAt = x.CreatedAt
                    })
                    .ToListAsync()
            };

            return response;

        }

        public async Task<BaseResponse<GetOneResponse>> GetOne(GetOneRequest rq)
        {
            var response = new BaseResponse<GetOneResponse>();

            var cliente = await _db.Cliente
                .AsNoTracking()
                .Where(x => x.Id == rq.Id)
                .Include(x => x.Contratos)
                .Select(x => new GetOneResponse
                {
                    Id = x.Id,
                    NombreApellido = x.NombreApellido,
                    DNI = x.DNI,
                    Direccion = x.Direccion,
                    Localidad = x.Localidad,
                    Provincia = x.Provincia,
                    Telefono1 = x.Telefono1,
                    Telefono2 = x.Telefono2,
                    Email = x.Email,
                    RedSocial = x.RedSocial,
                    Contratos = x.Contratos.Select(c => new GetOneResponse.Item
                    {
                        Id = c.Id,
                        Saldo = c.Saldo,
                        CantidadParcelas = c.CantidadParcelas,
                        Estado = c.Estado
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return response.SetError(Messages.Error.EntitiesNotFound("Cliente"));
            }

            response.Data = cliente;

            return response;
        }

        public async Task<BaseResponse<CreateResponse>> Create(CreateRequest rq)
        {
            var response = new BaseResponse<CreateResponse>();

            // Corrected the method call to pass the generic type parameter explicitly
            var validation = await ValidateCreate(rq, response);

            if (!validation)
            {
                return response;
            }

            var cliente = new Cliente
            {
                NombreApellido = rq.NombreApellido,
                DNI = rq.DNI,
                Direccion = rq.Direccion,
                Localidad = rq.Localidad,
                Provincia = rq.Provincia,
                Telefono1 = rq.Telefono1,
                Telefono2 = rq.Telefono2,
                Email = rq.Email,
                RedSocial = rq.RedSocial
            };

            _db.Cliente.Add(cliente);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return response.SetError(Messages.Error.SaveEntity("Cliente"));
            }

            response.Message = Messages.CRUD.EntityCreated("Cliente");
            return response;
        }

        public async Task<BaseResponse> Update(UpdateRequest rq)
        {
            var response = new BaseResponse();

            var cliente = await _db.Cliente
                .Where(x => x.Id == rq.Id)
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return response.SetError(Messages.Error.EntitiesNotFound("Cliente"));
            }

            var validation = await ValidateUpdate(rq, response, cliente.Id);

            if (!validation)
            {
                return response;
            }

            cliente.NombreApellido = rq.NombreApellido;
            cliente.DNI = rq.DNI;
            cliente.Direccion = rq.Direccion;
            cliente.Localidad = rq.Localidad;
            cliente.Provincia = rq.Provincia;
            cliente.Telefono1 = rq.Telefono1;
            cliente.Telefono2 = rq.Telefono2;
            cliente.Email = rq.Email;
            cliente.RedSocial = rq.RedSocial;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return response.SetError(Messages.Error.SaveEntity("Cliente"));
            }

            response.Message = Messages.CRUD.EntityUpdated("Cliente");
            return response;
        }

        public async Task<BaseResponse> Delete(DeleteRequest rq)
        {
            var response = new BaseResponse();

            var cliente = await _db.Cliente
                .Where(x => x.Id == rq.Id)
                .Include(x => x.Contratos)
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return response.SetError(Messages.Error.EntitiesNotFound("Cliente"));
            }

            if (cliente.Contratos.Any())
            {
                return response.SetError(Messages.Error.EntityWithRelations("Cliente","Contrato"));
            }


            cliente.DeletedAt = DateTime.UtcNow;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return response.SetError(Messages.Error.SaveEntity("Cliente"));
            }

            response.Message = Messages.CRUD.EntityDeleted("Cliente");
            return response;
        }
        #endregion



        #region Métodos privados
        private static IQueryable<Cliente> OrderQuery(IQueryable<Cliente> query, PaginateRequest rq)
        {
            return rq.ColumnSort switch
            {
                "nombreapellido" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.NombreApellido) : query.OrderByDescending(x => x.NombreApellido),
                "createdAt" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.NombreApellido),
            };
        }


        private async Task<bool> ValidateCreate(CreateRequest rq, BaseResponse<CreateResponse> response)
        {
            // Validar que las propiedades requeridas existan y no sean nulas
            if (string.IsNullOrEmpty(rq.NombreApellido))
            {
                response.SetError(Messages.Error.FieldRequired("Nombre y Apellido"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.DNI))
            {
                response.SetError(Messages.Error.FieldRequired("DNI"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Direccion))
            {
                response.SetError(Messages.Error.FieldRequired("Direccion"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Localidad))
            {
                response.SetError(Messages.Error.FieldRequired("Localidad"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Provincia))
            {
                response.SetError(Messages.Error.FieldRequired("Provincia"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Telefono1))
            {
                response.SetError(Messages.Error.FieldRequired("Telefono 1"));
                return false;
            }

            // Validar DNI único
            var dniExists = await _db.Cliente
                .AsNoTracking()
                .AnyAsync(x => x.DNI == rq.DNI);

            if (dniExists)
            {
                response.SetError("Ya existe este DNI");
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateUpdate(UpdateRequest rq, BaseResponse response, int id)
        {
            // Validar que las propiedades requeridas existan y no sean nulas
            if (string.IsNullOrEmpty(rq.NombreApellido))
            {
                response.SetError(Messages.Error.FieldRequired("Nombre y Apellido"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.DNI))
            {
                response.SetError(Messages.Error.FieldRequired("DNI"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Direccion))
            {
                response.SetError(Messages.Error.FieldRequired("Direccion"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Localidad))
            {
                response.SetError(Messages.Error.FieldRequired("Localidad"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Provincia))
            {
                response.SetError(Messages.Error.FieldRequired("Provincia"));
                return false;
            }

            if (string.IsNullOrEmpty(rq.Telefono1))
            {
                response.SetError(Messages.Error.FieldRequired("Telefono 1"));
                return false;
            }

            // Validar DNI único
            var dniExists = await _db.Cliente
                .AsNoTracking()
                .AnyAsync(x => x.DNI == rq.DNI && x.Id != id);

            if (dniExists)
            {
                response.SetError("Ya existe este DNI");
                return false;
            }

            return true;
        }



        #endregion


    }
}
