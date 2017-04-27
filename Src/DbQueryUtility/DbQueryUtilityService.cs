using BizTalkComponents.Utilities.DbQueryUtility.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BizTalkComponents.Utilities.DbQueryUtility
{
    public class DbQueryUtilityService
    {
        private readonly IDbQueryRepository _dbQueryRepository = null;
        public DbQueryUtilityService(IDbQueryRepository dbQueryRepository)
        {
            if(dbQueryRepository == null)
            {
                throw new ArgumentNullException("dbQueryRepository");
            }

            _dbQueryRepository = dbQueryRepository;
        }

        public XPathNavigator Query(string query, string configurationKey)
        {
            var doc = _dbQueryRepository.Query(query, configurationKey);
            var nav = doc.CreateNavigator();

            return nav.CreateNavigator();
        }
    }
}
