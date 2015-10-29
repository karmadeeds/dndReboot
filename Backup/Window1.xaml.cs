using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ConvertersInWPF
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ObservableCollection<Request> requestList = new ObservableCollection<Request> 
            {
                new Request{Title="Add Employee To Active Directory", 
                    RequestStatus=Request.Status.Closed},
                new Request{Title="Create Requested AD Distribution List", 
                    RequestStatus=Request.Status.InProgress},
                new Request{Title="Install Windows Server 2008", 
                    RequestStatus=Request.Status.Resolved},
                new Request{Title="Format System", 
                    RequestStatus=Request.Status.Assigned},
                new Request{Title="Change Passowrd", 
                    RequestStatus=Request.Status.Assigned},
                new Request{Title="Install Office 2007", 
                    RequestStatus=Request.Status.Resolved},
                new Request{Title="Grant Access of Facebook", 
                    RequestStatus=Request.Status.InProgress},
                new Request{Title="Grant Access of Youtube", 
                    RequestStatus=Request.Status.Submitted},
                new Request{Title="Install Visual Studio 2010 RC", 
                    RequestStatus=Request.Status.Submitted},
                new Request{Title="Install Expression Blend 4 Beta", 
                    RequestStatus=Request.Status.InProgress},
            };
            dgRequests.ItemsSource = requestList;
        }
    }

    public class Request
    {
        #region Enum-Status
        public enum Status
        {
            Submitted,
            Assigned,
            InProgress,
            Resolved,
            Closed
        } 
        #endregion

        #region Public-Properties
        public string Title { get; set; }
        public Status RequestStatus { get; set;}
        #endregion
    }
}
