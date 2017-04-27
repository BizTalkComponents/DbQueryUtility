using BizTalkComponents.Utilities.DbQueryUtility.Repository;
using System;
using System.Collections.Generic;
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

            return util.Query(query, configurationKey);
        }
    }
}
