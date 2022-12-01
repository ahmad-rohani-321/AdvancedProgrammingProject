using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    internal class Literature
    {
        internal static bool Add(Model.Literature l)
        {
            bool a = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Literature.Add(l);
                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    a = false;
                }
            }
            return a;
        }

        internal static object GetWritings()
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Literature.Include("PersonInformation").Where(x => x.TotalAmount != (x.TotalDiscount + x.TotalRecived)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }

        internal static int GetLastUniqueId()
        {
            int id = 0;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    int UniqueId = s.Literature.OrderByDescending(x => x.UniqueId).FirstOrDefault().UniqueId;
                    id = UniqueId + 1;
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return id;
        }


        internal static bool AddJournal(int Lid, decimal discount, decimal recieved, string remarks)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                using (var Transaction = s.Database.BeginTransaction())
                {
                    try
                    {
                        var MID = s.Literature.FirstOrDefault(x => x.Lid == Lid);
                        MID.TotalDiscount += discount;
                        MID.TotalRecived += recieved;

                        if (recieved > 0)
                        {
                            var journalEntry = new Model.JournalEntry()
                            {
                                Till = 1,
                                CreationDate = DateTime.Now,
                                credit = recieved,
                                debit = 0,
                                remarks = remarks,
                                TransactionType = 2
                            };
                            s.JournalEntry.Add(journalEntry);

                            var till = s.Tills.FirstOrDefault();
                            till.TillValue += recieved;
                        }
                        s.SaveChanges();
                        Transaction.Commit();
                        Transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Defaults.SetLog(ex);
                        Transaction.Rollback();
                        Transaction.Dispose();
                        ret = false;
                    }
                }
            }
            return ret;
        }
        internal static object GetLiteratureBySearch(string MName)
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Literature.Include("PersonInformation").Where(x => x.TotalAmount != (x.TotalDiscount + x.TotalRecived) && (x.LiteratureName.Contains(MName) || x.UniqueId.ToString().Contains(MName))).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
        internal static object GetLiteratureReport()
        {
            object data = null;
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now.AddDays(-30);
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Literature.Include("PersonInformation").Where(x => x.CreationDate < StartDate || x.CreationDate > EndDate).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }

        internal static object GetLiteratureReport(DateTime StartDate, DateTime EndDate, int[] People)
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Literature.Include("PersonInformation").Where(x => (x.CreationDate < StartDate || x.CreationDate > EndDate) && People.Contains(x.Person)).ToList();
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
