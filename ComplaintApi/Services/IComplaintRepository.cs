﻿using ComplaintApi.Entities;
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

        IEnumerable<CompanyMaster> GetCompanyMasters();

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

        ComplainsMaster getComplain(string complainId);

        bool complainExists(string complainId);

        ComplainsHistory getComplainsHistory(string historyId, string complainId);
        IEnumerable<UserMaster> getUsers();
       
        bool complainHistoryExists(string historyId, string complainId);
        
        IEnumerable<PriorityMaster> getPriorities();
        

        IEnumerable<ComplainsMaster> getAllComplains();

        IEnumerable<UserCompany> getAllUserCompany();

        IEnumerable<ModuleMaster> getAllModules();
        /*IEnumerable<ComplainsHistory> getComplainHistories();*/

        //void UpdateCompany(CompanyMaster company);
        void UpdateCompany(IEnumerable<CompanyMaster> companyFromRepo);
        bool Save();
    }
}
