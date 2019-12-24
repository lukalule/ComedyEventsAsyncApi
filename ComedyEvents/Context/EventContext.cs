using ComedyEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Context
{
    public class EventContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EventContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Comedian> Comedians { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
