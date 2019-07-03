using System;
using System.Collections.Generic;
using paytm;

namespace Paytm_Payment_Gateway
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String merchantKey = "3nq9CVSw2mPNqs6o" ;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string paytmChecksum = "";
            foreach (string key in Request.Form.Keys)
            {
                parameters.Add(key.Trim(), Request.Form[key].Trim());
            }

            if (parameters.ContainsKey("CHECKSUMHASH"))
            {
                paytmChecksum = parameters["CHECKSUMHASH"];
                parameters.Remove("CHECKSUMHASH");
            }

            if (CheckSum.verifyCheckSum(merchantKey, parameters, paytmChecksum))
            {
                Response.Write(Request.Params["STATUS"] == "TXN_FAILURE" ? "Payment Failed" : "Payment Successful");
            }
            else
            {
                Response.Write("Payment Failed");
            }
        }
    }
}