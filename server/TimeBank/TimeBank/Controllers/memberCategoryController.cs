using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeBank.Controllers
{
     public class para
    {
        public string phone { get; set; }
        public string catName { get; set; }
        public Dto.dtoClasses.categoryMember newMemberCat { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class memberCategoryController : ControllerBase
    {//בפוסט שולחים רק משתנה אחד! בגט אפשר שתים בURL אבל אם אצ רוצה בפוסט-תצרי מערך
        [HttpPost("addMemberCategory")]
        public ActionResult<Dto.dtoClasses.categoryMember> addMemberCategory
            (para PhoneAndCatName)
        {
            Dto.dtoClasses.categoryMember newMemberCat = PhoneAndCatName.newMemberCat;
            string memberPhone = PhoneAndCatName.phone;
            string categoryName = PhoneAndCatName.catName;
            try
            {
                
                  Bll.functions.memberCategoryFunction.addMemberCategory(newMemberCat, memberPhone, categoryName);
                    return Ok(newMemberCat);
            }
            catch
            { return null; }

        }

        [HttpGet("getAllMemberCategory")]

        public ActionResult<List<Dto.dtoClasses.catPlusMember>> getAllMemberCategory()
        {
             List<Dto.dtoClasses.catPlusMember> catPlusMembers = Bll.functions.memberCategoryFunction.getAllCategoriesMember();
            return Ok(catPlusMembers);
        }
    
        [HttpGet("getFilterMemberCategory")]

        public ActionResult<List<Dto.dtoClasses.catPlusMember>> getFilterMemberCategory(Dto.dtoClasses.catPlusMember filter)
        {
            List<Dto.dtoClasses.catPlusMember> catPlusMembers = Bll.functions.memberCategoryFunction.GetFilteredMemberCategories(filter);
            return Ok(catPlusMembers);
        }
    }
}
