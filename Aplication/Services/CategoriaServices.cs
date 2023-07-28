using Aplication.Interface;
using Erla.Domain.Interfaces.Repository;
using Infraestructure.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class CategoriaServices : IService<Categorium>
    {
        private readonly IRepository<Categorium> _repository;
        public CategoriaServices(IRepository<Categorium> repository)
        {
            _repository = repository;
        }

        public Categorium Add(Categorium entity)
        {
            var vresult= _repository.Add(entity);
            _repository.Save();
            return vresult;
        }

        public Categorium Update(Categorium entity)
        {
            var vresult = _repository.Update(entity);
            _repository.Save(); 
            return vresult;
        }
    }
}
