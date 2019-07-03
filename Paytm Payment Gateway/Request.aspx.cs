using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using paytm;

namespace Paytm_Payment_Gateway
{
    public partial class Request : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PaytmPayment(object sender, EventArgs e)
        {
            string emailId = ((TextBox)FindControl("txtEmail")).Text;
            string mobileNumber = ((TextBox)FindControl("txtMobileNumber")).Text;            
            String merchantKey = "3nq9CVSw2mPNqs6o";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "lEGUpY97255671347258");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL", emailId);
            parameters.Add("MOBILE_NO", mobileNumber);
            parameters.Add("CUST_ID", "Cust01");
            parameters.Add("ORDER_ID", "OR06");
            parameters.Add("TXN_AMOUNT", "200");
            parameters.Add("CALLBACK_URL", "http://localhost:6042/Response.aspx");

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction?orderid=OR01";

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
        }
    }
}