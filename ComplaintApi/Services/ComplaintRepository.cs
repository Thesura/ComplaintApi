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

        //methods for get requests

        public CompanyMaster GetCompany(string companyId)
        {
            return _context.CompanyMaster.Where(c => c.CompanyID == companyId).FirstOrDefault();
        }

        public ComplainsMaster getComplain(string complainId)
        {
            return _context.ComplainsMaster.Where
                (cm => cm.ComplainID == complainId)
                .FirstOrDefault();
        }

        public ComplainsHistory getComplainsHistory(string historyId, string complainId)
        {
            return _context.ComplainsHistory.Where(ch => ch.HistoryID == historyId && ch.ComplainID == complainId)
                .FirstOrDefault();
        }

        public ModuleMaster getModule(string moduleId)
        {
            return _context.ModuleMaster.Where(m => m.ModuleID == moduleId).FirstOrDefault();
        }

        public PriorityMaster getPriority(string priorityId)
        {
            return _context.PriorityMaster.Where(p => p.PriorityID == priorityId).FirstOrDefault();
        }

        public UserMaster getUser(string empId)
        {
            return _context.UserMaster.Where(u => u.EmpID == empId).FirstOrDefault();
        }

        public UserCompany getUserCompany(string empId, string companyId)
        {
            return _context.UserCompany.Where(uc => uc.EmpID == empId && uc.CompanyID == companyId).FirstOrDefault();
        }

        public UserModule getUserModule(string empId, string moduleId)
        {
            return _context.UserModule.Where(um => um.EmpID == empId && um.ModuleID == moduleId).FirstOrDefault();
        }


        //methods for checking the existence

        public bool companyExists(string companyId)
        {
            return _context.CompanyMaster.Any(c => c.CompanyID == companyId);
        }


        public bool complainHistoryExists(string historyId, string complainId)
        {
            return _context.ComplainsHistory.Any(ch => ch.HistoryID == historyId && ch.ComplainID == complainId);
        }

        public bool moduleExists(string moduleId)
        {
            return _context.ModuleMaster.Any(m => m.ModuleID == moduleId);
        }

        public bool priorityExists(string priorityId)
        {
            return _context.PriorityMaster.Any(p => p.PriorityID == priorityId);
        }

        public bool userCompanyExists(string empId, string companyId)
        {
            return _context.UserCompany.Any(uc => uc.EmpID == empId && uc.CompanyID == companyId);
        }

        public bool userExists(string empId)
        {
            return _context.UserMaster.Any(u => u.EmpID == empId);
        }

        public bool userModuleExists(string empId, string moduleId)
        {
            return _context.UserModule.Any(um => um.EmpID == empId && um.ModuleID == moduleId);
        }


		public bool Save()
		{
			return (_context.SaveChanges() >= 0);
		}


		//methods for delete requests

		public bool CompanyExists(object companyId)
		{
			throw new NotImplementedException();
		}

		public void DeleteCompany(CompanyMaster companyMaster)
		{
			_context.CompanyMaster.Remove(companyMaster);
		}

		public void DeleteModule(ModuleMaster moduleMaster)
		{
			_context.ModuleMaster.Remove(moduleMaster);
		}

		public bool ModuleExists(object moduleId)
		{
			throw new NotImplementedException();
		}

		public void DeletePriority(PriorityMaster priorityMaster)
		{
			_context.PriorityMaster.Remove(priorityMaster);
		}

		public bool PriorityExists(object priorityId)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(UserMaster userMaster)
		{
			_context.UserMaster.Remove(userMaster);
		}

		public bool UserExists(object empId)
		{
			throw new NotImplementedException();
		}

		public void DeleteUserCompany(UserCompany userCompany)
		{
			_context.UserCompany.Remove(userCompany);
		}

		public void DeleteUserModule(UserModule userModule)
		{
			_context.UserModule.Remove(userModule);
		}

        public bool complainExists(string complainId)
        {
            return _context.ComplainsMaster.Any
                (cm => cm.ComplainID == complainId);
        }

        public void DeleteComplain(ComplainsMaster complainsMaster)
        {
            _context.ComplainsMaster.Remove(complainsMaster);
        }

        public void DeleteComplainHistory(ComplainsHistory complainsHistory)
        {
            _context.ComplainsHistory.Remove(complainsHistory);
        }
    }
}
