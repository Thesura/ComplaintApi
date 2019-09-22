using ComplaintApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Services
{
    public interface IComplaintRepository
    {
        CompanyMaster GetCompany(string companyId);

        bool companyExists(string companyId);

        UserMaster getUser(string empId);

        bool userExists(string empId);

        ModuleMaster getModule(string moduleId);

        bool moduleExists(string moduleId);

        PriorityMaster getPriority(string priorityId);

        bool priorityExists(string priorityId);

        UserCompany getUserCompany(string empId, string companyId);

        bool userCompanyExists(string empId, string companyId);

        UserModule getUserModule(string empId, string moduleId);

        bool userModuleExists(string empId, string moduleId);

        ComplainsMaster getComplain(string companyId, string moduleId, string empId, string priorityId);

        bool complainExists(string companyId, string moduleId, string empId, string priorityId);

        ComplainsHistory getComplainsHistory(string historyId, string complainId);

        bool complainHistoryExists(string historyId, string complainId);

    }
}
