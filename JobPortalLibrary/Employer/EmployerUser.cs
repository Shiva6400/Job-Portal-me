﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalLibrary.Employer
{
   public class EmployerUser
    {
        public int EmployerId { get; set; }

        public string EmployerName { get; set; }

        public string Employercode { get; set; }

        public string EmailId { get; set; }

        public Int64 ContactNo { get; set; }

        public string Password { get; set; }

        public int isDelete { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string NoOfEmplees { get; set; }

        public string CompanyWebsite { get; set; }

        public string AboutCompany { get; set; }

        public int IndustryId { get; set; }

        public string Location { get; set; }

        public int Pincode { get; set; }

        public string CompanyLogo { get; set; }

        public string Porfolio { get; set; }

        public string Slogan { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string LinkedIn { get; set; }

        public string Instagram { get; set; }

        public string Google { get; set; }

        public string OwnerName { get; set; }

        public string HRName { get; set; }

        public string HREmail { get; set; }

        public string Source { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string IndustryName { get; set; }

        public int PostJobId { get; set; }

        public string PostJobCode { get; set; }

        public string OpportunityType { get; set; }

        public string JobTitle { get; set; }

        public int JobCategoryId { get; set; }

        public string JobDescription { get; set; }

        public string JobLocation { get; set; }

        public string Address { get; set; }

        public string JobType { get; set; }

        public string RequiredQualificationId { get; set; }

        public string WorkingShifts { get; set; }

        public string SalaryType { get; set; }

        public string SalaryRange { get; set; }

        public string Salary { get; set; }

        public string JobBenifitId { get; set; }

        public int CollectResume { get; set; }

        public string TotalExperience { get; set; }

        public DateTime ExpectedJoiningDate { get; set; }

        public DateTime ApplicationStartDate { get; set; }

        public DateTime ApplicationEndDate { get; set; }

        public int StatusId { get; set; }

        public string RejectionReason { get; set; }

        public string RequireQualification { get; set; }

        public string JobBenifit { get; set; }

        public int AppliedJobId { get; set; }

        public string Seekercode { get; set; }

        public int InterviewId { get; set; }

        public int RoundId { get; set; }

        public string Comment { get; set; }

        public string RoundName { get; set; }

        public string JobCategory { get; set; }

        public int ShareId { get; set; }

        public string Share { get; set; }

        public string ContactPerson { get; set; }

        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int QualificationId { get; set; }

        public string Qualification { get; set; }

        public int DegreeId { get; set; }

        public string Degree { get; set; }

        public int SpecializationId { get; set; }

        public string Specialization { get; set; }

        public string Language { get; set; }

        public string Status { get; set; }

        public string SkillName { get; set; }
        
    }
}
