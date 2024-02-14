using TodListModel;
namespace TodoListTest;

[TestClass]
public class TodoListMsTest
{
    [TestMethod]   
    public void TestTodoItemProperties()
    {
        var item = new TodoItem
        {
            Id = 1,
            DueDate = new DateTime(2024, 2, 15),
            Description = "Test todo item",
        };

        Assert.AreEqual(1, item.Id);
        Assert.AreEqual(new DateTime(2024, 2, 15), item.DueDate);
        Assert.IsNull(item.CompletedDate);
        Assert.AreEqual("Test todo item", item.Description);
    }

    }
}