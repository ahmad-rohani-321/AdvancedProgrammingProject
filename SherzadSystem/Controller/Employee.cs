using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    internal class Employee
    {
        public static object GetEmployees()
        {
            object ret = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    ret = s.Employees.ToList();
                }
                catch (Exception ex )
                {
                    Defaults.SetLog(ex);
                }
            }
            return ret;
        }
        public static bool Add(Model.Employees e)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Employees.Add(e);
                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    ret = false;
                }
            }
            return ret;
        }
        public static bool Update(Model.Employees e)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var row = s.Employees.FirstOrDefault(x => x.Eid == e.Eid);
                    row.FullName = e.FullName;
                    row.FatherName = e.FatherName;
                    row.PhoneNo = e.PhoneNo;
                    row.Job = e.Job;
                    row.remarks = e.remarks;
                    row.branch = e.branch;

                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    ret = false;
                }
            }
            return ret;
        }
        internal static bool AddJournal(int Eid, decimal recieved, string remarks)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                using (var Transaction = s.Database.BeginTransaction())
                {
                    try
                    {

                        var journalEntry = new Model.JournalEntry()
                        {
                            Till = 1,
                            CreationDate = DateTime.Now,
                            credit = 0,
                            debit = recieved,
                            remarks = remarks,
                            TransactionType = 3
                        };
                        s.JournalEntry.Add(journalEntry);

                        var till = s.Tills.FirstOrDefault();
                        till.TillValue -= recieved;
                        s.SaveChanges();

                        var accE = new Model.AccountEntry();
                        accE.EmpId = Eid;
                        accE.JournalId = journalEntry.JEid;
                        s.AccountEntry.Add(accE);   
                        s.SaveChanges();

                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Defaults.SetLog(ex);
                        Transaction.Rollback();
                        ret = false;
                    }
                }
            }
            return ret;
        }
        internal static object GetEmployeeAccounting()
        {
            object data = null;
            DateTime StartDate = DateTime.Now.AddDays(-30);
            DateTime EndDate = DateTime.Now;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.AccountEntry.Include("JournalEntry").Include("Employees").Where(x => x.JournalEntry.CreationDate < StartDate || x.JournalEntry.CreationDate > EndDate).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }

        internal static object GetEmployeeAccounting(DateTime StartDate, DateTime EndDate, int[] Emps)
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.AccountEntry.Include("JournalEntry").Include("Employees").Where(x => (x.JournalEntry.CreationDate < StartDate || x.JournalEntry.CreationDate > EndDate) && Emps.Contains(x.EmpId)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
    }
}
