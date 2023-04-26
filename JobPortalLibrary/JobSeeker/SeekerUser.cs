using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace JobPortalLibrary.JobSeeker
{
    public class SeekerUser
    {
        public int SeekerId { get; set; }

        public string Seekercode { get; set; }

        public string SeekerName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public Int64 ContactNo { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string CorrespondenceAddress { get; set; }

        public string PermanantAddress { get; set; }

        public int Pincode { get; set; }

        public int CityId { get; set; }

        public string LanguageId { get; set; }

        public int PhysicallyChallenged { get; set; }

        public string CasteCategory { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string ProfileSummary { get; set; }

        public int StatusId { get; set; }

        public string ResumePDF { get; set; }

        public string ProfileIMG { get; set; }

        public int isDelete { get; set; }

        public int EmployementId { get; set; }

        public int CurrentEmployement { get; set; }

        public string EmployementType { get; set; }

        public string CompanyName { get; set; }

        public string Designation { get; set; }

        public string JoiningDate { get; set; }

        public string CurrentSalary { get; set; }

        public string SkillId { get; set; }

        public string JobProfile { get; set; }

        public string NoticePeriod { get; set; }

        public int ProjectId { get; set; }  

        public string ProjectTitle { get; set; }

        public string ClientName { get; set; }

        public string ProjectStatus { get; set; }

        public string TotalExperience { get; set; }

        public string ProjectDetails { get; set; }

        public int QualificationId { get; set; }

        public string Qualification { get; set; }

        public int DegreeId { get; set; }

        public string Degree { get; set; }

        public int SpecializationId { get; set; }

        public string Specialization { get; set; }

        public string Language { get; set; }

        public string Status { get; set; }

        public string SkillName { get; set; }

        public int PassingYear { get; set; }

        public int Marks { get; set; }
        public string University { get; set; }

        public int JobAlertId { get; set; }

        public string AlertKeyword { get; set; }

        public int ReviewId { get; set; }

        public int CompanyId { get; set; }

        public string Employercode { get; set; }

        public int Rating { get; set; }

        public string Review { get; set; }

        public int Follow { get; set; }

        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        //--------------Sanket Changes for Job Search----------------//
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public string Salary { get; set; }
        public string JobType { get; set; }
        public string EndDate { get; set; }
        public string PostJobCode { get; set; }
        public string JobDescription { get; set; }
        public DateTime AppliedDate { get; set; }
        public int AppliedJobID { get;set; }

        public string UploadFile { get; set; }
        
        public List<SeekerUser> user { get; set; }
        
    }
}
