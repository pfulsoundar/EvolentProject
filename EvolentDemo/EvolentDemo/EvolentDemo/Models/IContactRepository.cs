using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentDemo.Models
{
    public class IContactRepository
    {
        public interface IEmployeeRepository
        {
            Task Add(Contact contacts);
            Task Update(Contact contacts);
            Task Delete(string id);
            Task<Contact> GetContact(string id);
            Task<IEnumerable<Contact>> GetContacts();
        }
    }
}