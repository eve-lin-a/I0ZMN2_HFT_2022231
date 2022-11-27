using I0ZMN2_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace I0ZMN2_HFT_2022231.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<RentCar> RentCars { get; set; }

        private Brand selectedBrand;
        private Car selectedCar;
        private RentCar selectedRentCar;




        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        BrandName = value.BrandName,
                        BrandCountry = value.BrandCountry,
                        BrandYear = value.BrandYear


                    };
                    OnPropertyChanged();
                    (DeleteBrand as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateBrand as RelayCommand).NotifyCanExecuteChanged();
                }


            }
        }
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Id = value.Id,
                        CarName = value.CarName,
                        CarType = value.CarType,
                        CarPrice = value.CarPrice,
                        Brand_id = value.Brand_id


                    };
                    OnPropertyChanged();
                    (DeleteCar as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateCar as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public RentCar SelectedRentCar
        {
            get => selectedRentCar;
            set
            {
                if (value != null)
                {
                    selectedRentCar = new RentCar()
                    {
                        Id = value.Id,
                        BuyerName = value.BuyerName,
                        BuyDate = value.BuyDate,
                        BuyerGender = value.BuyerGender,
                        IsFirstCar = value.IsFirstCar,
                        Car_id = value.Car_id

                    };
                    OnPropertyChanged();
                    (DeleteRentCar as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateRentCar as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ICommand CreateBrand { get; set; }
        public ICommand UpdateBrand { get; set; }
        public ICommand DeleteBrand { get; set; }

        public ICommand CreateCar { get; set; }
        public ICommand UpdateCar { get; set; }
        public ICommand DeleteCar { get; set; }

        public ICommand CreateRentCar { get; set; }
        public ICommand UpdateRentCar { get; set; }
        public ICommand DeleteRentCar { get; set; }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:13104/", "Brand", "hub");
                CreateBrand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {

                        BrandName = SelectedBrand.BrandName,
                        BrandYear = SelectedBrand.BrandYear

                    });
                });
                UpdateBrand = new RelayCommand(() => Brands.Update(SelectedBrand));
                DeleteBrand = new RelayCommand(() => Brands.Delete(SelectedBrand.Id), () => SelectedBrand != null);
                SelectedBrand = new Brand();

                //---------------------------------------------------------------
                Cars = new RestCollection<Car>("http://localhost:13104/", "Car", "hub");
                CreateCar = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {


                        CarName = SelectedCar.CarName,
                        CarType = SelectedCar.CarType,
                        Brand_id = SelectedCar.Brand_id

                    });
                });
                UpdateCar = new RelayCommand(() => Cars.Update(SelectedCar));
                DeleteCar = new RelayCommand(() => Cars.Delete(SelectedCar.Id), () => SelectedCar != null);
                SelectedCar = new Car();

                //---------------------------------------------------------------
                RentCars = new RestCollection<RentCar>("http://localhost:13104/", "RentCar", "hub");
                CreateRentCar = new RelayCommand(() =>
                {
                    RentCars.Add(new RentCar()
                    {

                        BuyerName = SelectedRentCar.BuyerName,
                        BuyDate = SelectedRentCar.BuyDate,
                        Car_id = SelectedRentCar.Car_id

                    });
                });
                UpdateRentCar = new RelayCommand(() => RentCars.Update(SelectedRentCar));
                DeleteRentCar = new RelayCommand(() => RentCars.Delete(SelectedRentCar.Id), () => SelectedRentCar != null);
                SelectedRentCar = new RentCar();

            }


        }


    }
}
