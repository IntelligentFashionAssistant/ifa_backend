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
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public GroupDto Create(GroupDto obj)
        {
            var group = _groupRepository.Create(new Group
            {
                Description = obj.Description,
                Name = obj.Name,
                CategoryId = obj.CategoryId,
            });

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CategoryId = group.CategoryId,
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
                CategoryId = obj.CategoryId,
            });

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CategoryId = obj.CategoryId,
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
                Propertys = group.Properties.Select(p => p.Name).ToList(),
                Category = group.Category.Name,
                CategoryId = group.CategoryId
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
                Propertys = group.Properties.Select(p => p.Name).ToList(),
                CategoryId = group.CategoryId,
            };
        }
    }
}
