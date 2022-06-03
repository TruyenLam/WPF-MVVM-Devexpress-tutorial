using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using WPF_MVVM_Devexpress_tutorial.Dbcontect;
using System.Linq;

namespace WPF_MVVM_Devexpress_tutorial.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Entity
        NorthwindEntities db = new NorthwindEntities();
        #endregion
        #region List
        public ObservableCollection<Product> List_Product
        {
            get { return GetProperty(() => List_Product); }
            set { SetProperty(() => List_Product, value); }
        }
        #endregion
        #region Khai bao bien
        public string ProductName
        {
            get { return GetProperty(() => ProductName); }
            set { SetProperty(() => ProductName, value); }
        }
        #endregion
        #region Phan Quyen
        public bool cmdThem
        {
            get { return GetProperty(() => cmdThem); }
            set { SetProperty(() => cmdThem, value); }
        }
    
        #endregion

        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            List_Product = new ObservableCollection<Product>();
        }
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            

        }
        #region Khai bao command
        public DelegateCommand Btn_LoadDS_SP { get; private set; }
        #endregion
        public MainViewModel()
        {
            Btn_LoadDS_SP  = new DelegateCommand(Btn_LoadDS_SP_, true);
        }

        private void Btn_LoadDS_SP_()
        {
            Load_Product();
        }

        public void Load_Product()
        {
            var list = db.Products.ToList();
            List_Product = new ObservableCollection<Product>(list);
        }
    }
}