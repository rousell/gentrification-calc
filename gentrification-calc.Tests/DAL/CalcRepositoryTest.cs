using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gentrification_calc.DAL;

namespace gentrification_calc.Tests.DAL
{
    [TestClass]
    public class CalcRepositoryTest
    {
        [TestMethod]
        public void RepoEnsureICanCreateAnInstance()
        {
            CalcRepository repo = new CalcRepository();
            Assert.IsNotNull(repo);
        }
    }
}
