using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class LoginAfterManager
    {
        LoginAfterGateway aLoginAMan=new LoginAfterGateway();
       
        Assistant aAssistant = new Assistant();


        public List<Assistant> GetAssistantData()
        {
            return aLoginAMan.GetAssistantData();

        }
        public List<Assistant> ViewInAssistantGrid(string aName)
        {
            return aLoginAMan.ViewInGridView(aName);
        }
        public List<Complain> ViewInGridview()
        {
            return aLoginAMan.ViewInGridView();
        }
        public List<Complain> ViewInReq()
        {
            return aLoginAMan.ViewInLabelReq();
        }
        public List<Complain> ChangeGridView(string reqType)
        {
            return aLoginAMan.GridViewChangeByLink(reqType);
        }
        public List<Complain> ReqTyp(string reqStatus,string cate)
        {
            return aLoginAMan.GridByReq(reqStatus,cate);
        }
        public string ChangeBySol(string[] asd, string sta)
        {
            return aLoginAMan.ChangedByCan(asd, sta);
        }
        public DataTable SearchByDate(string t1, string t2)
        {
            return aLoginAMan.SearchByDate(t1, t2);
        }
        public string AllocateFinal(List<Complain> aLLocate, string[] cid)
        {
            return aLoginAMan.AllocateAssistant(aLLocate, cid);
        }

        public List<string> DropPopu()
        {
            return aLoginAMan.PopulateDropDown();
        }

        public string GetRemarks(string cid)
        {
            return aLoginAMan.GetAllRemarks(cid);
        }

        public string GiveRemarks(string allrem, string id)
        {
            return aLoginAMan.GiveRemarks(allrem, id);
        }

        public Assistant ChangeAssisGrid(string name)
        {
            return aLoginAMan.ChangeReqLAM(name);
        }

        public string ChAssId(int p, int n, string nam)
        {
            return aLoginAMan.UpdateAssisGridViewReq(p, n, nam);
        }
    
    }
}