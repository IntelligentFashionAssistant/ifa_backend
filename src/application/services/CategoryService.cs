using application.persistence;
using domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDto Create(CategoryDto obj)
        {

          var category =  _categoryRepository.Create(new Category
            {
                Description = obj.Description,
                Name = obj.Name,
            });

           return new CategoryDto {Id = category.Id, Description = category.Description, Name = category.Name };
        }

        public void DeleteById(long id)
        {
            _categoryRepository.DeleteById(id);
        }

        public CategoryDto Edit(CategoryDto obj)
        {

            var category = _categoryRepository.Update(new Category
            {
                Description = obj.Description,
                Name = obj.Name,
                Id = obj.Id,
            });

            return new CategoryDto { Id = category.Id, Description = category.Description, Name = category.Name };
        }

        public ICollection<CategoryDto> GetAll()
        {
           var categories = _categoryRepository.GetAll();

            return categories.Select(categorie => new CategoryDto
            {
                Id = categorie.Id,
                Description = categorie.Description,
                Name = categorie.Name,
                NumberOfGroups = categorie.Groups.Count(),
            }).ToList();
        }

        public CategoryDto GetById(long id)
        {
            var category = _categoryRepository.GetById(id);

            return new CategoryDto
            { 
                Id = category.Id,
                Description = category.Description,
                Name = category.Name };

        }
    }
}
