using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OpinionService
    {
        DAL.Model.OpinionModel model = new DAL.Model.OpinionModel();

        public List<DTO.OpinionDTO> GetOpinions()
        {
            return Convert.OpinionConvert.Convert(model.GetOpinions());
        }

        public DTO.OpinionDTO GetOpinionByopinionId(int opinionId)
        {
            return Convert.OpinionConvert.Convert(model.GetOpinionByOpinionId(opinionId));
        }

        public List<DTO.OpinionDTO> GetOpinionsByAttrctionId(int attrctionId)
        {
            return Convert.OpinionConvert.Convert(model.GetOpinionsByAttrctionId(attrctionId));
        }

        public DTO.OpinionDTO Post(OpinionDTO opinion)
        {
            return Convert.OpinionConvert.Convert(model.Post(Convert.OpinionConvert.Convert(opinion)));
        }

        public DTO.OpinionDTO Put(OpinionDTO opinion)
        {
            return Convert.OpinionConvert.Convert(model.Put(Convert.OpinionConvert.Convert(opinion)));
        }

        public bool Delete(int opinionId)
        {
            return model.Delete(opinionId);
        }
    }
}
