using LeaveTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LeaveTracker.Shared.EnumService;

namespace LeaveTracker.Models
{
    public class LeaveEvents
    {
        public int ID;
        public string EmployeeName;     // Title;
        public int EmployeeID;          // SomeImportantKeyID;
        public string StartDateString;
        public string EndDateString;
        public string StatusString;
        public string StatusColor;
        public string ClassName;
        public string DateAppliedString;
        public string DateApprovedString;
        public string IsPlanned;
        public int ApprovedById;
        public string Reason;
        public string Comments;
        public static List<LeaveEvents> LoadAllLeavesInDateRange(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            using (DataContext ent = new DataContext())
            {
                var rslt = ent.Leaves.Where(s => s.StartDate >= fromDate && s.EndDate <= toDate);

                List<LeaveEvents> result = new List<LeaveEvents>();
                foreach (var item in rslt)
                {
                    LeaveEvents rec = new LeaveEvents();
                    rec.ID = item.LeaveId;
                    rec.EmployeeID = item.EmployeeId;
                    rec.EmployeeName = item.EmployeeName;
                    rec.StartDateString = item.StartDate.ToString("s"); // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.EndDateString = item.EndDate.ToString("s");
                    rec.DateAppliedString = item.DateApplied.ToString("s");
                    rec.DateApprovedString = item.DateApproved.ToString("s");
                    rec.Reason = item.Reason;
                    rec.StatusString = Enums.GetName<LeaveStatus>((LeaveStatus)(item.IsApproved?0:1));
                    rec.StatusColor = Enums.GetEnumDescription<LeaveStatus>(rec.StatusString);
                    string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
                    rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
                    rec.StatusColor = ColorCode;
                    rec.IsPlanned = item.IsPlanned?"Planned":"Unplanned";
                    rec.Comments = item.Comments;
                    rec.ApprovedById = item.ApprovedById;
                    result.Add(rec);
                }
                return result;
            }
        }
        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}