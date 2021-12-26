using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace repository.Repositories;

public class ShapeRepository : IShapeRepository
{
    
    private readonly AppDbContext _appDbContext;

    public ShapeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    
    public Shape GetShapeByName(string name)
    {
        return _appDbContext.Shapes.Single(shape => shape.Name == name); 
    }
    
    public Shape GetById(long id)
    {
        return _appDbContext.Shapes
            .Include(shape => shape.Properties)
            .Single(shape => shape.Id == id); 
    }

    public ICollection<Shape> GetAll()
    {
        return _appDbContext.Shapes.ToList();
    }

    public Shape Create(Shape obj)
    {
        _appDbContext.Shapes.Add(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public Shape Update(Shape obj)
    {
        _appDbContext.Shapes.Update(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public void DeleteById(long id)
    {
        var obj = _appDbContext.Shapes.Single(shape => shape.Id == id);
        _appDbContext.Shapes.Remove(obj);
        _appDbContext.SaveChanges();
    }

}