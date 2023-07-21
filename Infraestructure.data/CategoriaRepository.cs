using Erla.Domain.Interfaces.Repository;
using Infraestructure.data.Models;
//using MiPrimerProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.data
{

    public class CategoriaRepository : IRepository<Categorium>

    {
        private BdElopezContext _db;
        public CategoriaRepository(BdElopezContext db)
        {
            _db = db;
        }

        public Categorium Add(Categorium entity)
        {
           // entity.CodigoCat = entity.CodigoCat;
            entity.NombreCat = entity.NombreCat;
            _db.Categoria.Add(entity);
            return entity;
        }
        public void Save() { _db.SaveChanges(); }  
            
    }
}
