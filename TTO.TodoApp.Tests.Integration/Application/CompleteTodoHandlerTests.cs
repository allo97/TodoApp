using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TTO.TodoApp.Application;
using Xunit;

namespace TTO.TodoApp.Tests.Integration.Application
{
    public class CompleteTodoHandlerTests
    {
        private readonly TodoInMemoryRepository _todoRepository;
        private readonly CompleteTodoHandler _completeTodoHandler;
        private readonly AddTodoHandler _addTodoHandler;

        public CompleteTodoHandlerTests()
        {
            _todoRepository = new TodoInMemoryRepository();
            _completeTodoHandler = new CompleteTodoHandler(_todoRepository);
            _addTodoHandler = new AddTodoHandler(_todoRepository);
        }

        [Fact]
        public async Task GivenNullTodoDataShouldThrowExceptionAsync()
        {
            var id = Guid.NewGuid();
            var request = new CompleteTodo(id);

            Func<Task> testNullThrow = async () => await _completeTodoHandler.Handle(request, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<Exception>(testNullThrow);
            Assert.Equal($"Todo with id {request.Id} not found.", exception.Message);

            var todo = await _todoRepository.GetAsync(id);
            todo.Should().BeNull();
        }

        [Fact]
        public async Task GivenValidTodoDataIsCompleteShouldThrowExceptionAsync()
        {
            var id = Guid.NewGuid();
            var text = "Test";
            var isCompleted = true;
            var addTodoRequest = new AddTodo(id, text, isCompleted);
            var completeTodoRequest = new CompleteTodo(id);

            await _addTodoHandler.Handle(addTodoRequest, CancellationToken.None);

            Func<Task> testIsCompleteThrow = async () => await _completeTodoHandler.Handle(completeTodoRequest, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<Exception>(testIsCompleteThrow);
            Assert.Equal("Todo already completed!", exception.Message);

            var todo = await _todoRepository.GetAsync(id);

            todo.Should().NotBeNull();
            todo.IsCompleted.Should().Be(isCompleted);
        }

        [Fact]
        public async Task GivenValidTodoDataShouldCompleteTodo()
        {
            var id = Guid.NewGuid();
            var text = "Test";
            var isCompleted = false;
            var addTodoRequest = new AddTodo(id, text, isCompleted);
            var completeTodoRequest = new CompleteTodo(id);

            await _addTodoHandler.Handle(addTodoRequest, CancellationToken.None);

            await _completeTodoHandler.Handle(completeTodoRequest, CancellationToken.None);

            var todo = await _todoRepository.GetAsync(id);

            todo.Should().NotBeNull();
            todo.IsCompleted.Should().NotBe(isCompleted);

        }
    }
}
