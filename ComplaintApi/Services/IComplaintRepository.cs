using ComplaintApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Services
{
    public interface IComplaintRepository
    {
        //companyMaster Repo
        CompanyMaster GetCompany(string companyId);

        ComplainsMaster GetComplain(string complainId);

        bool CompanyExist(string CompanyID);

        void UpdateCompanyMaster(CompanyMaster company);

        bool Save();
        
        ComplainsHistory GetComplainsHistory(string HistoryId, string complainId);

        bool HistoryExist(string HistoryID);

        object GetModule(string moduleId);
        PriorityMaster GetPriority(string priorityId);

        //ComplainsHistory Repo
        void UpdateComplainHistory(ComplainsHistory history);
        void UpdateComplainsHistory(ComplainsHistory complainsHistoryForUpdateRepo);

        //modulemaster Repo
        ModuleMaster GetModuleMaster(string moduleId);
        bool complainHistoryExists(string historyId, string complainId);
        bool ModuleExist(string ModuleID);
        void UpdateModuleMaster(ModuleMaster module);

        object getComplainsHistory(string historyId, string complainId);
        
        //priorityMaster Repo
        PriorityMaster GetPriorityMaster(string priorityId);
        bool PriorityExist(string PriorityID);
        void UpdatePriorityMaster(PriorityMaster priority);
        void UpdateComplainsMaster(object complainsMasterForUpdateRepo);

        //ComplainsMaster Repo
        object GetComplainsMaster(string complainId);
        void UpdateComplainsMaster(ComplainsMaster complain);

        //usermaster Repo
        UserMaster GetUser(string empId);
        void UpdateUserMaster(UserMaster user); 
    }
}
