using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace AM.Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder) { 
            
            builder.HasKey(t =>new { t.IdTicket, t.FlightId, t.IdPassenger });

            builder.HasOne(t => t.Passengers)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.IdPassenger);

            builder.HasOne(t => t.Flights )
                .WithMany(f => f.Tickets)
                .HasForeignKey(t =>t.FlightId);


        }
    }
}
