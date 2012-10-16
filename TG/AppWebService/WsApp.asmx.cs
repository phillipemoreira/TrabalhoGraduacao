using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://appwebservice.fatec.com.br/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsApp : System.Web.Services.WebService
    {

        [WebMethod]
        public string getPlans()
        {
            return "Get Plans";
        }

        [WebMethod]
        public string getUser(String id)
        {
            return "Get User";
        }
    }
}