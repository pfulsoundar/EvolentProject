using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentDemo.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Contact contacts)
        {
            //Random r = new Random();
            //contacts.Id = Guid.NewGuid().ToString(); //r.Next().ToString(); //Guid.NewGuid().ToString();
            db.Contacts.Add(contacts);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Contact> GetContact(int id)
        {
            try
            {
                Contact employee = await db.Contacts.FindAsync(id);
                if (employee == null)
                {
                    return null;
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            try
            {
                var contacts = await db.Contacts.ToListAsync();
                return contacts.AsQueryable();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task Update(Contact contacts)
        {
            try
            {
                db.Entry(contacts).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Contact contacts = await db.Contacts.FindAsync(id);
                db.Contacts.Remove(contacts);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }

    }
}