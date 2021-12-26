using domain.Entitys;

namespace application.persistence;

public interface IShapeRepository : IRepository<Shape, long>
{
    Shape GetShapeByName(string name); 
}