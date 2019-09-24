﻿using System;
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

        public CompanyMaster GetCompanyMaster(string companyId)
        {
            return _context.CompanyMaster.FirstOrDefault(c => c.CompanyID == companyId);
            //throw new NotImplementedException();
        }

        public ComplainsHistory GetComplainsHistory(string HistoryId)
        {
            throw new NotImplementedException();
        }

        public object GetModule(string moduleId)
        {
            return _context.ModuleMaster.FirstOrDefault(c => c.ModuleID == moduleId);
            // throw new NotImplementedException();
        }

        public ModuleMaster GetModuleMaster(string moduleId)
        {
            return _context.ModuleMaster.FirstOrDefault(c => c.ModuleID == moduleId);
            //throw new NotImplementedException();
        }

        public PriorityMaster GetPriority(string priorityId)
        {
            return _context.PriorityMaster.FirstOrDefault(c => c.PriorityID == priorityId);
            //throw new NotImplementedException();
        }

        public PriorityMaster GetPriorityMaster(string priorityId)
        {
            return _context.PriorityMaster.FirstOrDefault(c => c.PriorityID == priorityId);
            //throw new NotImplementedException();
        }

        public UserMaster GetUser(string empId)
        {
            return _context.UserMaster.FirstOrDefault(c => c.EmpID == empId);
        }

        public UserMaster GetUserMaster(string empId)
        {
            return _context.UserMaster.FirstOrDefault(c => c.EmpID == empId);
            //throw new NotImplementedException();
        }

        public bool HistoryExist(string HistoryID)
        {
            throw new NotImplementedException();
        }

        public bool ModuleExist(string ModuleID)
        {
            throw new NotImplementedException();
        }

        public bool PriorityExist(string PriorityID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
            //throw new NotImplementedException();
        }

        public void UpdateCompanyMaster(CompanyMaster company)
        {
            //throw new NotImplementedException();
        }

        public void UpdateCompanyMaster(UserMaster userMasterForUpdateRepo)
        {
            //throw new NotImplementedException();
        }

        public void UpdateComplainHistory(ComplainsHistory history)
        {
            throw new NotImplementedException();
        }

        public void UpdateComplainsHistory(ComplainsHistory complainsHistoryForUpdateRepo)
        {
            throw new NotImplementedException();
        }

        public void UpdateComplainsMaster(CompanyMaster complainsMasterForUpdateRepo)
        {
            throw new NotImplementedException();
        }

        public void UpdateModuleMaster(ModuleMaster module)
        {
            //throw new NotImplementedException();
        }

        public void UpdatePriorityMaster(PriorityMaster priority)
        {
            //throw new NotImplementedException();
        }

        public void UpdatePriorityMaster(object priorityMasterForUpdateRepo)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserMaster(UserMaster user)
        {
            //throw new NotImplementedException();
        }

        public bool UserExist(string EmpID)
        {
            throw new NotImplementedException();
        }

        object IComplaintRepository.GetPriority(string priorityId)
        {
            return _context.PriorityMaster.FirstOrDefault(c => c.PriorityID == priorityId);
            //throw new NotImplementedException();
        }
    }
}
