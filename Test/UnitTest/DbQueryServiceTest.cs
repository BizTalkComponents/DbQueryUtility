using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BizTalkComponents.Utilities.DbQueryUtility.Repository;

namespace BizTalkComponents.Utilities.DbQueryUtility.Test.UnitTest
{
    [TestClass]
    public class DbQueryServiceTest
    {
        private static Mock<IDbQueryRepository> mock;
        private static DbQueryUtilityService util;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            XDocument doc =
              new XDocument(
                new XElement("result",
                  new XElement("param1", "param1value"),
                  new XElement("param2", "param2value"),
                  new XElement("param3", "param3value")
                  )
              );


            mock = new Mock<IDbQueryRepository>();
            util = new DbQueryUtilityService(mock.Object);
            mock.Setup(s => s.Query("SELECT * FROM Test","Key")).Returns(doc);
        }


        [TestMethod]
        public void TestHappyPath()
        {
            var result = util.Query("SELECT * FROM Test","Key");
            Assert.AreEqual(3, result.Select("/result/node()").Count);
            Assert.AreEqual("param2value", result.SelectSingleNode("/result/param2").Value);
        }
    }
}
