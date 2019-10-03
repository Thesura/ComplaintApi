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

        public bool CompanyExist(string CompanyID)
        {
            throw new NotImplementedException();
        }

        public CompanyMaster GetCompany(string companyId)
        {
            return _context.CompanyMaster.FirstOrDefault(c => c.CompanyID == companyId);
        }

        public ComplainsMaster GetComplain(string complainId)
        {
            return _context.ComplainsMaster.FirstOrDefault(c => c.ComplainID == complainId);
        }

        public object GetComplainsMaster(string complainId)
        {
            return _context.ComplainsMaster.FirstOrDefault(c => c.ComplainID == complainId);
        }

        public object GetModule(string moduleId)
        {
            return _context.ModuleMaster.FirstOrDefault(c => c.ModuleID == moduleId);
        }

        public ModuleMaster GetModuleMaster(string moduleId)
        {
            return _context.ModuleMaster.FirstOrDefault(c => c.ModuleID == moduleId);
        }

        public PriorityMaster GetPriority(string priorityId)
        {
            return _context.PriorityMaster.FirstOrDefault(c => c.PriorityID == priorityId);
        }

        public PriorityMaster GetPriorityMaster(string priorityId)
        {
            return _context.PriorityMaster.FirstOrDefault(c => c.PriorityID == priorityId);
        }

        public UserMaster GetUser(string empId)
        {
            return _context.UserMaster.FirstOrDefault(c => c.EmpID == empId);
        }

        public UserMaster GetUserMaster(string empId)
        {
            return _context.UserMaster.FirstOrDefault(c => c.EmpID == empId);
        }

        public ComplainsHistory GetComplainsHistory(string historyId)
        {
            return _context.ComplainsHistory.FirstOrDefault(c => c.HistoryID == historyId); ;
        }

        public bool HistoryExist(string HistoryID)
        {
            throw new NotImplementedException();
        }

        public bool ModuleExist(string ModuleID)
        {
            throw new NotImplementedException();
        }

        public bool ComplainExist(string ComplainID)
        {
            throw new NotImplementedException();
        }

        public bool PriorityExist(string PriorityID)
        {
           return _context.PriorityMaster.Any(o => o.PriorityID == PriorityID);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCompanyMaster(CompanyMaster company)
        {
            //throw new NotImplementedException();
        }

        public void UpdateCompanyMaster(UserMaster userMasterForUpdateRepo)
        {
            //throw new NotImplementedException();
        }

        public void UpdateComplainsMaster(ComplainsMaster complain)
        {   
        }

        public void UpdateModuleMaster(ModuleMaster module)
        {    
        }

        public void UpdatePriorityMaster(PriorityMaster priority)
        {   
        }

        public void UpdateUserMaster(UserMaster user)
        {    
        }

        public bool UserExist(string EmpID)
        {
            throw new NotImplementedException();
        }

        public void UpdateComplainsMaster(object complainsMasterForUpdateRepo)
        {
            throw new NotImplementedException();
        }

        public void complainsHistoryExist(string HistoryID)
        {
        }

        public void UpdateComplainsHistory(ComplainsHistory complain)
        {
            throw new NotImplementedException();
        }

        public void UpdateComplainsHistory(object complainsHistoryForUpdateRepo)
        {
            throw new NotImplementedException();
        }

        public bool ComplainHistoryExist(string HistoryId)
        {
            throw new NotImplementedException();
        }

        public ComplainsHistory GetComplainsHistory(string historyId, string complainId)
        {
            throw new NotImplementedException();
        }

        public bool complainsHistoryExist(string HistoryID, string ComplainID)
        {
            throw new NotImplementedException();
        }

        public void addComplainsHistory(ComplainsHistory complainshistoryEntity)
        {
            throw new NotImplementedException();
        }
    }
}
