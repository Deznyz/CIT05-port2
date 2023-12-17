using DataLayer;

namespace Tests.Tests
{
    public class DataLayerTests
    {
        [Fact]
        public void Create_and_Delete_Aliases()
        {
            var service = new DataService();
            var alias = service.CreateAliases(
                new DataLayer.Models.Aliases
                {
                    TitleId = "tt12879782",
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

        [Fact]
        public void Create_Update_Aliases()
        {
            var service = new DataService();
            var alias = service.CreateAliases(
                new DataLayer.Models.Aliases
                {
                    TitleId = "tt12879782",
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

            alias.Title = "updated";

            service.UpdateAliases(alias.Title, alias.Ordering, alias);
            Assert.Equal("updated", alias.Title);

            // cleanup
            service.DeleteAliases(alias);
        }

        [Fact]
        public void Get_Alias()
        {
            var service = new DataService();
            var alias = service.GetAlias("tt10687202", 83);
            Assert.Equal("Ein lustiges Hundeleben", alias.Title);
        }

        [Fact]
        public void Get_Aliases()
        {
            var service = new DataService();
            var aliases = service.GetAliases(0,10);
            Assert.Equal(365359, aliases.count);
        }

        [Fact]
        public void Get_Co_Actors_test()
        {
            var service = new DataService();
            var coActors = service.GetCoActors("Johnny Depp", 0, 10);
            Assert.Equal(101, coActors.count);

        }

    }
}
