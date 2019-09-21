using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintApi.Entities;

namespace ComplaintApi.Services
{
    public class ComplaintRepository : IComplaintRepository
    {
        private ComplaintContext _context;

        public ComplaintRepository(ComplaintContext context)
        {
            _context = context;
        }
        public CompanyMaster GetCompany(string companyId)
        {
            return _context.CompanyMaster.FirstOrDefault(c => c.CompanyID == companyId);
        }
    }
}
