using LeaveTracker.Models;
using System.Web.Mvc;
using System.Linq;

namespace LeaveTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLeaveEvents(double start, double end)
        {
            var LeaveListForDate = LeaveEvents.LoadAllLeavesInDateRange(start, end);
            var eventList = from e in LeaveListForDate
                            select new
                            {
                                id = e.ID,
                                someKey = e.EmployeeID,
                                title = e.EmployeeName,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                color = e.StatusColor,
                                className = e.ClassName
                                //id = e.ID,
                                //empid = e.EmployeeID,
                                //empname = e.EmployeeName,
                                //start = e.StartDateString,
                                //end = e.EndDateString,
                                //applied = e.DateAppliedString,
                                //approveddate = e.DateApprovedString,
                                //color = e.StatusColor,
                                //className = e.ClassName,
                                //approvedby = e.ApprovedById,
                                //reason = e.Reason,
                                //comments = e.Comments,
                                //planned = e.IsPlanned
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}