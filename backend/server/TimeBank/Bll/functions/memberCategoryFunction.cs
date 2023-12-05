using Bll.converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class memberCategoryFunction
    {
        public static void addMemberCategory(Dto.dtoClasses.categoryMember mcnew, string phoneOfMember,string categoryName)
        {
            Dal.functions.categoryMemberFun.addMemberCategory(Bll.converters.categoryMemberConvert.
                convertFromDtoToMicroWhithRouter(mcnew, phoneOfMember,categoryName));

        }
        public static  List<Dto.dtoClasses.catPlusMember> getAllCategoriesMember()
        {
             List<Dal.Models.MemberCategory> dDal = Dal.functions.categoryMemberFun.getAllCategoriesMember();
             List<Dto.dtoClasses.catPlusMember> d = new List<Dto.dtoClasses.catPlusMember>();
            foreach (var item in dDal)
            {
                d.Add(catPlusMemberConvert.convertFromMicToDto(item));
            }
            return d;
        }

        public static List<Dto.dtoClasses.catPlusMember> GetFilteredMemberCategories(Dto.dtoClasses.catPlusMember filter)
        {
          List<Dal.Models.MemberCategory> MC = Dal.functions.categoryMemberFun.GetFilteredMemberCategories( filter.memGiverName, filter.memPhone,  filter.memEmail,filter.memAddress,filter.memGender,
            filter.Category.name,filter.Place,filter.PossibilityComeCustomerHome, filter.ExperienceYears, filter.RestrictionsDescription, filter.ForGroup, filter.MinGruop, filter.MaxGroup);
             List<Dto.dtoClasses.catPlusMember> d = new List<Dto.dtoClasses.catPlusMember>();
            foreach (var item in MC)
            {
                d.Add( catPlusMemberConvert.convertFromMicToDto(item));
            }
            return d;
        }
    }
}
