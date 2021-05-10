using AppTestTsc.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppTestTsc.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}