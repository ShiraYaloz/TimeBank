using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TimeBank.Controllers
{
    public class postReport
    {
        public string phone { get; set; }
        public string categoryName { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class reportController : ControllerBase
    {
        [HttpPost("addReport/{phone}/{categoryName}")]
        public ActionResult<bool> addReport(string phone, string categoryName, Dto.dtoClasses.ReportsAndDetail rep)
        {
            //add checking of all the details if null exc.

            if (rep == null || rep.GetterMembers == null || rep.GetterMembers.Count == 0
                || rep.time.hours == 0 && rep.time.minutes == 0)
                return Ok(false);
            bool isCorrectInput = Bll.functions.reportFunction.addReport(phone, categoryName, rep);
            return Ok(isCorrectInput);
        }

        [HttpPut("getterAproveReport/{phone}/{reportId}")]
        public ActionResult<int> getterAproveReport(string phone , short reportId)
        {
            try
            {
                int sec = Bll.functions.reportFunction.getterAproveReport(phone, reportId);
                /*פה לקרוא לפונקציות של השכבות מתחת שלוקחות את החבר שנשלח ופשוט משנות את הערך של צק לשקר*/
                return Ok(sec);
            }
            catch
            { return BadRequest(0); }

        }




    }
}

