using task_officina.Models;
using task_officina.Repository;

namespace task_officina.Services
{
    public class ClienteService : IService<ClienteDTO>
    {

        private readonly ClienteRepos _repository;

        public ClienteService(ClienteRepos repository)
        {
            _repository = repository;
        }

        public ClienteDTO? Cerca(string varCod)
        {
            ClienteDTO? risultato = null;

            Cliente? inter = _repository.CercaperCodice(varCod);
            if (inter is not null)
            {
                risultato = new ClienteDTO()
                {
                    Cod = inter.Codice,
                    Nom = inter.Nome,
                    Cog = inter.Cognome,
                    Ema = inter.Email,
                    Ind = inter.Indirizzo,
                    Tel = inter.Telefono,
                };
            }
            return risultato;
        }

        public IEnumerable<ClienteDTO> Lista()
        {
            ICollection<ClienteDTO> risultato = new List<ClienteDTO>();

            IEnumerable<Cliente> clients = _repository.GetAll();

            foreach (Cliente c in clients)
            {

                ClienteDTO cli = new ClienteDTO()
                {
                    Cod = c.Codice,
                    Nom = c.Nome,
                    Cog = c.Cognome,
                    Ema = c.Email,
                    Ind = c.Indirizzo,
                    Tel = c.Telefono
                };

                risultato.Add(cli);
            }
            return risultato;
        }



        public bool InserisciCliente(ClienteDTO newcli)
        {
            Cliente cl = new Cliente()
            {
                Codice = newcli.Cod is not null ? newcli.Cod : Guid.NewGuid().ToString().ToUpper(),
                Nome = newcli.Nom,
                Cognome = newcli.Cog,
                Email = newcli.Ema,
                Indirizzo = newcli.Ind,
                Telefono = newcli.Tel
            };

            return _repository.Create(cl);
        }


        public bool Modifica(ClienteDTO objmod)
        {


            Cliente temp = new Cliente()
            {
                Email = objmod.Ema,
                Indirizzo = objmod.Ind,
                Telefono = objmod.Tel
            };
            return _repository.Update(temp);
        }


        public bool RimuoviCliente(int id)
        {
            bool risultato = false;

            Cliente? del = _repository.GetbyId(id);
            if (del is not null)
                _repository.Delete(id);
            risultato = true;

            return risultato;

        }


        public IEnumerable<ClienteDTO> RegistroClienti()
        {
            ICollection<ClienteDTO> risultato = new List<ClienteDTO>();

            IEnumerable<Cliente> clientis = _repository.GetAll();

            foreach (Cliente c in clientis)
            {

                ClienteDTO cli = new ClienteDTO()
                {
                    Cod = c.Codice,
                    Nom = c.Nome,
                    Ema = c.Email,
                    Ind = c.Indirizzo,
                    Tel = c.Telefono
                };

                risultato.Add(cli);
            }


            return risultato;
        }


    }
}
