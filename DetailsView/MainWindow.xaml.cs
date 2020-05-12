using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsExpanded = false;
        public bool usetransition = false;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void GridHeaderIndentCell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var gridHeaderIndentCell = sender as GridHeaderIndentCell;
            IsExpanded = !IsExpanded;
            usetransition = true;
            VisualStateManager.GoToState(gridHeaderIndentCell, IsExpanded ? "Expanded" : "Collapsed", usetransition);
            usetransition = false;
            if (IsExpanded)
                this.dataGrid.ExpandAllDetailsView();
            else
                this.dataGrid.CollapseAllDetailsView();
        }

       
    }

   
}
