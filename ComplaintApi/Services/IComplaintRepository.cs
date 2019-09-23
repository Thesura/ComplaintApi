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

        bool CompanyExist(string CompanyID);

        void UpdateCompanyMaster(CompanyMaster company);

        bool Save();
        //modulemaster Repo

        ComplainsHistory GetComplainsHistory(string HistoryId);

        bool HistoryExist(string HistoryID);

        void UpdateComplainHistory(ComplainsHistory history);

        //void UpdateComplainsHistory(ComplainsHistory complainsHistoryForUpdateRepo);

        ModuleMaster GetModuleMaster(string moduleId);

        bool ModuleExist(string ModuleID);

        void UpdateModuleMaster(ModuleMaster module);
        //prioritymaster Repo
        PriorityMaster GetPriorityMaster(string priorityId);

        bool PriorityExist(string PriorityID);

        void UpdatePriorityMaster(PriorityMaster priority);
        void UpdateComplainsMaster(CompanyMaster complainsMasterForUpdateRepo);
        void UpdateComplainsHistory(ComplainsHistory complainsHistoryForUpdateRepo);
    }
}
