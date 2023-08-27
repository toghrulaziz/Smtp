using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SMTP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {


		private string? toAddress;

		public string? ToAddress
		{
			get { return toAddress; }
			set { Set(ref toAddress, value); }
		}



		private string? subject;

		public string? Subject
		{
			get { return subject; }
			set { Set(ref subject, value); }
		}



		private string? message;

		public string? Message
		{
			get { return message; }
			set { Set(ref message, value); }
		}


        public RelayCommand SendCommand
        {
            get => new RelayCommand(() =>
            {
				try
				{
					MailAddress fromAddress = new("togrul1609@gmail.com", "Togrul Azizli");
					MailAddress toAddress = new($"{ToAddress}");

					MailMessage message = new(fromAddress, toAddress);

					message.Subject = Subject;
					message.IsBodyHtml = true;
					message.Body = $"<html><body><h1>{Message}</h1></body></html>";

					SmtpClient smtpClient = new("smtp.gmail.com", 587);

					smtpClient.Credentials = new NetworkCredential("togrul1609@gmail.com", "bhguvayglxtrxpgx");
					smtpClient.EnableSsl = true;

					smtpClient.Send(message);

					MessageBox.Show("Message Sent!");

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}	

            });
        }


    }
}
