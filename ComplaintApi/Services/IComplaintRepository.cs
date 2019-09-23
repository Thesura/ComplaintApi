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
        ModuleMaster GetModuleMaster(string moduleId);

        bool ModuleExist(string ModuleID);

        void UpdateModuleMaster(ModuleMaster module);
    }
}
