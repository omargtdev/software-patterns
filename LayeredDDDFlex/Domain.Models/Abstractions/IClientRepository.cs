using Domain.Models.Entities;
using System.Collections.Generic;

namespace Domain.Models.Abstractions
{
    public interface IClientRepository
    {
        // Behaviors of the client
        int Add(Client client);
        int Edit(Client client);
        int Remove(Client client);
        IEnumerable<Client> GetClients(string filter);
    }
}
