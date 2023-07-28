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

        public Categorium Update(Categorium entity)
        {
            // entity.CodigoCat = entity.CodigoCat;
            var vCategoria = _db.Categoria.Where(x => x.CodigoCat == entity.CodigoCat).FirstOrDefault();
            if (vCategoria != null) {
                vCategoria.NombreCat = entity.NombreCat;
                _db.Entry(vCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return entity;
        }

        public void Save() 
        { 
            _db.SaveChanges(); 
        }  
            
    }
}
