using NLog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class TaskService
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();
        private ApplicationDbContext _context;

        public TaskService()
        {
            _context = new ApplicationDbContext();
        }

        public void CloseTask(int taskId)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == taskId);

            task.IsClosed = true;
            _context.SaveChanges();

            try
            {
                new EmailSender().Send(
                    $"Zadanie {task.Title}",
                    $"Zadanie {task.Title} zostało zamknięte.",
                    task.User.Email);

                MessageBox.Show("Wysyłanie e-mail'a zakończono sukcesem.");
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Wysyłanie e-mail zakończone błędem {exception.Message}.");
                MessageBox.Show("Wysyłanie e-mail'a zakończono błędem.");
            }
        }
    }
}
