using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using SzkolaTestowJednostkowych.Mocking;

namespace SzkolaTestowJednostkowych_UnitTests.Mocking
{
    class TaskServiceTests
    {
        private Mock<ILogger> _mockLogger;
        private Mock<IEmailSender> _mockEmailSender;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMessageBoxWrapper> _mockMessageBox;
        private TaskService _taskService;
        private Task _task;

        private void Init()
        {
            _task = new Task
            {
                Id = 1,
                Title = "1",
                User = new User { Email = "1@1.pl" }
            };

            _mockLogger = new Mock<ILogger>();
            _mockEmailSender = new Mock<IEmailSender>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMessageBox = new Mock<IMessageBoxWrapper>();

            _mockUnitOfWork.Setup(x=>x.Task.GetTask(_task.Id)).Returns(_task);

            _taskService = new TaskService(
                _mockLogger.Object, 
                _mockEmailSender.Object,
                _mockUnitOfWork.Object, 
                _mockMessageBox.Object);
        }

        [Test]
        public void CloseTask_WhenTaskNotFound_ShouldThrowException()
        {
            Init();
            _mockUnitOfWork.Setup(x => x.Task.GetTask(1)).Returns((Task)null);

            Action action = () => _taskService.CloseTask(1);

            action.Should().ThrowExactly<Exception>().WithMessage("*Notfound task*");
        }

        [Test]
        public void CloseTask_WhenTaskIsAlreadyCloced_ShouldThrowException()
        {
            Init();
            _task.IsClosed = true;
            _mockUnitOfWork.Setup(x => x.Task.GetTask(1)).Returns((Task)null);

            Action action = () => _taskService.CloseTask(1);

            action.Should().ThrowExactly<Exception>().WithMessage("*The task is already closed*");
        }

        [Test]
        public void CloseTask_WhenEmailFails_ShouldLogError()
        {
            Init();
            _mockEmailSender
                .Setup(x=>x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception());

            _taskService.CloseTask(_task.Id);

            _mockLogger.Verify(x => x.Error(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CloseTask_WhenEmailFails_ShouldDisplayMessage()
        {
            Init();
            _mockEmailSender
                .Setup(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception());

            _taskService.CloseTask(_task.Id);

            _mockMessageBox.Verify(x => x.Show(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CloseTask_WhenCalled_ShouldUpdateTaskInDb()
        {
            Init();

            _taskService.CloseTask(_task.Id);

            _task.IsClosed.Should().BeTrue();
            _mockUnitOfWork.Verify(x=>x.Complete(),Times.Once);
        }

        [Test]
        public void CloseTask_WhenCalled_ShouldSendEmail()
        {
            Init();

            _taskService.CloseTask(_task.Id);

            _mockEmailSender.Verify(x=> x.Send(It.IsAny<string>(), It.IsAny<string>(),_task.User.Email),Times.Once);
        }

        [Test]
        public void CloseTask_WhenCalled_ShouldShowMessage()
        {
            Init();

            _taskService.CloseTask(_task.Id);

            _mockMessageBox.Verify(x => x.Show(It.IsAny<string>()), Times.Once);
        }
    }
}
