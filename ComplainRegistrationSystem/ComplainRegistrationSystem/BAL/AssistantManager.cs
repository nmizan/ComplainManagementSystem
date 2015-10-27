using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class AssistantManager
    {
        AssistantGateway aGateway=new AssistantGateway();
        public string Save(Assistant aAssistant)
        {
           
                if (aGateway.Save(aAssistant) > 0)
                {
                    return "Successfully Inserted !";
                }
                else
                {
                    return "Insertion Failed!!";
                }
            
        }

       

        public List<Assistant> ShowAllAssistants()
        {
            return aGateway.ShowAllAssistant();
        }

        public bool Delete(string assistId)
        {
            if (aGateway.Delete(assistId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(string assistId, string assistName, string assistType, string contctNo)
        {
            if (aGateway.Update(assistId, assistName, assistType, contctNo) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Assistant> GetAssistantsByType(string type)
        {
            return aGateway.GetAssistantsByType(type);
        }
    }
}