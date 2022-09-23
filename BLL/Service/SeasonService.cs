using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SeasonService
    {
        DAL.Model.SeasonModel model = new DAL.Model.SeasonModel();
        public List<DTO.SeasonDTO> Get()
        {
            return Convert.SeasonConvert.Convert(model.GetSeasons());
        }

        public DTO.SeasonDTO GetseasonByseasonId(int seasonId)
        {
            return Convert.SeasonConvert.Convert(model.GetSeasonBySeasonId(seasonId));
        }

        public DTO.SeasonDTO Post(DTO.SeasonDTO season)
        {
            return Convert.SeasonConvert.Convert(model.Post(Convert.SeasonConvert.Convert(season)));
        }

        public DTO.SeasonDTO Put(DTO.SeasonDTO season)
        {
            return Convert.SeasonConvert.Convert(model.Put(Convert.SeasonConvert.Convert(season)));
        }

        public DTO.SeasonDTO Delete(DTO.SeasonDTO season)
        {
            return Convert.SeasonConvert.Convert(model.Delete(Convert.SeasonConvert.Convert(season)));
        }

    }
}