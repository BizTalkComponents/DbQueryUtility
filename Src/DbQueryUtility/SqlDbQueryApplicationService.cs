using BizTalkComponents.Utilities.DbQueryUtility.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BizTalkComponents.Utilities.DbQueryUtility
{
    public class SqlDbQueryApplicationService
    {
        public XPathNavigator Query(string query, string configurationKey)
        {
            var util = new DbQueryUtilityService(new SqlDbQueryRepository());

            XPathNavigator nav;

            try
            {
                nav = util.Query(query, configurationKey);
            }
            catch(Exception ex)
            {
                Trace.WriteLine(String.Format("An exception was thrown in DbQueryUtity. {0}", ex.ToString()));
                throw ex;
            }
            return nav;
        }
    }
}
