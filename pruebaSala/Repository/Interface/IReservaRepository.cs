using pruebaSala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSala.Repository.Interface
{
    public interface IReservaRepository
    {
        IEnumerable<ReservaDTO> GetReservas();
        Task<ReservaDTO> GetReserva(int reserva);
        IEnumerable<Sala> GetSalasDisponibles(Reserva reserva);
        Reserva AddReserva(Reserva reserva);
        Task<ReservaDTO> UpdateReserva(Reserva reserva);
        void DeleteReserva(int ReservaId);
    }
}
