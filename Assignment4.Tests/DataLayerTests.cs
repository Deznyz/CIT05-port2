using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Tests
{
    public class DataLayerTests
    {
        [Fact]
        public void CreateAliases_ValidData_CreteAliasesAndReturnsNewObject()
        {
            var service = new DataService();
            var alias = service.CreateAliases(
                new DataLayer.Models.Aliases
                {
                    TitleId = "titleId",
                    Ordering = 0,
                    Title = "title",
                    Region = "region",
                    Language = "language",
                    IsOriginalTitle = false,
                    Types = "types",
                    Attributes = "attributes"
                });
            Assert.True(alias.Ordering == 0);
            Assert.Equal("title", alias.Title);
            Assert.Equal("language", alias.Language);

            // cleanup
            service.DeleteAliases(alias);
        }
    }
}
