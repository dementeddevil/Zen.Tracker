﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Im.Basket.Client.Entities;
using Xamarin.Forms;

namespace Im.Basket.Client.Views
{
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();
            InitializeToolBars();
        }
        private void InitializeToolBars()
        {
            string addIcon = null;
            string refreshIcon = null;

            if (Device.OS == TargetPlatform.WinPhone)
            {
                addIcon = "Toolkit.Content/ApplicationBar.Add.png";
                refreshIcon = "Toolkit.Content/ApplicationBar.Refresh.png";
            }
            var addToolButton = new ToolbarItem("Add", addIcon, () =>
            {
                var todoItem = new TodoItem();
                var todoPage = new TodoListView();
                //todoPage.BindingContext = todoItem;
                Navigation.PushAsync(todoPage);
            }, 0, 0);

            var refreshToolButton = new ToolbarItem("Refresh", refreshIcon, () =>
            {
                OnAppearing();

            }, 0, 0);

            ToolbarItems.Add(addToolButton);
            ToolbarItems.Add(refreshToolButton);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //App.TodoManager.TodoViewModel.TodoItems = await App.TodoManager.GetTasksAsync();
            //listViewTasks.ItemsSource = App.TodoManager.TodoViewModel.TodoItems;
        }

        // Open item page only when the label is clicked.
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem != null)
            //{
            //    if (!App.TodoManager.CheckBoxClicked)
            //    {
            //        var todoItem = e.SelectedItem as ToDoItem;
            //        var todoPage = new ToDoItemXaml();
            //        todoPage.BindingContext = todoItem;
            //        Navigation.PushAsync(todoPage);
            //    }
            //    else
            //    {
            //        App.TodoManager.CheckBoxClicked = false;
            //        ((ListView)sender).SelectedItem = null;
            //    }
            //}
        }
        async void OnCheckBoxChanged(object sender, bool isChecked)
        {
            var checkBox = ((Im.Basket.Client.Views.CheckBox)sender);

            var item = (TodoItem)checkBox.BindingContext;

            if (item.Complete != isChecked)
            {
                item.Complete = isChecked;
                if (item.Complete)
                {
                    item.CompletedAt = DateTimeOffset.UtcNow;
                }

                //await App.TodoManager.SaveTaskAsync(item);
            }
        }

        #region Get size of device

        bool _firstTime = true;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (_firstTime)
            {
                _firstTime = false;
                //App.TodoManager.Device.DeviceWidth = width;
                //App.TodoManager.Device.DeviceHeight = height;
            }
        }

        #endregion
    }
}