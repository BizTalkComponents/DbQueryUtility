using System;
using System.Collections.Generic;
using System.Configuration;
using Oracle.ManagedDataAccess.Client; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BizTalkComponents.Utilities.DbQueryUtility.Repository
{
    public class OracleDbQueryRepository : IDbQueryRepository
    {
        public XDocument Query(string query, string configurationKey)
        {
            var doc = new XDocument();
            var resultElement = new XElement("Result");
            var connectionString = ConfigurationManager.ConnectionStrings[configurationKey].ConnectionString;

            using (var connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand (query, connection))
                {
                    if (!query.Contains(' '))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        command.CommandType = System.Data.CommandType.Text;
                    }

                    OracleDataReader reader;

                    connection.Open();

                    using (reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                resultElement.Add(new XElement(reader.GetName(i), reader.GetValue(i)));
                            }
                        }
                    }
                }
            }

            doc.Add(resultElement);

            return doc;
        }

    }
}
