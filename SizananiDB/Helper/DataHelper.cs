using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SizananiDB.Data;
using SizananiDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Helper
{
    public class DataHelper
    {
        public VehicleManagementContext _context;

        public DataHelper(VehicleManagementContext context)
        {
            _context = context;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> list;
            string sql = "EXEC dbo.GetVechiles";
            list = _context.Vehicles.FromSqlRaw<Vehicle>(sql).ToList();

            return list;
        }
        

        public bool AddVehicle(string registration, string model, int weight)
        {
            try
            {
                string sql = "EXEC dbo.CreateVehicle @RegistrationNumber, @Model, @Weight";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@RegistrationNumber", Value = registration },
                    new SqlParameter { ParameterName = "@Model", Value = model },
                    new SqlParameter { ParameterName = "@Weight", Value = weight }
                };

                _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Contractor> GetContractors()
        {
            List<Contractor> list;
            string sql = "EXEC dbo.GetContractors";
            list = _context.Contractors.FromSqlRaw<Contractor>(sql).ToList();

            return list;
        }

        public bool AddContractor(string name, string email, string phoneNumber)
        {
            try
            {
                string sql = "EXEC dbo.CreateContractor @Name, @Email, @PhoneNumber";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@Name", Value = name },
                    new SqlParameter { ParameterName = "@Email", Value = email },
                    new SqlParameter { ParameterName = "@PhoneNumber", Value = phoneNumber }
                };

                _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Vehicle> GetContractorVehicles(int id)
        {
            List<Vehicle> list;
            string sql = "EXEC dbo.GetContractorsVehicles @ContractorId";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@ContractorId", Value = id },
            };

            list = _context.Vehicles.FromSqlRaw<Vehicle>(sql, parms.ToArray()).ToList();

            return list;
        }

        public bool LinkVehicleToContractor(int vehicleId, int contractorId)
        {
            try
            {
                string sql = "EXEC dbo.LinkVehicleToContractor @VehicleId, @ContactorId";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@VehicleId", Value = vehicleId },
                    new SqlParameter { ParameterName = "@ContactorId", Value = contractorId },
                };

                _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
