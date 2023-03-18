using IsaacLewisTermProject.Controllers;
using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace IsaacLewisTermProjectTests
{
    public class HomebrewControllerTests
    {
        IHomebrewRepository repo = new FakeHomebrewRepository();
        HomebrewController controller;
        public HomebrewControllerTests()
        {
            controller = new HomebrewController(repo, null);
        }

        //I dont know what I am doing wrong but I cant get this to work.
        [Fact]
        public void FilterItemByNameTest()
        {
            var item1 = new Item() { ItemName = "Test1" };
            repo.StoreItemAsync(item1).Wait();
            repo.StoreItemAsync(item1).Wait();
            var item2 = new Item() { ItemName = "Test2" };
            repo.StoreItemAsync(item2).Wait();
            repo.StoreItemAsync(item2).Wait();
            var item3 = new Item() { ItemName = "Test3" };
            repo.StoreItemAsync(item3).Wait();
            repo.StoreItemAsync(item3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Item(item1.ItemName, null).Result as ViewResult;
            List<Item> filtered = filteredView.Model as List<Item>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].ItemName, item1.ItemName);
            Assert.Equal(filtered[1].ItemName, item1.ItemName);
        }

        [Fact]
        public void FilterItemByUsernameTest()
        {
            var item1 = new Item() { User = new AppUser { UserName= "Test1" } };
            repo.StoreItemAsync(item1).Wait();
            repo.StoreItemAsync(item1).Wait();
            var item2 = new Item() { User = new AppUser { UserName = "Test2" } };
            repo.StoreItemAsync(item2).Wait();
            repo.StoreItemAsync(item2).Wait();
            var item3 = new Item() { User = new AppUser { UserName = "Test3" } };
            repo.StoreItemAsync(item3).Wait();
            repo.StoreItemAsync(item3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Item(null, item2.User.UserName).Result as ViewResult;
            List<Item> filtered = filteredView.Model as List<Item>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].User.UserName, item2.User.UserName);
            Assert.Equal(filtered[1].User.UserName, item2.User.UserName);
        }

        [Fact]
        public void FilterAdventureByNameTest()
        {
            var model1 = new Adventure() { AdventureName = "Test1" };
            repo.StoreAdventureAsync(model1).Wait();
            repo.StoreAdventureAsync(model1).Wait();
            var model2 = new Adventure() { AdventureName = "Test2" };
            repo.StoreAdventureAsync(model2).Wait();
            repo.StoreAdventureAsync(model2).Wait();
            var model3 = new Adventure() { AdventureName = "Test3" };
            repo.StoreAdventureAsync(model3).Wait();
            repo.StoreAdventureAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Adventure(model1.AdventureName, null).Result as ViewResult;
            List<Adventure> filtered = filteredView.Model as List<Adventure>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].AdventureName, model1.AdventureName);
            Assert.Equal(filtered[1].AdventureName, model1.AdventureName);
        }

        [Fact]
        public void FilterAdventureByUsernameTest()
        {
            var model1 = new Adventure() { User = new AppUser { UserName = "Test1" } };
            repo.StoreAdventureAsync(model1).Wait();
            repo.StoreAdventureAsync(model1).Wait();
            var model2 = new Adventure() { User = new AppUser { UserName = "Test2" } };
            repo.StoreAdventureAsync(model2).Wait();
            repo.StoreAdventureAsync(model2).Wait();
            var model3 = new Adventure() { User = new AppUser { UserName = "Test3" } };
            repo.StoreAdventureAsync(model3).Wait();
            repo.StoreAdventureAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Adventure(null, model2.User.UserName).Result as ViewResult;
            List<Adventure> filtered = filteredView.Model as List<Adventure>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].User.UserName, model2.User.UserName);
            Assert.Equal(filtered[1].User.UserName, model2.User.UserName);
        }

        [Fact]
        public void FilterSpellByNameTest()
        {
            var model1 = new Spell() { SpellName = "Test1" };
            repo.StoreSpellAsync(model1).Wait();
            repo.StoreSpellAsync(model1).Wait();
            var model2 = new Spell() { SpellName = "Test2" };
            repo.StoreSpellAsync(model2).Wait();
            repo.StoreSpellAsync(model2).Wait();
            var model3 = new Spell() { SpellName = "Test3" };
            repo.StoreSpellAsync(model3).Wait();
            repo.StoreSpellAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Spell(model1.SpellName, null).Result as ViewResult;
            List<Spell> filtered = filteredView.Model as List<Spell>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].SpellName, model1.SpellName);
            Assert.Equal(filtered[1].SpellName, model1.SpellName);
        }

        [Fact]
        public void FilterSpellByUsernameTest()
        {
            var model1 = new Spell() { User = new AppUser { UserName = "Test1" } };
            repo.StoreSpellAsync(model1).Wait();
            repo.StoreSpellAsync(model1).Wait();
            var model2 = new Spell() { User = new AppUser { UserName = "Test2" } };
            repo.StoreSpellAsync(model2).Wait();
            repo.StoreSpellAsync(model2).Wait();
            var model3 = new Spell() { User = new AppUser { UserName = "Test3" } };
            repo.StoreSpellAsync(model3).Wait();
            repo.StoreSpellAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Spell(null, model2.User.UserName).Result as ViewResult;
            List<Spell> filtered = filteredView.Model as List<Spell>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].User.UserName, model2.User.UserName);
            Assert.Equal(filtered[1].User.UserName, model2.User.UserName);
        }

        [Fact]
        public void FilterFeatByNameTest()
        {
            var model1 = new Feat() { FeatName = "Test1" };
            repo.StoreFeatsAsync(model1).Wait();
            repo.StoreFeatsAsync(model1).Wait();
            var model2 = new Feat() { FeatName = "Test2" };
            repo.StoreFeatsAsync(model2).Wait();
            repo.StoreFeatsAsync(model2).Wait();
            var model3 = new Feat() { FeatName = "Test3" };
            repo.StoreFeatsAsync(model3).Wait();
            repo.StoreFeatsAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Feat(model1.FeatName, null).Result as ViewResult;
            List<Feat> filtered = filteredView.Model as List<Feat>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].FeatName, model1.FeatName);
            Assert.Equal(filtered[1].FeatName, model1.FeatName);
        }

        [Fact]
        public void FilterFeatByUsernameTest()
        {
            var model1 = new Feat() { User = new AppUser { UserName = "Test1" } };
            repo.StoreFeatsAsync(model1).Wait();
            repo.StoreFeatsAsync(model1).Wait();
            var model2 = new Feat() { User = new AppUser { UserName = "Test2" } };
            repo.StoreFeatsAsync(model2).Wait();
            repo.StoreFeatsAsync(model2).Wait();
            var model3 = new Feat() { User = new AppUser { UserName = "Test3" } };
            repo.StoreFeatsAsync(model3).Wait();
            repo.StoreFeatsAsync(model3).Wait();

            var controller = new HomebrewController(repo, null);

            var filteredView = controller.Feat(null, model2.User.UserName).Result as ViewResult;
            List<Feat> filtered = filteredView.Model as List<Feat>;

            Assert.Equal(2, filtered.Count);
            Assert.Equal(filtered[0].User.UserName, model2.User.UserName);
            Assert.Equal(filtered[1].User.UserName, model2.User.UserName);
        }
    }
}