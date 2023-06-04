using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Entities;
using ApplicationLayer;
using UI.Desktop.ViewModel;

namespace UI.Desktop.ApplicationController
{
    public class ClientController
    {
        public IEnumerable<ClientViewModel> GetClientsAll(string filter)
        {
            var clientList = new ClientService().GetClients(filter);
            var viewModel = new List<ClientViewModel>();
            foreach (Client client in clientList)
                viewModel.Add(new ClientViewModel()
                {
                    ID = client.ID,
                    Nombre = client.Nombre,
                    Apellido = client.Apellido,
                    Direccion = client.Direccion,
                    Ciudad = client.Ciudad,
                    Email = client.Email,
                    Telefono = client.Telefono,
                    Ocupacion = client.Ocupacion
                });

            return viewModel;
        }
    }
}
