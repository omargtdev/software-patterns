using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Abstractions;
using Domain.Models.Entities;
using Infra.DataAccess.Repository;

namespace ApplicationLayer
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public IEnumerable<Client> GetClients(string filter) => _clientRepository.GetClients(filter);
    }
}
