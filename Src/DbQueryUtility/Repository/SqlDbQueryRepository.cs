using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BizTalkComponents.Utilities.DbQueryUtility.Repository
{
    public class SqlDbQueryRepository : IDbQueryRepository
    {
        public XDocument Query(string query, string configurationKey)
        {
            var doc = new XDocument();
            var resultElement = new XElement("Result");
            var connectionString = ConfigurationManager.ConnectionStrings[configurationKey].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if(query.Split(' ').Count() == 0)
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        command.CommandType = System.Data.CommandType.Text;
                    }

                    SqlDataReader reader;

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
