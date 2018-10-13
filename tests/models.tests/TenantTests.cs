using Models;
using System;
using Xunit;

namespace models.tests
{
    public class TenantTests
    {
        #region New tests

        [Fact]
        public void NewTenant_ShouldSetPassedValues()
        {
            var id = Guid.NewGuid();

            var classUnderTest = new Tenant(id, "newUser");

            Assert.Equal(id, classUnderTest.Id);
            Assert.Equal("newUser", classUnderTest.CreatedBy);


        }
        #endregion
    }
}
