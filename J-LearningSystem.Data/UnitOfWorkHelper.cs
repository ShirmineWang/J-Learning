using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace J_LearningSystem.Data
{
    public class UnitOfWorkHelper
    {
        public static UnitOfWork GetUnitOfWork()
        {
            UnitOfWork uow = CallContext.GetData(typeof(UnitOfWork).Name) as UnitOfWork;
            if (uow == null)
            {
                uow = new UnitOfWork();
                CallContext.SetData(typeof(UnitOfWork).Name, uow);
            }
            return uow;
        }
        
    }
}
