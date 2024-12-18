using Dapper;
using pruebaSala.Models;
using pruebaSala.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
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
            //throw new NotImplementedException();
            string insertQuery = @"EXEC DeleteReserva @ID;";
            try
            {
                // TODO: Add insert logic here
                var result = _connection.Execute(insertQuery, new
                {
                    ID=ReservaId
                });
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public Reserva GetReserva(int reserva)
        {
            var storedProcedureName = "SelectByIDReservas";
            var values = new { ID = reserva };
            var results = _connection.Query<Reserva>(storedProcedureName, values, commandType: CommandType.StoredProcedure).ToList();
            return results[0];
        }

        public IEnumerable<ReservaDTO> GetReservas()
        {
            var queryReservaciones = "EXEC SelectAllReservas;";
            return _connection.Query<ReservaDTO>(queryReservaciones);
            
        }
        public IEnumerable<Sala> GetSalasDisponibles(Reserva reserva)
        {
            var storedProcedureName = "DisponibilidadReserva";
            var values = new { Nombre = reserva.Nombre, Fecha = reserva.Fecha };
            var results = _connection.Query<Sala>(storedProcedureName, values, commandType: CommandType.StoredProcedure).ToList();
            return results;

        }

        public Reserva UpdateReserva(Reserva reserva)
        {
            string insertQuery = @"EXEC UpdateReserva @Nombre, @Fecha, @SalaID, @ID;";
            try
            {
                // TODO: Add insert logic here
                var result = _connection.Execute(insertQuery, new
                {
                    reserva.Nombre,
                    reserva.Fecha,
                    reserva.SalaID,
                    reserva.Id
                });
                return reserva;
            }
            catch
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}