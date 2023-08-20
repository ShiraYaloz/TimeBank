using Dto.dtoClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.converters
{
    public class reportAndDetialConvert:IEnumerable
    {
        public static Dto.dtoClasses.ReportsAndDetail convertFromMicToDto(Dal.Models.Report report )
        {
            Dto.dtoClasses.ReportsAndDetail r = new Dto.dtoClasses.ReportsAndDetail();
            r.Date = report.Date;
            //כאן יש צורך לעשות לולאה עבור כל חברי הפעולה שקבלו.
            //ההמרה מתבצעת לרשימה כדי לגשת למקום הראשון כי יש חבר אחד
            //בניית החבר היחיד בינתיים שמקבל את הפעולה
            if (report.ReportsDetails.Count() != 0)
            {
               // r.GetterMembers = new Dto.dtoClasses.Receiver(report.ReportsDetails.ToList()[0].GetterMember.Name, report.ReportsDetails.ToList()[0].GetterMember.Phone);
                List<Dto.dtoClasses.Receiver> gM = new List<Dto.dtoClasses.Receiver>();
                for (int i = 0; i < report.ReportsDetails.ToList().Capacity; i++)
                {
                    gM.Add(new Dto.dtoClasses.Receiver(report.ReportsDetails.ToList()[i].GetterMember.Name, report.ReportsDetails.ToList()[0].GetterMember.Phone));
                }
                r.GetterMembers = gM;
                List<bool> appr = new List<bool>();
                ///????????
                r.ReceiverApproved = report.ReportsDetails.ToList().FirstOrDefault(x => x.ReceiverApproved == false) == null;
            }
            r.time =new Dto.dtoClasses.Time( report.Hour.Hours,report.Hour.Minutes);
            r.Note = report.Note;
            return r;
        }
        // (ממנו למיקרוסופט (חבר
/*        public static Dal.Models.Report convertFromDtoToMicro(Dto.dtoClasses.ReportsAndDetail report)
        {

            Dal.Models.Report r = new Dal.Models.Report();
            r.Date = report.Date;
            //כאן יש צורך לעשות לולאה עבור כל חברי הפעולה שקבלו.
            //ההמרה מתבצעת לרשימה כדי לגשת למקום הראשון כי יש חבר אחד

            for (int i = 0; i < report.GetterMembers.Capacity; i++)
            {
             r.ReportsDetails.Add(new Dal.Models.ReportsDetail()
            { 
                    GetterMemberId = Dal.functions.memberFun.getMemberByPhone(report.GetterMembers[i].phone).Id,
                    ReceiverApproved = report.ReceiverApproved
                    ,GetterMember = Dal.functions.memberFun.getMemberByPhone(report.GetterMembers[i].phone)
                   
            });
            }
           
            return r;
        }*/
        public static Dal.Models.Report convertFromDtoToMicroWhithRouter(Dto.dtoClasses.ReportsAndDetail report, string categoryName,string phone)
        {
            //Dal.Models.Report r = convertFromDtoToMicro(report);
            //r.Category.CategoryId = Dal.functions.categoryFun.GetAllCategories().FirstOrDefault(c => c.Name == categoryName).Id;
            Dal.Models.Report r = new Dal.Models.Report();
            r.Date = report.Date;
            Dal.Models.Member tempMember = Dal.functions.memberFun.GetAllMembers().FirstOrDefault(m => m.Phone == phone);
            if (tempMember != null)
                r.GiverId = tempMember.Id;
            Dal.Models.MemberCategory c = tempMember.MemberCategories.FirstOrDefault(x => x.Category.Name == categoryName);
            if (c != null)
                r.CategoryId = c.Category.Id;
            //r.Giver = Dal.functions.memberFun.GetAllMembers().FirstOrDefault(m => m.Phone == phone);
            
            r.Hour = new TimeSpan(report.time.hours, report.time.minutes, 0);
            r.Note = report.Note;
            return r;
        }
        // ממיר רשימה של מיקרוסופט אלנו
        public static List<Dto.dtoClasses.ReportsAndDetail> ConvertListFromMicToDto(List<Dal.Models.Report> microMemberList)
        {
            List<Dto.dtoClasses.ReportsAndDetail> lm = new List<Dto.dtoClasses.ReportsAndDetail>();
            microMemberList.ForEach(m => lm.Add(convertFromMicToDto(m)));
            return lm;
        }

        // ממיר רשימה שלנו למיקרוסופט
   /*     public static List<Dal.Models.Report> ConvertListDtoToMic(List<Dto.dtoClasses.ReportsAndDetail> dto)
        {
            List<Dal.Models.Report> mic = new List<Dal.Models.Report>();
            dto.ForEach(m => mic.Add(convertFromDtoToMicro(m)));
            return mic;
        }*/

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
