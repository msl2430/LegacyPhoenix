using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace IRF
{
    public partial class load_csv : System.Web.UI.Page
    {
        private string TempFileName =  String.Concat(HttpContext.Current.Server.MapPath("CSVFile"), "/temp.csv");
        
        public int QueuedCases { get; set; }
        public int ProcessedCases { get; set; } 

        protected void Page_Load(object sender, EventArgs e)
        {
            grvQueue.DataSource = GetQueue();
            grvQueue.DataBind();
            grvProcessed.DataSource = GetProcessed();
            grvProcessed.DataBind();
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (fileCSV.HasFile)
            {
                Match regexMatch = Regex.Match(fileCSV.FileName, @"\.(csv)$", RegexOptions.IgnoreCase);
                if (regexMatch.Success)
                {
                    fileCSV.SaveAs(TempFileName);
                    LoadCSV(TempFileName);
                    File.Delete(TempFileName);
                }
                else
                {
                    lblErrorMsg.InnerText = "This file format is not supported. Please select a CSV (*.csv) file.";
                    divError.Visible = true;
                    divSuccess.Visible = false;
                }
            }
            else
            {
                lblErrorMsg.InnerText = "A file must be selected.";
                divError.Visible = true;
                divSuccess.Visible = false;
            }
            grvQueue.DataSource = GetQueue();
            grvQueue.DataBind();
        }

        private void LoadCSV(string Path)
        {
            int count = 0;
            try
            {  
                using (StreamReader fStream = new StreamReader(Path))
                {
                    while(fStream.Peek() != -1)
                    {
                        InsertCaseNumber(fStream.ReadLine());
                        count++;
                    }
                }
                lblSuccessMsg.InnerText = String.Format("Successfully added {0} {1}.", count.ToString(), (count == 1) ? "case" : "cases");
                divSuccess.Visible = true;
                divError.Visible = false;

            }
            catch (Exception ex)
            {
                lblErrorMsg.InnerText = ex.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        
        private void InsertCaseNumber(string casenumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(@"INSERT INTO IRFCaseQueue VALUES (@CaseNumber, @Date, @Time)");
            db.AddInParameter(cmd, "CaseNumber", DbType.String, casenumber);
            db.AddInParameter(cmd, "Date", DbType.Date, DateTime.Now.Date.ToString());
            db.AddInParameter(cmd, "Time", DbType.Time, DateTime.Now.TimeOfDay.ToString());
            
            db.ExecuteNonQuery(cmd);
        }

        private DataTable GetQueue()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(@"SELECT CaseNumber, CAST(CAST([Date] AS VARCHAR(15)) + ' ' + CAST([Time] AS VARCHAR(25)) AS DATETIME) AS 'tempTime' FROM IRFCaseQueue ORDER BY 'tempTime' DESC");
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Case Number");
            dtResult.Columns.Add("Added");
            using (IDataReader sqlReader = db.ExecuteReader(cmd))
            {
                while (sqlReader.Read()) 
                {
                    object[] dRow = new object[2];
                    dRow[0] = sqlReader.GetString(0);
                    TimeSpan diff = DateTime.Now.Subtract(sqlReader.GetDateTime(1));
                    if (diff.Days > 0) { dRow[1] = String.Format("{0} {1} ago", diff.Days, (diff.Days > 1) ? "days" : "day"); }
                    else if (diff.Hours > 0) { dRow[1] = String.Format("{0} {1} ago", diff.Hours, (diff.Hours > 1) ? "hours" : "hour"); }
                    else { dRow[1] = String.Format("{0} {1} ago", diff.Minutes, (diff.Minutes == 0 || diff.Minutes > 1) ? "minutes" : "minute"); }
                    
                    var newRow = dtResult.NewRow();
                    newRow.ItemArray = dRow;
                    dtResult.Rows.Add(newRow);
                }
            }
            QueuedCases = dtResult.Rows.Count;
            return dtResult;
        }

        private DataTable GetProcessed()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand("GetProcessedIRF");
            db.AddInParameter(cmd, "searchDate", DbType.DateTime, DateTime.Now.ToShortDateString());
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Case Number");
            dtResult.Columns.Add("Time");
            dtResult.Columns.Add("Result");
            dtResult.Columns.Add("Reason");
            using (IDataReader sqlReader = db.ExecuteReader(cmd))
            {
                while (sqlReader.Read())
                {
                    object[] dRow = new object[4];
                    dRow[0] = sqlReader.GetString(0);
                    dRow[1] = sqlReader.GetString(1).Substring(0, 5);
                    dRow[2] = sqlReader.GetString(2);
                    dRow[3] = sqlReader.GetString(3);
                    var newRow = dtResult.NewRow();
                    newRow.ItemArray = dRow;
                    dtResult.Rows.Add(newRow);
                }
            }
            ProcessedCases = dtResult.Rows.Count;
            return dtResult;
        }
    }   
}