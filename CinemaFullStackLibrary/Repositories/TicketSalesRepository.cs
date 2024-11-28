﻿using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories
{
    public class TicketSalesRepository(CinemaContext context) : BaseRepository<TicketSales>(context),ITicketSalesRepository
    {
    }
}