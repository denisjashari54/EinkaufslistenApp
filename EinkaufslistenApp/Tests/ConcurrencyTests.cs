using NUnit.Framework;
using System;
using System.Threading.Tasks;
using EinkaufslistenApp.Data;
using EinkaufslistenApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EinkaufslistenApp.Tests
{
    [TestFixture]
    public class ConcurrencyTests
    {
        private static DbContextOptions<EinkaufslistenDbContext> _options =
            new DbContextOptionsBuilder<EinkaufslistenDbContext>()
            .UseSqlServer("Server=DENISLAPTOP\\SQLEXPRESS;Database=EinkaufslistenDB;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        [SetUp]
        public async Task Setup()
        {
            using var context = new EinkaufslistenDbContext(_options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var einkaufsItem = new EinkaufsItem
            {
                Name = "Brot",
                Menge = 1,
                Gekauft = false,
                ErstelltAm = DateTime.UtcNow,
                RowVersion = new byte[1],
                BenutzerId = 1
            };

            context.EinkaufsItems.Add(einkaufsItem);
            await context.SaveChangesAsync();
        }

        [Test]
        public async Task Concurrent_Update_Should_Throw_DbUpdateConcurrencyException()
        {
            using var context1 = new EinkaufslistenDbContext(_options);
            using var context2 = new EinkaufslistenDbContext(_options);

            var item1 = await context1.EinkaufsItems.FirstAsync(i => i.Name == "Brot");
            var item2 = await context2.EinkaufsItems.FirstAsync(i => i.Name == "Brot");

            item1.Menge = 10;
            await context1.SaveChangesAsync();

            item2.Menge = 5;

            var ex = Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () =>
            {
                await context2.SaveChangesAsync();
            });

            Assert.That(ex, Is.Not.Null, "Concurrency-Exception wurde nicht geworfen!");
        }

        [Test]
        public async Task Item_Can_Be_Added_Successfully()
        {
            using var context = new EinkaufslistenDbContext(_options);
            var newItem = new EinkaufsItem
            {
                Name = "Butter",
                Menge = 2,
                Gekauft = false,
                ErstelltAm = DateTime.UtcNow,
                RowVersion = new byte[1],
                BenutzerId = 1
            };

            context.EinkaufsItems.Add(newItem);
            await context.SaveChangesAsync();

            var savedItem = await context.EinkaufsItems.FirstOrDefaultAsync(i => i.Name == "Butter");
            Assert.That(savedItem, Is.Not.Null, "Item wurde nicht erfolgreich gespeichert!");
            Assert.That(savedItem.Menge, Is.EqualTo(2), "Die Menge stimmt nicht überein.");
        }

        [Test]
        public async Task Item_Can_Be_Deleted_Successfully()
        {
            using var context = new EinkaufslistenDbContext(_options);
            var item = await context.EinkaufsItems.FirstAsync(i => i.Name == "Brot");

            context.EinkaufsItems.Remove(item);
            await context.SaveChangesAsync();

            var deletedItem = await context.EinkaufsItems.FirstOrDefaultAsync(i => i.Name == "Brot");
            Assert.That(deletedItem, Is.Null, "Item wurde nicht erfolgreich gelöscht!");
        }

        [Test]
        public async Task Concurrent_Update_Without_RowVersion_Should_Create_Data_Inconsistency()
        {
            using var context1 = new EinkaufslistenDbContext(_options);
            using var context2 = new EinkaufslistenDbContext(_options);

            var item1 = await context1.EinkaufsItems.FirstAsync(i => i.Name == "Brot");
            var item2 = await context2.EinkaufsItems.FirstAsync(i => i.Name == "Brot");

            item1.Menge = 10;
            await context1.SaveChangesAsync();

            using var verificationContext = new EinkaufslistenDbContext(_options);
            var latestItem = await verificationContext.EinkaufsItems
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == item2.Id);

            if (latestItem == null)
            {
                Assert.Fail("Item wurde während der Transaktion gelöscht oder verändert.");
            }

            context2.Entry(item2).Property("RowVersion").CurrentValue = latestItem.RowVersion;

            item2.Menge = 5;
            await context2.SaveChangesAsync();

            var updatedItem = await verificationContext.EinkaufsItems.FirstAsync(i => i.Name == "Brot");

            Assert.That(updatedItem.Menge, Is.Not.EqualTo(10), "Die Datenbank hat eine ungewollte Inkonsistenz!");
            Assert.That(updatedItem.Menge, Is.EqualTo(5), "Der zweite Wert wurde ohne Prüfung überschrieben!");
        }

    }
}
