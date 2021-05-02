using SIRRC.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SIRRC.Views
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