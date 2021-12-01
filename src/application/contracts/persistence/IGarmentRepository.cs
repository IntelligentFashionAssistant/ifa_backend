using application.DTOs;
using domain.Entitys;

namespace application.persistence
{
    public interface IGarmentRepository : IRepository<Garment, long>
    {
        void RateGarment(PropertyFeedback obj);
    }
}