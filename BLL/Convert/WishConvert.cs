using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class WishConvert
    {
        public static DTO.WishDTO Convert(DAL.wish obj)
        {
            if (obj == null)
                return null;
            return new DTO.WishDTO()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                UserId = obj.UserId
            };
        }
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
                Status = obj.Status,
                CategoryId = obj.CategoryId,
                CategoryName = obj.category?.Name,
                CountAvgGrading = obj.opinions.Any() ? obj.opinions.ToList().Average(x => x.Grading) : 0,
                Images = string.Join(",", obj.images.Select(x => x.Img))
            };
        }

        public static DAL.wish Convert(DTO.WishDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.wish()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                UserId = obj.UserId
            };
        }

        public static List<DAL.wish> Convert(List<DTO.WishDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.WishDTO> Convert(List<DAL.wish> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.AttractionDTO> Convert(List<DAL.attraction> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
