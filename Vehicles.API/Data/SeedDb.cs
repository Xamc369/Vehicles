using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.Common.Enum;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypesAsync();
            await CheckBrandsAsync();
            await CheckDocuemntTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1719735951", "Ximena", "Moreno", "xime@yopmail.com", "3398028", "Prados del Condado", UserType.Admin);
            await CheckUserAsync("1705148730", "Dennis", "Arias", "dennis@yopmail.com", "3380519", "Carcelen", UserType.User);
            await CheckUserAsync("1801059831", "Irma", "Munoz", "irma@yopmail.com", "667776", "La Magdalena", UserType.User);
        }


        //asi se crean los usuarios
        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Adress = address,
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(z => z.Description == "CEDULA"),
                    Email = email,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención delantera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención trasera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación carburador" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite motor" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite caja" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Guayas" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Reparación de motor" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Kit arrastre" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Banda transmisión" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio batería" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavada de tanque" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio de bujia" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Accesorios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocuemntTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "CEDULA" });
                _context.DocumentTypes.Add(new DocumentType { Description = "TARJETA DE IDENTIDAD" });
                _context.DocumentTypes.Add(new DocumentType { Description = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Description = "PASAPORTE" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "DUCATI" });
                _context.Brands.Add(new Brand { Description = "HARLEY DAVIDSON" });
                _context.Brands.Add(new Brand { Description = "BMW" });
                _context.Brands.Add(new Brand { Description = "NISSAN" });
                _context.Brands.Add(new Brand { Description = "KIA" });
                _context.Brands.Add(new Brand { Description = "SHANGAN" });
                _context.Brands.Add(new Brand { Description = "TOYOTA" });
                _context.Brands.Add(new Brand { Description = "CHEVROLET" });
                _context.Brands.Add(new Brand { Description = "MAZDA" });
                _context.Brands.Add(new Brand { Description = "JAC" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehicleTypesAsync()
        {
            if (! _context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "CARRO" });
                _context.VehicleTypes.Add(new VehicleType { Description = "MOTO" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
