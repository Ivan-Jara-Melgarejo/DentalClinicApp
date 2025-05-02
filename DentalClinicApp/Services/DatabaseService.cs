using Npgsql;
using System.Collections.Generic;
using DentalClinicApp.Models;

namespace DentalClinicApp.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Host=dentalclinicdb.c5ogic2eeexi.us-east-2.rds.amazonaws.com;Port=5432;Database=DentalClinicDB;Username=admin_clinic;Password=SecurePass123";
        //USA LOCALHOST si tengo apagado el servidor son 780 hrs gratis pendejo...
        //private readonly string _connectionString = "Host=localhost;Port=5432;Database=DentalClinicDB;Username=admin_clinic;Password=SecurePass123";

        public List<Doctor> GetDoctors()
        {
            var doctors = new List<Doctor>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM doctors", conn))
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