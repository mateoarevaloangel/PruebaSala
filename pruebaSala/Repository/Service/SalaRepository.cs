using Dapper;
using pruebaSala.Models;
using pruebaSala.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace pruebaSala.Repository.Service
{
    public class SalaRepository : ISalaRepository
    {
        IDbConnection _connection;

        readonly string connectionString = "Data Source=DESKTOP-HRBLSGJ\\SQLEXPRESS; Initial Catalog = PruebaDB; User ID = userPrueba2; Password = 123;Trusted_Connection=SSPI;MultipleActiveResultSets=true;";
        public SalaRepository()
        {
            _connection = new SqlConnection(connectionString);
        }
        public Sala AddSala(Sala sala)
        {
            string insertQuery = @"EXEC AddSala @Nombre, @Descripcion,@Capacidad;";
            try
            {
                // TODO: Add insert logic here
                var result = _connection.Execute(insertQuery, new
                {
                    sala.Nombre,
                    sala.Descripcion,
                    sala.Capacidad
                });
                return sala;
            }
            catch
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        public void DeleteSala(int salaID)
        {
            throw new NotImplementedException();
        }

        public Sala GetSala(int salaID)
        {
            var storedProcedureName = "SelectByIDSalas";
            var values = new { ID = salaID };
            var results = _connection.Query<Sala>(storedProcedureName, values, commandType: CommandType.StoredProcedure).ToList();
            return results[0];
        }

        public IEnumerable<Sala> GetSalas()
        {
            var queryReservaciones = "EXEC SelectAllSalas;";
            return _connection.Query<Sala>(queryReservaciones);
        }

        public Sala UpdateSala(Sala sala)
        {
            string insertQuery = @"EXEC UpdateSala @Nombre, @Descripcion,@Capacidad, @ID;";
            try
            {
                // TODO: Add insert logic here
                var result = _connection.Execute(insertQuery, new
                {
                    sala.Nombre,
                    sala.Descripcion,
                    sala.Capacidad,
                    sala.ID
                });
                return sala;
            }
            catch
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}