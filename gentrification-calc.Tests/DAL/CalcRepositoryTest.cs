using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GentrificationCalc.DAL;
using Moq;
using GentrificationCalc.Models;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace GentrificationCalc.Tests.DAL
{
    [TestClass]
    public class CalcRepositoryTest
    {

        Mock<CalcContext> mock_context { get; set; }
        CalcRepository Repo { get; set; }
        Mock<DbSet<Demographic>> mock_demographic_table { get; set; }
        IQueryable<Demographic> demographic_data { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_demographic_table = new Mock<DbSet<Demographic>>();
            mock_context = new Mock<CalcContext>();
            Repo = new CalcRepository(mock_context.Object);

            List<Demographic> demographic_datasource = new List<Demographic>();
            demographic_data = demographic_datasource.AsQueryable();
        }

        void ConnectMocksToDatastore()
        {
            mock_demographic_table.As<IQueryable<Demographic>>().Setup(d => d.GetEnumerator()).Returns(demographic_data.GetEnumerator());
            mock_demographic_table.As<IQueryable<Demographic>>().Setup(d => d.ElementType).Returns(demographic_data.ElementType);
            mock_demographic_table.As<IQueryable<Demographic>>().Setup(d => d.Expression).Returns(demographic_data.Expression);
            mock_demographic_table.As<IQueryable<Demographic>>().Setup(d => d.Provider).Returns(demographic_data.Provider);

            mock_context.Setup(context => context.Demographics).Returns(mock_demographic_table.Object);
        }



        [TestMethod]
        public void RepoEnsureICanCreateAnInstance()
        {
            CalcRepository repo = new CalcRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIHaveDemographicSeedData()
        {
            //Arrange
            ConnectMocksToDatastore();

            //Act
            int demographic_data_count = Repo.GetDemographicDataCount();

            //Assert
            Assert.AreNotEqual(0, demographic_data_count);
        }
    }
}
