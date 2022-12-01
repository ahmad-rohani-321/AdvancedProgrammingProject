using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SherzadSystem.Model;

namespace SherzadSystem.Controller
{
    public class Person
    {
        internal static Model.PersonInformation AddPerson(Model.PersonInformation p)
        {
            var person = new Model.PersonInformation();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    s.PersonInformation.Add(p);
                    s.SaveChanges();

                    person = p;
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return person;
        }

        internal static List<Model.PersonInformation> GetAllPeople()
        {
            List<Model.PersonInformation> pi = new List<Model.PersonInformation>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    pi = s.PersonInformation.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return pi;
        }

        internal static bool Update(PersonInformation person)
        {
            bool u = true;
            using (Model.ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    var update = s.PersonInformation.FirstOrDefault(x => x.PIid == person.PIid);
                    update = person;

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

        internal static List<Model.PersonInformation> GetAllPeople(string S)
        {
            List<Model.PersonInformation> pi = new List<Model.PersonInformation>();
            using (Model.ShirzadSystem s = new Model.ShirzadSystem())
            {
                try
                {
                    pi = s.PersonInformation.Where(x => x.CreationDate.ToString().Contains(S) || x.FirstName.Contains(S) || x.LastName.Contains(S) || x.FatherName.Contains(S) || x.Province.Contains(S)).ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return pi;
        }

        internal static PersonInformation GetPerson(int personId)
        {
            PersonInformation person = new PersonInformation();
            using (ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    person = s.PersonInformation.FirstOrDefault(x => x.PIid == personId);
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return person;
        }
        //internal static bool UpdatePeople(Model.PersonInformation person)
        //{

        //}
    }
}
