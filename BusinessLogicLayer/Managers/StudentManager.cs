using BusinessLogicLayer.Helper;
using BusinessLogicLayer.Messages;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork;
using Entities.SchoolStakeholders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Managers
{
    internal class StudentManager : BaseManager<Student>
    {
        internal StudentManager() : base()
        {
            repo = work.GetStudentRepository();
        }
        
        internal ResponseCodeMessage AddStudent(Student student)
        {
            try
            {
                work.BeginTransaction();
                var result = repo.Insert(student);
                if (result != null && result.Id > 0)
                {
                    work.CommitTransaction();
                    return BusinessHelper.GetResponse(ReponseCode.SUCCESS);
                }
                else
                {
                    work.RollbackTransaction();
                    return BusinessHelper.GetResponse(ReponseCode.DATABASE_ERROR);
                }
            }
            catch (Exception ex)
            {
                SystemLogger.SystemLogger.LogException(ex);
                return BusinessHelper.GetResponse(ReponseCode.GENERAL_ERROR);
            }
        }
    }
}
