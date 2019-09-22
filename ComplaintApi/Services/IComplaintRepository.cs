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

        UserMaster getUser(string empId);

        ModuleMaster getModule(string moduleId);

        PriorityMaster getPriority(string priorityId);

        UserCompany getUserCompany(string empId, string companyId);

        UserModule getUserModule(string empId, string moduleId);

        ComplainsMaster getComplains(string companyId, string moduleId, string empId, string priorityId);

        ComplainsHistory getComplainsHistory(string historyId, string complainId);

    }
}
