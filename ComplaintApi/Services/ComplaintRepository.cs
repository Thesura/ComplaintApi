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
            return _context.CompanyMaster.Where(c => c.CompanyID == companyId).FirstOrDefault();
        }

        public ComplainsMaster getComplains(string companyId, string moduleId, string empId, string priorityId)
        {
            throw new NotImplementedException();
        }

        public ComplainsHistory getComplainsHistory(string historyId, string complainId)
        {
            throw new NotImplementedException();
        }

        public ModuleMaster getModule(string moduleId)
        {
            throw new NotImplementedException();
        }

        public PriorityMaster getPriority(string priorityId)
        {
            throw new NotImplementedException();
        }

        public UserMaster getUser(string empId)
        {
            throw new NotImplementedException();
        }

        public UserCompany getUserCompany(string empId, string companyId)
        {
            throw new NotImplementedException();
        }

        public UserModule getUserModule(string empId, string moduleId)
        {
            throw new NotImplementedException();
        }
    }
}
