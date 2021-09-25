using System;

namespace OneToOneEmployeeAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new OneToOneEmployeeAddressDbContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.SaveChanges();
        }
    }
}
