using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    internal class Accounting
    {
        public static decimal GetTillValue()
        {
            decimal getData = 0;
            using (Model.ShirzadSystem s  = new Model.ShirzadSystem())
            {
                try
                {
                    getData = Math.Round(s.Tills.FirstOrDefault().TillValue, 0);
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return getData;
        }
        public static bool InsertJournalEntry(decimal amount, int ERCode, bool tType, string remarks)
        {
            bool ret = true;
            using(Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                using (var transaction = s.Database.BeginTransaction())
                {
                    try
                    {
                        // journal entry 
                        var JournalEntry = new Model.JournalEntry();
                        JournalEntry.CreationDate = DateTime.Now;
                        JournalEntry.credit = tType == true ? amount : 0;
                        JournalEntry.debit = tType == false ? amount : 0;
                        JournalEntry.TransactionType = ERCode;
                        JournalEntry.Till = 1;
                        JournalEntry.remarks = remarks;
                        s.JournalEntry.Add(JournalEntry);
                        // till entry
                        if (tType == true)
                        {
                            var GetTill = s.Tills.FirstOrDefault();
                            GetTill.TillValue += amount;
                        }else
                        {
                            var GetTill = s.Tills.FirstOrDefault();
                            GetTill.TillValue -= amount;
                        }

                        s.SaveChanges();

                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Defaults.SetLog(ex);
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                }
            }
            return ret;
        }
        internal static object GetJournalEntries()
        {
            object Return = null;
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime EndDate = DateTime.Now.AddDays(-30);
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    Return = s.JournalEntry.Include("ERCodes").Where(x => (x.CreationDate > StartDate || x.CreationDate < EndDate) && x.ERCodes.IsReserved == false).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return Return;
        }
        internal static object GetJournalEntries(DateTime StartDate, DateTime EndDate, int[] TransactionTypes)
        {
            Object Return = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    Return = s.JournalEntry.Include("ERCodes").Where(x => (x.CreationDate > StartDate || x.CreationDate < EndDate) && x.ERCodes.IsReserved == false && TransactionTypes.Contains(x.TransactionType)).ToList();

                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return Return;
        }
    }
}
