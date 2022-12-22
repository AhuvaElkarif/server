using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class AttractionConvert
    {
        public static DTO.AttractionDTO Convert(DAL.attraction obj)
        {
            if (obj == null)
                return null;
            return new DTO.AttractionDTO()
            {
                Id = obj.Id,
                Address = obj.Address,
                Name = obj.Name,
                Date = obj.Date,
                DaysToCancel = obj.DaysToCancel,
                Description = obj.Description,
                FromAge = obj.FromAge,
                TillAge = obj.TillAge,
                TimeDuration = obj.TimeDuration,
                IsAvailable = obj.IsAvailable,
                MaxParticipant = obj.MaxParticipant,
                MinParticipant = obj.MinParticipant,
                Price = obj.Price,
                Phone = obj.Phone,
                ManagerId = obj.ManagerId,
                Status = obj.Status,
                CategoryId = obj.CategoryId,
                AreaId = obj.AreaId,
                CategoryName = obj.category?.Name,
                CountAvgGrading = obj.opinions.Any()? obj.opinions.Average(x => x.Grading):0,
                Images = string.Join(",", obj.images.Select(x => x.Img)),
                Seasons = obj.periods.Select(x => x.SeasonId).ToArray()
            };
           
        }

        public static DAL.attraction Convert(DTO.AttractionDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.attraction()
            {
                Id = obj.Id,
                Address = obj.Address,
                Name = obj.Name,
                Date = obj.Date,
                DaysToCancel = obj.DaysToCancel,
                Description = obj.Description,
                FromAge = obj.FromAge,
                TillAge = obj.TillAge,
                TimeDuration = obj.TimeDuration,
                IsAvailable = obj.IsAvailable,
                MaxParticipant = obj.MaxParticipant,
                MinParticipant = obj.MinParticipant,
                Price = obj.Price,
                Status = obj.Status,
                AreaId = obj.AreaId,
                Phone = obj.Phone,
                CategoryId = obj.CategoryId,
                ManagerId = obj.ManagerId,
            };
        }

        public static List<DAL.attraction> Convert(List<DTO.AttractionDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.AttractionDTO> Convert(List<DAL.attraction> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
