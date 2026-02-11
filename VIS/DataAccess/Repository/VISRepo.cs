using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class VISRepo : IVISRepo
    {
        private VISDbContext _dbContext;

        public VISRepo()
        {
            _dbContext = new VISDbContext();
        }

        public bool AddCity(City city)
        {

            if (city == null)
            {
                return false;
            }

            try
            {
                _dbContext.Cities.Add(city);
                _dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<City> GetCityList()
        {
            return _dbContext.Cities.ToList();
        }

        public bool AddVoter(Voter voter)
        {

            if (voter == null)
            {
                return false;
            }

            try
            {
                _dbContext.Voters.Add(voter);
                _dbContext.SaveChanges();
            }
            catch { return false; }
            return true;

        }

        public bool DeleteVoter(int id)
        {
            Voter voter = null;

            try
            {
                voter = _dbContext.Voters.Find(id);
                _dbContext.Voters.Remove(voter);
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
            
        }

        public Voter FindByPK(int id)
        {

            Voter voters = null;
            try
            {
                voters = _dbContext.Voters.Find(id);
            }
            catch
            {
                return null;
            }
            return voters;
        }


        public List<Voter> GetVoterList()
        {
            return _dbContext.Voters.ToList();
        }

        public bool UpdateVoter(Voter votersinfo) {

            if (votersinfo == null) { 
               return false;
            }

            Voter voters = null;

            try {
                voters = _dbContext.Voters.Find(votersinfo.VoterId);
                //voters.State = votersinfo.State;
                voters.Age = votersinfo.Age;
                voters.VoterName = votersinfo.VoterName;
                voters.City = votersinfo.City;
                voters.Dob = votersinfo.Dob;
                voters.MobileNumber = votersinfo.MobileNumber;
                voters.Gender = votersinfo.Gender;
                voters.EmailId = votersinfo.EmailId;
                _dbContext.SaveChanges();  
            }
            catch { return false; }
            return true;

        }

        public AdminUser ValidateUser(string emailId, string password) { 
         
            AdminUser adminuser = null;

            try {
              adminuser = _dbContext.AdminUsers.Where(u=>u.EmailId == emailId && u.Password == password).FirstOrDefault();
            }

            catch {
            }

            return adminuser;
         
        }
    }

}
