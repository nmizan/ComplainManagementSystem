using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplainRegistrationSystem.Model
{
    public class Complain
    {
        public string ComplainId { get; set; }
        public string PersonName { get; set; }
        public int HostelNo { get; set; }
        public int RoomNo { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string Priority { get; set; }
        public DateTime DateOfComplain { get; set; }
        public string Status { get; set; }
        public string ContactNo { get; set; }
        public string AssistantName { get; set; }
        public string Remarks { get; set; }
        public string AssistantContact { get; set; }
        public int NewReq { get; set; }
        public int PenReq { get; set; }
        public int CanReq { get; set; }
        public int SolReq { get; set; }
        public string CanButt { get; set; }
        public string SolButt { get; set; }
        public string All1 { get; set; }
        public string All2 { get; set; }
        public string full { get; set; }

    }
}