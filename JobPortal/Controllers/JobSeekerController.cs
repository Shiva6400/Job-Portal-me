using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using JobPortalLibrary.JobSeeker;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FluentEmail.Core.Defaults;
using System.Runtime.Remoting.Messaging;
using System.Net.Mime;
using System.Web.Services.Description;

namespace JobPortal.Controllers
{
    public class JobSeekerController : Controller
    {
     
        // GET: JobSeeker
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult SeekerIndex()
        {

            return View();
        }

        [HttpGet]
        public async Task <ActionResult> Search()
        {

            //string postJobCode = "PJC0001";
            //BALSeeker ObjBal = new BALSeeker();
            //DataSet ds = new DataSet();
            //ds = ObjBal.FindJobs(postJobCode);
            //SeekerUser objDetails = new SeekerUser();
            //objDetails.PostJobCode = postJobCode;
            //List<SeekerUser> lstUserDt1 = new List<SeekerUser>();
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    SeekerUser obju = new SeekerUser();
            //    obju.JobTitle = ds.Tables[0].Rows[i]["JobTitle"].ToString();
            //    obju.JobLocation = ds.Tables[0].Rows[i]["JobLocation"].ToString();
            //    obju.SalaryRange = ds.Tables[0].Rows[i]["SalaryRange"].ToString();

            //    lstUserDt1.Add(obju);
            //}

            //objDetails.user = lstUserDt1;
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task <ActionResult> Search(SeekerUser obj ,string jobTitle, string jobLocation, string salary)
        
        {
            SeekerUser obj1 = new SeekerUser();

            obj.JobTitle = jobTitle;
            obj.Salary = salary;
            obj.JobLocation = jobLocation;
            BALSeeker ObjBal = new BALSeeker();
            DataSet ds = new DataSet();
            ds = ObjBal.FindJobs1(obj);
            SeekerUser objDetails = new SeekerUser();
            //objDetails.PostJobCode = "postJobCode";
            List<SeekerUser> lstUserDt1 = new List<SeekerUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SeekerUser obju = new SeekerUser();
                obju.PostJobCode = ds.Tables[0].Rows[i]["PostJobCode"].ToString();
                obju.JobTitle = ds.Tables[0].Rows[i]["JobTitle"].ToString();
                obju.JobLocation = ds.Tables[0].Rows[i]["Location1"].ToString();
                obju.Salary = ds.Tables[0].Rows[i]["Salary"].ToString();
                obju.JobType = ds.Tables[0].Rows[i]["JobType"].ToString();
                obju.EndDate = ds.Tables[0].Rows[i]["ApplicationEndDate"].ToString();

                lstUserDt1.Add(obju);
            }

            objDetails.user = lstUserDt1;
            return await Task.Run(() => View(objDetails));
        }

        public async Task<ActionResult> SeekerSearch()
        {

            return View();
        }

        //-------------ApplyJobsDr--------------------------//

