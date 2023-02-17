using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApplication.Model;

namespace WpfApplication.View
{
    /// <summary>
    /// Interaktionslogik für Metadata.xaml
    /// </summary>
    public partial class Metadata : UserControl
    {
        public Metadata()
        {
            InitializeComponent();

            var data = new List<TestData>
            {
                new TestData { Id = 1, Name = "Item 1", Created = DateTime.Now, Yes = true },
                new TestData { Id = 2, Name = "Item 2", Created = DateTime.Now, Yes = true},
                new TestData { Id = 3, Name = "Item 3", Created = DateTime.Now, Yes = false },
                new TestData { Id = 4, Name = "Item 4", Created = DateTime.Now, Yes = true },
                new TestData { Id = 5, Name = "Item 5", Created = DateTime.Now, Yes = false },
                new TestData { Id = 6, Name = "Item 6", Created = DateTime.Now, Yes = true },
                new TestData { Id = 7, Name = "Item 7", Created = DateTime.Now, Yes = false }
            };

            // set the ItemSource of the DataGrid control into xaml page
            datagrid2.ItemsSource = data;
        }
    }
}
