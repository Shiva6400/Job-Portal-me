using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using JobPortalLibrary.JobSeeker;


namespace JobPortalLibrary.JobSeeker
{
    public class BALSeeker
    {
        SqlConnection con = new SqlConnection("Data Source=SANKET;Initial Catalog=\"Job Portal\";Integrated Security=True");

        public DataSet FindJobs(SeekerUser objsekUser /*string postjobcode*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag","FindJobs");
            //cmd.Parameters.AddWithValue("@PostJobCode", postjobcode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        //------------------Search Jobs-------------------------------------------------//
        public DataSet FindJobs1(SeekerUser objsekUser /*string jobtitle,string joblocation,string salary*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FindJobs1");
            
            cmd.Parameters.AddWithValue("@JobTitle", objsekUser.JobTitle);
            cmd.Parameters.AddWithValue("@JobLocation", objsekUser.JobLocation);
            cmd.Parameters.AddWithValue("@Salary", objsekUser.Salary);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        //--------ApplyButton Jobs Popup---------------------------------//
        public SqlDataReader ApplyJobView(SeekerUser objsekUser /*string PostJobCode*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ApplyJobView");
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        //-----------------ResumePDF----------------------------------------------//

        public void SubmitPDF(SeekerUser objsekUser /*string seekercode, string postjobcode, int statusid, DateTime applieddate, string resumepdf*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SubmitPDF");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            cmd.Parameters.AddWithValue("@PostJobCode", objsekUser.PostJobCode);
            cmd.Parameters.AddWithValue("@StatusID", objsekUser.StatusId);
            cmd.Parameters.AddWithValue("@AppliedDate", objsekUser.AppliedDate);
            cmd.Parameters.AddWithValue("@ResumePDF", objsekUser.ResumePDF);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //----------ApplicationGriview--------------------------//
        public DataSet ApplicationGrid(SeekerUser objsekUser /*string seekercode*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ApplicationGrid");
            cmd.Parameters.AddWithValue("@Seekercode", objsekUser.Seekercode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        //------------DeleteButtononGrid----------------//
        public void IsDelete(SeekerUser objsekUser /*int jobappliedid*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "IsDelete");
            cmd.Parameters.AddWithValue("@AppliedJobId",objsekUser.AppliedJobID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //-----------StatusUpdateonJobSubmit-----------//
        
        public SqlDataReader SubmitApplication(SeekerUser objsekUser /*int  jobappliedid,int statusid*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SubmitApplication");
            cmd.Parameters.AddWithValue("@StatusID", objsekUser.StatusId);
            cmd.Parameters.AddWithValue("@AppliedJobId", objsekUser.AppliedJobID);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        //------------------DownloadPDF------------------------//
        public SqlDataReader DownloadPDF(SeekerUser objsekUser  /*int seekerid*/)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DownloadPDF");          
            cmd.Parameters.AddWithValue("@SeekerId", objsekUser.SeekerId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
    }



}
