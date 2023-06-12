using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class SightseeingBLL
    {
        private SightDAL _DAL;
        private Mapper _PersonMapper;

        public SightseeingBLL()
        {
            _DAL = new SightDAL();
            var _configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Sight, SightModel>().ReverseMap());

            _PersonMapper = new Mapper(_configPerson);
        }

        public List<SightModel> GetAllSights()
        {
            List<Sight> personsFromDB = _DAL.GetAllSights();
            List<SightModel> personsModel = _PersonMapper.Map<List<Sight>, List<SightModel>>(personsFromDB);

            return personsModel;
        }

        public SightModel GetSightById(int id)
        {
            var personEntity = _DAL.GetSightById(id);

            SightModel sightModel = _PersonMapper.Map<Sight, SightModel>(personEntity);

            return sightModel;
        }


        public void postSight(SightModel personModel)
        {
            Sight personEntity = _PersonMapper.Map<SightModel, Sight>(personModel);
            _DAL.postSight(personEntity);
        }
    }
}
