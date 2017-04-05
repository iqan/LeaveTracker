using System;
using System.Data.Entity;
using LeaveTracker.Models;

namespace LeaveTracker.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            for (var i = 1; i < 5; i++)
            {

                context.Leaves.Add(new LeaveDetails()
                {
                    EmployeeId = i,
                    EmployeeName = "name " + i,
                    StartDate = DateTime.Now.AddDays(i),
                    EndDate = DateTime.Now.AddDays(i),
                    DateApplied = DateTime.Now,
                    DateApproved = DateTime.Now,
                    ApprovedById = i,
                    IsApproved = true,
                    IsPlanned = true,
                    Comments = "comments",
                    Reason = "reason"
                });
            }
            
            base.Seed(context);
        }
    }
}