using System;
using System.Collections.Generic;
using Data.Mappers;
using Data.Models;
using Data.Models.Controller.TodoItem;
using Data.Models.DataAccess;
using DataAccess.Helpers;
using NUnit.Framework;

namespace DataAccess.Tests.Mappers
{
    public class Tests
    {
        private DateTime time = DateTime.Parse("2019-10-09 08:07:06");

        private IList<TodoItemStatus> statusEnum = (TodoItemStatus[])Enum.GetValues(typeof(TodoItemStatus));

        #region ToDataAccess

        #region TodoItemDataAccess

        [Test]
        public void ToDataAccess_TodoItemDataAccess_Null_Success()
        {
            foreach (var status in statusEnum)
            {
                var result = TodoItemMapper.ToDataAccess((TodoItemCreate)null, time, status);

                Assert.IsNull(result);
            }
        }

        [Test]
        public void ToDataAccess_TodoItemDataAccess_Default_Success()
        {
            var input = ObjectMaker.GetTodoItemCreate();
            var result = TodoItemMapper.ToDataAccess(input, ObjectMaker.Defaults.TodoItems.CreatedDate, ObjectMaker.Defaults.TodoItems.Status);

            Assert.AreEqual(ObjectMaker.GetTodoItemDataAccess(), result);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ToDataAccess_TodoItemDataAccess_Defaults_Success(int index)
        {
            var input = ObjectMaker.GetTodoItemCreate(index);
            var result = TodoItemMapper.ToDataAccess(input, ObjectMaker.Defaults.TodoItems.CreatedDates[index], ObjectMaker.Defaults.TodoItems.Statues[index]);

            Assert.AreEqual(ObjectMaker.GetTodoItemDataAccess(index), result);
        }

        #endregion

        #endregion

        #region ToController

        #region TodoItemStatusHistory

        [Test]
        public void ToController_TodoItemStatusHistory_Null_Success()
        {
            var result = TodoItemMapper.ToController((TodoItemStatusHistoryDataAccess) null);

            Assert.IsNull(result);
        }

        [Test]
        public void ToController_TodoItemStatusHistory_Success()
        {
            var result = TodoItemMapper.ToController(ObjectMaker.GetTodoItemStatusHistoryDataAccess());

            Assert.AreEqual(ObjectMaker.GetTodoItemStatusHistory(), result);
        }

        #endregion

        #endregion
    }
}
