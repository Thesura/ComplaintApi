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
    }
}
