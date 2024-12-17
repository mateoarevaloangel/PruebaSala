﻿using pruebaSala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSala.Repository.Interface
{
    internal interface ISalaRepository
    {
        IEnumerable<Sala> GetSalas();
        Task<Sala> GetSala(int salaID);
        Sala AddSala(Sala sala);
        Task<Sala> UpdateSala(Sala sala);
        void DeleteSala(int salaID);
    }
}