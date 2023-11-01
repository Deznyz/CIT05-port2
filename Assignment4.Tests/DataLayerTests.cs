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
            //var newAlias = 
            //    new DataLayer.Models.Aliases
            //    {
            //        TitleId = "tt0052520",
            //        Ordering = 456,
            //        Title = "title",
            //        Region = "region",
            //        Language = "language",
            //        IsOriginalTitle = false,
            //        Types = "types",
            //        Attributes = "attributes"
            //    };
            var alias = service.CreateAliases(
                new DataLayer.Models.Aliases
                {
                    TitleId = "tt0052520 ",
                    Ordering = 456,
                    Title = "title",
                    Region = "region",
                    Language = "language",
                    IsOriginalTitle = false,
                    Types = "types",
                    Attributes = "attributes"
                });
            Assert.True(alias.Ordering == 456);
            Assert.Equal("title", alias.Title);
            Assert.Equal("language", alias.Language);



            // cleanup
            service.DeleteAliases(alias);
        }
       
    }
}
