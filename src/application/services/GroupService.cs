using application.DTOs;
using application.persistence;
using domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IPropertyService _propertyService;

        public GroupService(IGroupRepository groupRepository,
                            IPropertyService propertyService)
        {
            _groupRepository = groupRepository;
            _propertyService = propertyService;
        }
        public GroupDto Create(GroupDto obj)
        {
            var group = _groupRepository.Create(new Group
            {
                Description = obj.Description,
                Name = obj.Name,
                Categories = obj.Categorys.Select(categoryId => new Category { Id = categoryId }).ToList(),  
            });

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Categorys = group.Categories.Select(c => c.Id).ToList(),
            };
        }

        public void DeleteById(long id)
        {
           _groupRepository.DeleteById(id);
        }

        public GroupDto Edit(GroupDto obj)
        {
            var group = _groupRepository.Update(new Group
            {
                Id = obj.Id,
                Description = obj.Description,
                Name = obj.Name,
                Categories = obj.Categorys.Select(categoryId => new Category { Id = categoryId }).ToList(),
            });

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Categorys = group.Categories.Select(c => c.Id).ToList(),
            };
        }

        public ICollection<GroupDto> GetAll()
        {
            var groups = _groupRepository.GetAll();

            return groups.Select(group => new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CategorysNames = group.Categories.Select(c => c.Name).ToList(),
            }).ToList();
        }

      
        public GroupDto GetById(long id)
        {
            var group = _groupRepository.GetById(id);

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Propertys = _propertyService.GetPropertysByGroupId(group.Id),
                Categorys = group.Categories.Select(c => c.Id).ToList(),
                CategorysNames = group.Categories.Select(c => c.Name).ToList(),
            };
        }

        public ICollection<GroupDto> GetGroupByCategory(long id)
        {
            var data = _groupRepository.GetGroupByCategory(id);

            return data.Select(group => new GroupDto()
            {
                Id = group.Id,
                Name = group.Name,
                Propertys = _propertyService.GetPropertysByGroupId(group.Id),
            }).ToList();
        }
    }
}
