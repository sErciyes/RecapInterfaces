using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomerManager customerManager = new CustomerManager();

            //customerManager.Logger = new DatabaseLogger();

            //customerManager.Logger = new FileLogger();

            customerManager.Logger = new SmsLogger();

            customerManager.Logger.Log();
            customerManager.Add();
        }
        class CustomerManager
        {
            public ILogger Logger { get; set; }
            public void Add()
            {
                MessageBox.Show("Customer added!");
            }
        }
        class Logger : ILogger
        {
            public void Log()
            {
                throw new NotImplementedException();
            }
        }
        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                MessageBox.Show("Logged to Database!");
            }
        }
        class FileLogger : ILogger
        {
            public void Log()
            {
                MessageBox.Show("Logged to File");
            }
        }
        class SmsLogger : ILogger
        {
            public void Log()
            {
                MessageBox.Show("Logged to SMS");
            }
        }
        interface ILogger
        {
             void Log();
        }
    }
}
