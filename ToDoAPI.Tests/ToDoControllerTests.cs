using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;
using System.Threading;
using Moq;
using ToDoAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Data;

namespace ToDoAPI.Tests
{
    public class ToDoControllerTests
    {
        [Fact]
        public async Task GetAll_WithAListOfTodos_ReturnsAList()
        {
            var repoStub = new Mock<IRepository>();
            repoStub.Setup(repo => repo.GetAll<ToDoItem>()).ReturnsAsync(GetTestTodos());
            var controller = new ToDoController(repoStub.Object);
            var res = await controller.GetAll();
            var listRes = Assert.IsAssignableFrom<List<ToDoItem>>(res.Value);
            Assert.Equal(GetTestTodos().Count, listRes.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetItem_WithAnId_ReturnsAToDoItem(int id)
        {
            var repoStub = new Mock<IRepository>();
            repoStub.Setup(repo => repo.Get<ToDoItem>(It.IsAny<int>())).ReturnsAsync(GetTestTodos().Find(item => item.Id == id));
            var controller = new ToDoController(repoStub.Object);
            var res = await controller.GetItem(id);
            var item = Assert.IsType<ToDoItem>(res.Value);
            Assert.Equal(id, item.Id);
        }

        [Fact]
        public async Task GetItem_WhenIdNotExist_ReturnsNotFound()
        {
            var repoStub = new Mock<IRepository>();
            repoStub.Setup(repo => repo.Get<ToDoItem>(It.IsAny<int>())).ReturnsAsync(null as ToDoItem);
            var controller = new ToDoController(repoStub.Object);
            var res = await controller.GetItem(0);
            Assert.IsType<NotFoundResult>(res.Result);
        }

        private List<ToDoItem> GetTestTodos()
        {
            return new List<ToDoItem> {
                new ToDoItem { Id = 1, Text = "Text1", Date = DateTime.Now },
                new ToDoItem { Id = 2, Text = "Text2", Date = DateTime.Now },
                new ToDoItem { Id = 3, Text = "Text3", Date = DateTime.Now },
            };
        }
    }
}
