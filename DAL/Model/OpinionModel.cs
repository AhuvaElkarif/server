using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OpinionModel
    {
        public List<opinion> GetOpinions()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.opinions.Where(x => x.Status==true).ToList();
            }
        }
        public List<opinion> GetNotActiveOpinions()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.opinions.Where(x => x.Status == false).ToList();
            }
        }
        public opinion GetOpinionByOpinionId(int opinionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.opinions.FirstOrDefault(x => x.Id == opinionId);
            }
        }
        public List<opinion> GetOpinionsByAttrctionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.opinions.Where(x => x.AttractionId == attractionId).ToList();
            }
        }
        public opinion Post(opinion opinion)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                opinion = db.opinions.Add(opinion);
                db.SaveChanges();
                return opinion;
            }
        }
        public opinion Put(opinion opinion)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                opinion newOpinion = db.opinions.FirstOrDefault(x => x.Id == opinion.Id);
                newOpinion.AttractionId = opinion.AttractionId;
                newOpinion.InsertDate = opinion.InsertDate;
                newOpinion.OpinionText = opinion.OpinionText;
                newOpinion.UserId = opinion.UserId;
                newOpinion.Status = opinion.Status;
                newOpinion.Grading = opinion.Grading;
                db.SaveChanges();
                return opinion;
            }
        }
        public opinion ChangeStatus(int opinionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                opinion newOpinion = db.opinions.FirstOrDefault(x => x.Id == opinionId);
                newOpinion.Status = !newOpinion.Status;
                db.SaveChanges();
                return newOpinion;
            }
        }
        public bool Delete(int opinionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                opinion newOpinion = db.opinions.Remove(db.opinions.FirstOrDefault(x => x.Id == opinionId));
                db.SaveChanges();
                return true;
            }
        }
    }
}
