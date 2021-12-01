using System.Collections.Generic;
using application.DTOs;
using application.persistence;
using domain.Entitys;

namespace repository.Repositories
{
    public class GarmentRepository : IGarmentRepository
    {
        public Garment GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Garment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Garment Create(Garment obj)
        {
            throw new System.NotImplementedException();
        }

        public Garment Update(Garment obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void RateGarment(GarmentRatingDto garmentRatingDto)
        {
            throw new NotImplementedException();
        }
    }
}