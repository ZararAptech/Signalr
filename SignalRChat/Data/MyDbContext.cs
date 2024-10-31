using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Runtime.Intrinsics.X86;
using SignalRChat.Models;
namespace SignalRChat.Data

{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<user> Users { get; set; }
        public virtual DbSet<usermsghistory> UserMessage {  get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 optionsBuilder.UseSqlServer("Data Source=DESKTOP-1NHQSUD\\SQLEXPRESS;Initial Catalog=signalr;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}
