using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.functions
{
    public class reportFun
    {
        // משתנה שמכיל את המסד
        static Models.TimeBankContext db = new Models.TimeBankContext();

        public static int addReport(Report rep)
        {
            try
            {
                /* db.Members.Include(m => m.MemberCategories).ToList();
                 db.Reports.Include(m => m.ReportsDetails).ToList();
                 db.MemberCategories.Include(m => m.Reports).ToList();
                 db.MemberCategories.Include(m => m.Category).ToList();*/
                //תקח מטבלת החברים את החבר 
                /*  db.Members.FirstOrDefault(m => m.Phone == phone).MemberCategories.
                      FirstOrDefault(c => c.Category.Name == categoryName).Reports.
                      Add(rep);

                  Dal.Models.Member r= db.Members.FirstOrDefault(m => m.Phone == phone);*/
                //int tryId = 0;
                rep.Giver = null;
                rep.ReportsDetails = null;
                rep.Category = null;
                db.Reports.Add(rep);
                db.SaveChanges();
                //tryId = rep.Id;
                return rep.Id;
            }
            catch(Exception e)
            {
                throw new Exception();
            }
    
        }
    }
}
