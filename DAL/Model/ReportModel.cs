﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ReportModel
    {
        public List<report> GetReports()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.reports.Include("attraction").Include("attraction.category").Include("user").Include("kindReport").Include("opinion").Where(x => x.Status == true).ToList();
            }
        }

        public report GetReportByreportId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.reports.FirstOrDefault(x => x.Id == id);
            }
        }
        public bool ChangeStatus(int id, string operation)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                report report = db.reports.Include("attraction").Include("kindReport").Include("user").Include("opinion").FirstOrDefault(x => x.Id == id);
                if (operation == "remove")
                {
                    opinion o = db.opinions.FirstOrDefault(x => x.Id == report.OpinionId);
                    o.Status = !o.Status;
                }
                report.Status = !report.Status;
                db.SaveChanges();
                return true;
            }
        }
        public report Post(report report)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (db.reports.Any(x => x.OpinionId == report.OpinionId && x.Status==true))
                    return null;
                report = db.reports.Add(report);
                db.SaveChanges();
                return report;
            }
        }
        public report Put(report report)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                report newReport = db.reports.FirstOrDefault(x => x.Id == report.Id);
                newReport.AttractionId = report.AttractionId;
                newReport.UserId = report.UserId;
                newReport.ReportId = report.ReportId;
                newReport.Status = report.Status;
                db.SaveChanges();
                return report;
            }
        }

        public bool Delete(int reportId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                report newReport = db.reports.Remove(db.reports.FirstOrDefault(x => x.Id == reportId));
                db.SaveChanges();
                return true;
            }
        }
    }
}