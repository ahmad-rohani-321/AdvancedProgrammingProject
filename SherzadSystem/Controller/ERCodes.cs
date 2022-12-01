using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherzadSystem.Controller
{
    internal class ERCodes
    {
        internal static bool Add(Model.ERCodes codes)
        {
            bool a = true;
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    codes.IsReserved = false;
                    s.ERCodes.Add(codes);
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

        internal static List<Model.ERCodes> GetAllExpenseCodes()
        {
            List<Model.ERCodes> es = new List<Model.ERCodes>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    es = s.ERCodes.Where(x => x.CodeType == true && x.IsReserved == false).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return es;
        }

        internal static List<Model.ERCodes> GetAllRevenueCodes()
        {
            List<Model.ERCodes> es = new List<Model.ERCodes>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    es = s.ERCodes.Where(x => x.CodeType == false && x.IsReserved == false).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return es;
        }

        internal static bool Update(Model.ERCodes c)
        {
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    var code = s.ERCodes.FirstOrDefault(x => x.Cid == c.Cid);
                    code.CodeName = c.CodeName;

                    s.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    return true;
                }
            }
        }
        internal static List<Model.ERCodes> GetERCodes()
        {
            List<Model.ERCodes> eRs = new List<Model.ERCodes>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    eRs = s.ERCodes.Where(x => x.IsReserved == false).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return eRs;
        }
    }
}
