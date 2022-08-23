﻿using System;
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
                date = obj.date,
                DaysToCancel = obj.DaysToCancel,
                Description = obj.Description,
                FromAge = obj.FromAge,
                TillAge = obj.TillAge,
                TimeDuration = obj.TimeDuration,
                IsAvailable = obj.IsAvailable,
                MaxParticipant = obj.MaxParticipant,
                MinParticipant = obj.MinParticipant,
                Price = obj.Price,
                status = obj.status,
                CountAvgGrading = obj.opinions.Any()? obj.opinions.ToList().Average(x=>x.Grading):0,
                Images= string.Join(",", obj.images.Select(x=>x.Img))

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
                date = obj.date,
                DaysToCancel = obj.DaysToCancel,
                Description = obj.Description,
                FromAge = obj.FromAge,
                TillAge = obj.TillAge,
                TimeDuration = obj.TimeDuration,
                IsAvailable = obj.IsAvailable,
                MaxParticipant = obj.MaxParticipant,
                MinParticipant = obj.MinParticipant,
                Price = obj.Price,
                status = obj.status
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