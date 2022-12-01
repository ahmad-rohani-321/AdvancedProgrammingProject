using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    internal class Monograph
    {
        internal static bool AddMonograph(Model.Monograph m )
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Monograph.Add(m);
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
        internal static Model.Monograph GetMonograph(int id)
        {
            Model.Monograph monograph = new Model.Monograph();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    monograph = s.Monograph.FirstOrDefault(x => x.Mid == id);
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return monograph;
        }
        internal static int GetLastUniqueId()
        {
            int GetId = 0;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    GetId = s.Monograph.OrderByDescending(x => x.UniqueId).FirstOrDefault().UniqueId;
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return GetId + 1;
        }
        internal static object GetMonographBySearch(string MName)
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Include("Departments").Include("Universities").Include("Faculties").Include("PersonInformation").Where(x => x.totalPrice != (x.totalDiscount + x.totalRecived) && (x.Title.Contains(MName) || x.UniqueId.ToString().Contains(MName))).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
        internal static object GetMonographs()
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Include("Departments").Include("Universities").Include("Faculties").Include("PersonInformation").Where(x => x.totalPrice != (x.totalDiscount + x.totalRecived)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }

        internal static List<Model.Monograph> GetAllMonographs(String Keywords)
        {
            List<Model.Monograph> data = new List<Model.Monograph>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Where(x => x.CreationDate.ToString().Contains(Keywords) || x.UniqueId.ToString().Contains(Keywords) || x.Title.Contains(Keywords) || x.Year.ToString().Contains(Keywords)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
        internal static List<Model.Monograph> GetAllMonographs()
        {
            List<Model.Monograph> data = new List<Model.Monograph>();
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Where(x => x.CreationDate <= EndDate || x.CreationDate >= StartDate).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
        internal static bool AddJournal(int Mid, decimal discount, decimal recieved, string remarks)
        {
            bool ret = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                using (var Transaction = s.Database.BeginTransaction())
                {
                    try
                    {
                        var MID = s.Monograph.FirstOrDefault(x => x.Mid == Mid);
                        MID.totalDiscount += discount;
                        MID.totalRecived += recieved;

                        if(recieved > 0)
                        {
                            var journalEntry = new Model.JournalEntry()
                            {
                                Till = 1,
                                CreationDate = DateTime.Now,
                                credit = recieved,
                                debit = 0,
                                remarks = remarks,
                                TransactionType = 1
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
        internal static object GetMonographsReport()
        {
            object data = null;
            DateTime StartDate = DateTime.Now.AddDays(-30);
            DateTime EndDate = DateTime.Now;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Include("PersonInformation").Where(x => x.CreationDate > StartDate || x.CreationDate < EndDate).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return data;
        }
        internal static object GetMonographsReport(DateTime StartDate, DateTime EndDate, int[] People)
        {
            object data = null;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    data = s.Monograph.Include("PersonInformation").Where(x => (x.CreationDate > StartDate || x.CreationDate < EndDate) && People.Contains(x.PersonId)).ToList();
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
