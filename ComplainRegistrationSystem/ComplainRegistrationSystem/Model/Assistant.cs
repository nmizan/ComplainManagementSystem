using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplainRegistrationSystem.Model
{
    public class Assistant
    {
        public string AssistantId { get; set; }
        public string AsstName { get; set; }
        public string AsstType { get; set; }
        public string ContactNo { get; set; }
        public string AsstTypeName { set; get; }
        public int SolvingReq { set; get; }
        public int PendingReq { set; get; }

    }
}