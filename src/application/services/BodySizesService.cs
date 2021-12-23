using application.contracts.services;
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
    public class BodySizesService : IBodySizesService
    {
        private readonly IBodySizesRepository _bodySizesRepository;

        public BodySizesService(IBodySizesRepository bodySizesRepository)
        {
            _bodySizesRepository = bodySizesRepository;
        }

        public BodySizesDto Create(BodySizesDto obj)
        {
            var bodySizes = _bodySizesRepository.Create(new BodySizes
            {
                ShoulderRange = obj.ShoulderRange,
                BustRange = obj.BustRange,
                HipRange = obj.HipRange,
                WaistRange = obj.WaistRange,
            });

            return new BodySizesDto
            {
                Id = bodySizes.Id,
                ShoulderRange = bodySizes.ShoulderRange,
                WaistRange = bodySizes.WaistRange,
                HipRange = bodySizes.HipRange,
                BustRange = bodySizes.BustRange,
            };
        }

        public void DeleteById(long id)
        {
            _bodySizesRepository.DeleteById(id);
        }

        public BodySizesDto Edit(BodySizesDto obj)
        {
            var bodySizes = _bodySizesRepository.Update(new BodySizes
            {
                Id = obj.Id,
                ShoulderRange = obj.ShoulderRange,
                BustRange = obj.BustRange,
                HipRange = obj.HipRange,
                WaistRange = obj.WaistRange,
            });

            return new BodySizesDto
            {
                Id = bodySizes.Id,
                ShoulderRange = bodySizes.ShoulderRange,
                WaistRange = bodySizes.WaistRange,
                HipRange = bodySizes.HipRange,
                BustRange = bodySizes.BustRange,
            };
        }

        public ICollection<BodySizesDto> GetAll()
        {
            var listBodySizes = _bodySizesRepository.GetAll();

            return listBodySizes.Select(bodySizes => new BodySizesDto
            {
                Id = bodySizes.Id,
                ShoulderRange = bodySizes.ShoulderRange,
                WaistRange = bodySizes.WaistRange,
                HipRange = bodySizes.HipRange,
                BustRange = bodySizes.BustRange,
            }).ToList();
        }

        public BodySizesDto GetById(long id)
        {
           var bodySizes = _bodySizesRepository.GetById(id);

            return new BodySizesDto
            {
                Id = bodySizes.Id,
                ShoulderRange = bodySizes.ShoulderRange,
                WaistRange = bodySizes.WaistRange,
                HipRange = bodySizes.HipRange,
                BustRange = bodySizes.BustRange,
            };
        }

        public string CreateBody(BodySizesDto obj)
        {
            if (obj != null)
            {
                var bodySizes = _bodySizesRepository.Create(new BodySizes
                {
                    ShoulderRange = obj.ShoulderRange,
                    BustRange = obj.BustRange,
                    HipRange = obj.HipRange,
                    WaistRange = obj.WaistRange,
                });

                return "shap";
            }


            return null;
        }
        public string EditBody(BodySizesDto obj)
        {
            if (obj != null)
            {
                var bodySizes = _bodySizesRepository.Create(new BodySizes
                {
                    Id = obj.Id,
                    ShoulderRange = obj.ShoulderRange,
                    BustRange = obj.BustRange,
                    HipRange = obj.HipRange,
                    WaistRange = obj.WaistRange,
                });

                return "shap";
            }


            return null;
        }
    }
}
