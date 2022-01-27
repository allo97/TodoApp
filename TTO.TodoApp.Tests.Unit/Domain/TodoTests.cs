using System;
using FluentAssertions;
using TTO.TodoApp.Domain;
using Xunit;

namespace TTO.TodoApp.Tests.Unit.Domain
{
    public class TodoTests
    {
        [Fact]
        public void GivenValidTodoDataShouldCreated()
        {
            var id = Guid.NewGuid();
            var text = "Test";
            var isCompleted = true;

            var todo = new Todo(id, text, isCompleted);

            todo.Id.Should().Be(id);
            todo.Text.Should().Be(text);
            todo.IsCompleted.Should().Be(isCompleted);
        }
    }
}
