using NLog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class TaskService
    {
        private ILogger _logger;
        private IEmailSender _emailSender;
        private IUnitOfWork _unitOfWork;
        private IMessageBoxWrapper _messageBox;

        public TaskService(ILogger logger, IEmailSender emailSender, IUnitOfWork unitOfWork, IMessageBoxWrapper messageBox)
        {
            _logger = logger;
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _unitOfWork = unitOfWork;
            _messageBox = messageBox;
        }

        public void CloseTask(int taskId)
        {
            var task = _unitOfWork.Task.GetTask(taskId);

            if (task == null)
                throw new Exception("Notfound task.");

            if (task.IsClosed)
                throw new Exception("The task is already closed.");

            task.IsClosed = true;
            _unitOfWork.Complete();

            try
            {
                _emailSender.Send(
                    $"Zadanie {task.Title}",
                    $"Zadanie {task.Title} zostało zamknięte.",
                    task.User.Email);

                _messageBox.Show("Wysyłanie e-mail'a zakończono sukcesem.");
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Wysyłanie e-mail zakończone błędem {exception.Message}.");
                _messageBox.Show("Wysyłanie e-mail'a zakończono błędem.");
            }
        }
    }
}
