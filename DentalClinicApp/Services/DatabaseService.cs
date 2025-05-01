using DentalClinicApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicApp.Services
{
    internal class DatabaseService
    
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=DentalClinicDB;Username=postgres;Password=1234";

        public List<Doctor> GetDoctors()
        {
            var doctors = new List<Doctor>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Doctors", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        doctors.Add(new Doctor
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Specialization = reader.GetString(2)
                        });
                    }
                }
            }

            return doctors;
        }

        
    }
}
