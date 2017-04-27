using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BizTalkComponents.Utilities.DbQueryUtility.Repository
{
    public interface IDbQueryRepository
    {
        XDocument Query(string query, string configurationKey);
    }
}
