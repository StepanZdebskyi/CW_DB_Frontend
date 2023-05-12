using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using CW_DB_Frontend.Model.ASP_NET_Model;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.ViewModels;
using CW_DB_Frontend.UI.Views;

namespace CW_DB_Frontend.UI
{
    public partial class App : Application
    { 
        private MyViewModel _viewModel;
        private AspViewModel aspViewModel;

        public App()
        {
            _viewModel = new MyViewModel();
            MainWindow = new MainWindow();

            new AspMapping().Create();
            AspDataModel aspModel = new AspDataModel();
            aspViewModel = Mapper.Map<AspDataModel, AspViewModel>(aspModel);

            _viewModel.aspViewModel = this.aspViewModel;
            _viewModel.aspDataModel = aspModel;

            MainWindow.DataContext = _viewModel;
            MainWindow wnd = (MainWindow)Window.GetWindow(MainWindow);
            _viewModel.mainWindow = wnd;
            wnd.Show();
        }
    }
}
