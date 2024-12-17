using Dapper;
using pruebaSala.Models;
using pruebaSala.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace pruebaSala.Repository.Service
{
    public class ReservaRepository : IReservaRepository
    {
        IDbConnection _connection;

        readonly string connectionString = "Data Source=DESKTOP-HRBLSGJ\\SQLEXPRESS; Initial Catalog = PruebaDB; User ID = userPrueba2; Password = 123;Trusted_Connection=SSPI;MultipleActiveResultSets=true;";
        //var DBConnection = 
        public ReservaRepository()
        {
            _connection = new SqlConnection(connectionString);
        }

        public Reserva AddReserva(Reserva reserva)
        {
            //string insertQuery = @"INSERT INTO [dbo].[Customer]([FirstName], [LastName], [State], [City], [IsActive], [CreatedOn]) VALUES (@FirstName, @LastName, @State, @City, @IsActive, @CreatedOn)";
            string insertQuery = @"EXEC AddReserva @Nombre, @Fecha,@SalaID;";            
            try
            {
                // TODO: Add insert logic here
                var result = _connection.Execute(insertQuery, new
                {
                    reserva.Nombre,
                    reserva.Fecha,
                    reserva.SalaID
                });
                return reserva;
            }
            catch
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        public void DeleteReserva(int ReservaId)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaDTO> GetReserva(int reserva)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservaDTO> GetReservas()
        {
            var queryReservaciones = "EXEC SelectAllReservas;";
            return _connection.Query<ReservaDTO>(queryReservaciones);
            
        }

        public Task<ReservaDTO> UpdateReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}