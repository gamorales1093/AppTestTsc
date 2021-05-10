using AppTestTsc.ViewModels;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTestTsc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : ContentPage
    {
        public CountriesPage()
        {
            InitializeComponent();
            this.BindingContext = new CountriesViewModel();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.slvCountries.LayoutManager is GridLayout)
                {
                    (this.slvCountries.LayoutManager as GridLayout).SpanCount = 1;
                }
            }
            else
            {
                if (this.slvCountries.LayoutManager is GridLayout)
                {
                    (this.slvCountries.LayoutManager as GridLayout).SpanCount = 2;
                }
            }
        }
    }
}