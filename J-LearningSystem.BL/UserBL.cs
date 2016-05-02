using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearningSystem.Data;

namespace J_LearningSystem.BL
{
    public class UserBL
    {
        private static readonly Lazy<UserBL> lazy =
            new Lazy<UserBL>(() => new UserBL());

        public static UserBL Instance { get { return lazy.Value; } }

        private UserBL()
        {
            UnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
        }
    }
}
