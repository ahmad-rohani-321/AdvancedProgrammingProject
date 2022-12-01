using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    public class Universities
    {
        public static int CountOfUniversities()
        {
            int Count = 0;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    Count = s.Universities.Count();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return Count;
        }
        internal static bool Update(Model.Universities unive)
        {
            bool u = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var row = s.Universities.FirstOrDefault(x => x.Uid == unive.Uid);
                    row.UniversityName = unive.UniversityName;
                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    u = false;
                }
            }
            return u;
        }
        public static bool AddUniversity(Model.Universities universities)
        {
            bool Add = true;
            using(Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Universities.Add(universities);
                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    Add = false;
                }
            }
            return Add;
        }
        public static List<Model.Universities> GetUniversities()
        {
            List<Model.Universities> u = new List<Model.Universities>();
            using(Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    u = s.Universities.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return u;
        }
    }
}
