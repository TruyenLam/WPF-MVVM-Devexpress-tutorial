using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using WPF_MVVM_Devexpress_tutorial.Dbcontect;
using System.Linq;

namespace WPF_MVVM_Devexpress_tutorial.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        NorthwindEntities db = new NorthwindEntities();
        public ObservableCollection<Product> List_Product
        {
            get { return GetProperty(() => List_Product); }
            set { SetProperty(() => List_Product, value); }
        }
        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            List_Product = new ObservableCollection<Product>();
        }
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Load_Product();

        }

        public MainViewModel()
        {

        }
        public void Load_Product()
        {
            var list = db.Products.ToList();
            List_Product = new ObservableCollection<Product>(list);
        }
    }
}