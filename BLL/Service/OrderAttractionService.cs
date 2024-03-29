﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderAttractionService
    {
        DAL.Model.OrderAttractionModel model = new DAL.Model.OrderAttractionModel();

        public List<DTO.OrderAttractionDTO> GetOrders()
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrders());
        }
        public DTO.OrderAttractionDTO GetOrdersByOrderAttractionId(int orderAttractionId)
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrdersByOrderAttractionId(orderAttractionId));
        }
        public List<DTO.OrderAttractionDTO> GetOrdersByManagerId(int managerId)
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrdersByManagerId(managerId));
        }
        public List<DTO.OrderAttractionDTO> GetOrdersByUserId(int userId)
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrdersByUserId(userId));
        }
        public List<EventsInCalenderDTO> GetDaysInMonth(int attractionId,int month, int year, int amount)
        {
            return Convert.EventsInCalenderConvert.Convert(model.GetDaysInMonth(attractionId, month, year,amount));
        }
        public List<TimesInCalenderDTO> GetTimesInDay(int day, int month, int year, int id, int amount)
        {
            return Convert.TimesInCalenderConvert.Convert(model.GetTimesInDay(day, month,year, id, amount));
        }
        public DTO.OrderAttractionDTO Post(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Post(Convert.OrderAttractionConvert.Convert(orderAttraction), Convert.UserConvert.Convert(orderAttraction.User)));
        }

        public DTO.OrderAttractionDTO Put(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Put(Convert.OrderAttractionConvert.Convert(orderAttraction)));
        }
        public bool ChangeStatus(int orderId)
        {
            return model.ChangeStatus(orderId);
        }

        public bool ChangeApproval(int id)
        {
            return model.ChangeApproval(id);
        }
        public DTO.OrderAttractionDTO Delete(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Delete(Convert.OrderAttractionConvert.Convert(orderAttraction)));
        }
    }
}
