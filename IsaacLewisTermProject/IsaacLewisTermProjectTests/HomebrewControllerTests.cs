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
            Assert.Equal(filtered[2].User.UserName, item2.User.UserName);
            Assert.Equal(filtered[3].User.UserName, item2.User.UserName);
        }
    }
}