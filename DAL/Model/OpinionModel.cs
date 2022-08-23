using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OpinionModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<opinion> GetOpinions()
        {
            return db.opinions.ToList();
        }
        public opinion GetOpinionByOpinionId(int opinionId)
        {
            return db.opinions.FirstOrDefault(x => x.Id == opinionId);
        }
        public List<opinion> GetOpinionsByAttrctionId(int attractionId)
        {
            return db.opinions.Where(x => x.AttractionId == attractionId).ToList();
        }
        public opinion Post(opinion opinion)
        {
            opinion = db.opinions.Add(opinion);
            db.SaveChanges();
            return opinion;
        }
        public opinion Put(opinion opinion)
        {
            opinion newOpinion = db.opinions.FirstOrDefault(x => x.Id == opinion.Id);
            newOpinion.AttractionId = opinion.AttractionId;
            newOpinion.InsertDate = opinion.InsertDate;
            newOpinion.OpinionText = opinion.OpinionText;
            newOpinion.UserId = opinion.UserId;
            newOpinion.Grading = opinion.Grading;
            db.SaveChanges();
            return opinion;

        }
        public opinion Delete(opinion opinion)
        {
            opinion newOpinion = db.opinions.Remove(opinion);
            db.SaveChanges();
            return opinion;
        }
    }
}
