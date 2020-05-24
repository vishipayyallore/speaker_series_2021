using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoWebApi.Models;

namespace ToDoWebApi.Tests
{

    [TestClass]
    public class ToDoApplicationTests
    {
        const string LastCommitSha = "fd6973f430a3367ad718ff049f1b075843913d6f";

        [TestMethod]
        public void WhenNewObjectIsCreated()
        {
            ToDoApplication toDoApplication = new ToDoApplication();

            Assert.AreEqual(toDoApplication.LastCommitSha, LastCommitSha);
        }
    }

}
