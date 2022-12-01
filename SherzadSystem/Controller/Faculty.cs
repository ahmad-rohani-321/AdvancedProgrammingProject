using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    public class Faculty
    {
        public static int CountOfFaculties()
        {
            int Count = 0;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    Count = s.Faculties.Count();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return Count;
        }
        public static bool AddFaculty(Model.Faculties f)
        {
            bool Added = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Faculties.Add(f);
                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    Added = false;
                }
            }
            return Added;
        }
        internal static bool Update(Model.Faculties f)
        {
            bool u = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var row = s.Faculties.FirstOrDefault(x => x.Fid == f.Fid);
                    row.FacultyName = f.FacultyName;

                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return u;
        }
        public static List<Model.Faculties> GetAllFculties()
        {
            List<Model.Faculties> faculty = new List<Model.Faculties>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    faculty = s.Faculties.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return faculty;
        }
    }

}
