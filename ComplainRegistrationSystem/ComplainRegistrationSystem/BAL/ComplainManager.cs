using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class ComplainManager
    {
        ComplainGateway aGateway=new ComplainGateway();

        public string Save(Complain aComplain)
        {
            
                if (aGateway.Save(aComplain) > 0)
                {
                    return "Complain registered Successfully !!";
                }
                else
                {
                    return "Registered Failed!";
                }

        }

        public List<Complain> ShowAllComplain()
        {
            return aGateway.ShowAllComplain();
        }

        public List<Complain> GetComplainByall(string type,string textbox)
        {
            return aGateway.GetComplainByall(type,textbox);
        }

       
        public bool Update(string compId, string pName, int hNo, int rNo, string catg, string subj,string sumry, string priority,
            string cntctNo)
        {
            if (aGateway.Update(compId, pName, hNo, rNo, catg, subj, sumry, priority, cntctNo) == "WellDone")
                return true;
            else
                return false;
            
        }
        public Complain DropGri(string cid)
        {
            return aGateway.DropInGrid(cid);
        }

       
    }
}