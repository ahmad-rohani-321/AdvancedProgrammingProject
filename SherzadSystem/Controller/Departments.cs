using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    public class Departments
    {
        public static int CountOfDepartments()
        {
            int Count = 0;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    Count = s.Departments.Count();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return Count;
        }
        public static bool Add(string name )
        {
            bool Add = true;
            using(Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.Departments.Add(new Model.Departments() { DepartmentName = name });
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
        internal static bool Update(Model.Departments d)
        {
            bool u = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var dep = s.Departments.FirstOrDefault(x => x.Did == d.Did);
                    dep.DepartmentName = d.DepartmentName;
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
        public static List<Model.Departments> GetAllDepartment()
        {
            List<Model.Departments> li = new List<Model.Departments>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    li = s.Departments.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
                return li;
        }
    }
}
