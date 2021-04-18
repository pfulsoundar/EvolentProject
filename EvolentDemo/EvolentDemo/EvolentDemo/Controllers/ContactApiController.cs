using EvolentDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvolentDemo.Controllers
{
    public class ContactApiController : ApiController
    {
        private readonly ContactRepository _iContactRepository = new ContactRepository();

        [HttpGet]
        [Route("api/Contact/Get")]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _iContactRepository.GetContacts();
        }

        [HttpPost]
        [Route("api/Contact/Create")]
        public async Task CreateAsync([FromBody]Contact contacts)
        {
            if (ModelState.IsValid)
            {
                await _iContactRepository.Add(contacts);
            }
        }

        [HttpGet]
        [Route("api/Contact/Details/{id}")]
        public async Task<Contact> Details(int id)
        {
            var result = await _iContactRepository.GetContact(id);
            return result;
        }

        [HttpPut]
        [Route("api/Contact/Edit")]
        public async Task EditAsync([FromBody]Contact contacts)
        {
            if (ModelState.IsValid)
            {
                await _iContactRepository.Update(contacts);
            }
        }

        [HttpDelete]
        [Route("api/Contact/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iContactRepository.Delete(id);
        }
    }
}
