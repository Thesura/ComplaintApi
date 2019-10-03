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

        bool ComplainHistoryExist(string HistoryId);

        void UpdateCompanyMaster(CompanyMaster company);

        bool Save();
        
        bool HistoryExist(string HistoryID);

        object GetModule(string moduleId);
        PriorityMaster GetPriority(string priorityId);

        //ComplainsHistory Repo
        ComplainsHistory GetComplainsHistory(string historyId,string complainId);
        bool complainsHistoryExist(string HistoryID,string ComplainID);
        void UpdateComplainsHistory(ComplainsHistory complain);
        
        //modulemaster Repo
        ModuleMaster GetModuleMaster(string moduleId);
        bool ModuleExist(string ModuleID);
        void UpdateModuleMaster(ModuleMaster module);
        
        //priorityMaster Repo
        PriorityMaster GetPriorityMaster(string priorityId);
        bool PriorityExist(string PriorityID);
        void UpdatePriorityMaster(PriorityMaster priority);
        
        //ComplainsMaster Repo
        object GetComplainsMaster(string complainId);
        void UpdateComplainsMaster(ComplainsMaster complain);
        void UpdateComplainsMaster(object complainsMasterForUpdateRepo);

        void UpdateComplainsHistory(object complainsHistoryForUpdateRepo);

        //usermaster Repo
        UserMaster GetUser(string empId);
        void UpdateUserMaster(UserMaster user);
        void addComplainsHistory(ComplainsHistory complainshistoryEntity);
    }
}