        [HttpGet]
        public async Task<ActionResult> ApplyJobs(SeekerUser obj , string postJobCode)
        {

            obj.PostJobCode = postJobCode;
            BALSeeker obj1 = new BALSeeker();
            SqlDataReader dr;
            dr = obj1.ApplyJobView(obj);
            while (dr.Read())
            {
                obj.PostJobCode = dr["PostJobCode"].ToString();
                obj.JobTitle = dr["JobTitle"].ToString();
                obj.CompanyName = dr["CompanyName"].ToString();
                obj.JobLocation = dr["Location1"].ToString();
                obj.JobType = dr["JobType"].ToString();
                obj.Salary = dr["Salary"].ToString();
                obj.JobDescription = dr["JobDescription"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView(obj));

        }

        //---------------SubmitPDF---------------------------------------//
        [HttpPost]
        public async Task<ActionResult> SubmitPDF( HttpPostedFileBase myFile)
        {
            
            SeekerUser obj = new SeekerUser();
            string seekercode = "JSC0001";
            obj.StatusId = 9;
            obj.Seekercode = seekercode;
            obj.AppliedDate = DateTime.Now;
            BALSeeker obj1 = new BALSeeker();
           
            
            if  (myFile != null && myFile.ContentLength > 0)
            {

                string fileName = Path.GetFileName(myFile.FileName);
                string path = Server.MapPath("~/Content/PDF Files");
                string ResumePath = Path.Combine(path, fileName);
                myFile.SaveAs(ResumePath);
                obj.ResumePDF = fileName;
                obj1.SubmitPDF(obj);

                TempData["notice"] = "OK! The file is uploaded";

            }
            

            return await Task.Run(() => RedirectToAction("Search"));

        }

        //------------ApplicationGrid-----------------------------------------//

        [HttpGet]
        public async Task<ActionResult> ApplicationGrid(SeekerUser obj1)
        {
             string seekercode = "JSC0001";
            obj1.Seekercode = seekercode;
            SeekerUser objss = new SeekerUser();
            BALSeeker objUser = new BALSeeker();
            DataSet ds = new DataSet();
            ds = objUser.ApplicationGrid(obj1);
            SeekerUser objDetails = new SeekerUser();
            List<SeekerUser> LstUser = new List<SeekerUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SeekerUser obj = new SeekerUser();
                //obj.Seekercode = ds.Tables[0].Rows[i]["Seekercode"].ToString();
                obj.JobTitle = ds.Tables[0].Rows[i]["JobTitle"].ToString();
                obj.AppliedJobID = Convert.ToInt32(ds.Tables[0].Rows[i]["AppliedJobID"].ToString());
                obj.AppliedDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["AppliedDate"].ToString());
                obj.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                obj.ResumePDF = ds.Tables[0].Rows[i]["ResumePDF"].ToString();
                obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                LstUser.Add(obj);
            }
            ViewBag.ResumePDF = obj1.ResumePDF;
            objDetails.user = LstUser;
            return await Task.Run(() => View(objDetails));
        }

        //-----------------DeleteApplication---------------------------------------//

        [HttpGet]
        public async Task<ActionResult> IsDelete( SeekerUser obj)
        {
            
            BALSeeker obj1 = new BALSeeker();
            obj1.IsDelete(obj);
            return await Task.Run(() => RedirectToAction("ApplicationGrid"));

        }
        
        //--------------------------SubmitApplication------------------------------//

        [HttpPost]
        public async Task<ActionResult> SubmitApplication(SeekerUser obj, int jobappliedid, int statusid)
        {
            SeekerUser objs = new SeekerUser();
            obj.AppliedJobID = jobappliedid;
            BALSeeker obj1 = new BALSeeker();
            SqlDataReader dr;
            dr = obj1.SubmitApplication(obj);
            while (dr.Read())
            {
                obj.StatusId = Convert.ToInt32(dr["StatusID"].ToString());
                obj.AppliedJobID = Convert.ToInt32(dr["AppliedJobID"].ToString());
                
            }
            dr.Close();
            return await Task.Run(() => PartialView("ApplyJobs"));
        }

        //--------------------DownloadPDF--------------------------//

        [HttpGet]
        public FileResult DownloadPDF(int seekerid)
        {
           
            SeekerUser obj = new SeekerUser();
            obj.SeekerId = seekerid;
            BALSeeker obj1 = new BALSeeker();
            SqlDataReader dr;
            dr=obj1.DownloadPDF(obj);
            
            while (dr.Read())
            {
                obj.SeekerId = Convert.ToInt32(dr["JobSeekerCode"].ToString());
            }
            dr.Close();
            
            List<SeekerUser> ObjFiles = new List<SeekerUser>(obj.SeekerId);

            var FileById = (from FC in ObjFiles
                            where FC.SeekerId.Equals(seekerid)
                            select new { FC.ResumePDF, FC.UploadFile }).ToList().FirstOrDefault();

            return File(FileById.UploadFile, "application/pdf", FileById.ResumePDF);

        }
    }
}