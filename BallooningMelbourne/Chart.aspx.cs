using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BallooningMelbourne
{
    public partial class Chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

//using System;  
//using System.Web.UI.WebControls;  
//using System.Data;  
//using System.Data.SqlClient;  
//using System.Configuration;  
//using System.Web.UI.DataVisualization.Charting;  
  
//namespace BindDataControl_Demo  
//{  
//    public partial class ChartControl : System.Web.UI.Page  
//    {  
//        protected void Page_Load(object sender, EventArgs e)  
//        {  
//            if (!IsPostBack)  
//            {  
//                GetChartData();  
//                GetChartTypes();  
//            }  
//        }  
  
//        private void GetChartTypes()  
//        {  
//            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))  
//            {  
//                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());  
//                ddlChart.Items.Add(li);  
//            }  
//        }  
  
//        private void GetChartData()  
//        {  
//            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  
//            using (SqlConnection con = new SqlConnection(CS))  
//            {  
//                SqlCommand cmd = new SqlCommand("spGetStudentMarks", con);  
//                cmd.CommandType = CommandType.StoredProcedure;  
//                con.Open();  
//                SqlDataReader rdr = cmd.ExecuteReader();  
//                // Retrieve the Series to which we want to add DataPoints  
//                Series series = Chart1.Series["Series1"];  
//                // Loop thru each Student record  
//                while (rdr.Read())  
//                {  
//                    // Add X and Y values using AddXY() method  
//                    series.Points.AddXY(rdr["StudentName"].ToString(),  
//                    rdr["TotalMarks"]);  
//                }  
//            }  
//        }  
  
//        protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)  
//        {  
//            // Call Get ChartData() method when the user select a different chart type  
//            GetChartData();  
//            this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChart.SelectedValue);  
//        }  
//    }  
//}  