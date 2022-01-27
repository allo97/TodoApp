using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TTO.TodoApp.Application;
using Xunit;

namespace TTO.TodoApp.Tests.Integration.Application
{
    public class AddTodoHandlerTests
    {
        private readonly TodoInMemoryRepository _todoRepository;
        private readonly AddTodoHandler _addTodoHandler;

        public AddTodoHandlerTests()
        {
            _todoRepository = new TodoInMemoryRepository();
            _addTodoHandler = new AddTodoHandler(_todoRepository);
        }

        [Fact]
        public async Task GivenValidTodoDataShouldBeAdded()
        {
            var id = Guid.NewGuid();
            var text = "Test";
            var isCompleted = false;
            var request = new AddTodo(id, text, isCompleted);

            await _addTodoHandler.Handle(request, CancellationToken.None);

            var todo = await _todoRepository.GetAsync(id);
            todo.Should().NotBeNull();
            todo.Id.Should().Be(id);
            todo.Text.Should().Be(text);
            todo.IsCompleted.Should().Be(isCompleted);
        }
    }
}
