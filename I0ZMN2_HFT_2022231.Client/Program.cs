using ConsoleTools;
using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;

namespace I0ZMN2_HFT_2022231.Client
{
    internal class Program
    {
        public static RestService rserv = new RestService("http://localhost:13104");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);


            var menu = new ConsoleMenu()
               .Add("CRUD methods", () => CrudMenu())
               .Add("non-CRUD methods", () => NonCrudMenu())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CrudMenu()
        {

            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                .Add("Get one element", ReadPreMenu)
                .Add("Get all element", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        private static void NonCrudMenu()
        {
            var menu = new ConsoleMenu()
               .Add("Get RentCar at the Suzuki Brand", GetRentCarsAtSuzukiBrand)
               .Add("Get RentCar where their's Car price is over 200.000.000$", GetRentCarWhereWinIsOverTen)
               .Add("Get RentCar where their's Car model name is Boeing 787-8", GetRentCarWhereTeamNameIsRoll)
               .Add("Get Brands where is a RentCar with Canadian nationality", GetBrandtName)
               .Add("Get Brands where is a RentCar with the last name Cohen", GetBrandtAtTwenty)
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PreMenu(Action RentCar, Action Car, Action Brand)
        {
            var menu = new ConsoleMenu()
                .Add("RentCar", RentCar)
                .Add("Car", Car)
                .Add("Brand", Brand)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        //-------------------------------------------------------------------------------------------------------------CRUD------------------------------------------------

        //---------------------Create-------------------------
        private static void CreatePreMenu()
        {
            PreMenu(CreateRentCar, CreateCar, CreateBrand);
        }

        private static void CreateBrand()
        {
            Console.WriteLine("BrandName: ");
            string brandname = Console.ReadLine();
            Console.WriteLine("Age:");
            int brandyear = int.Parse(Console.ReadLine());
            rserv.Post<Brand>(new Brand() { BrandName = brandname, BrandYear = brandyear }, "Brand");
        }

        private static void CreateCar()
        {
            Console.WriteLine("TeamName: ");
            string carname = Console.ReadLine();
            Console.WriteLine("Wins:");
            string cartype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            rserv.Post<Car>(new Car() { CarName = carname, CarType = cartype, Brand_id = brandid }, "Car");
        }

        private static void CreateRentCar()
        {
            Console.WriteLine("Name: ");
            string buyername = Console.ReadLine();
            Console.WriteLine("Role name:");
            string buyergender = Console.ReadLine();
            Console.WriteLine("Car id: ");
            int Carid = int.Parse(Console.ReadLine());
            rserv.Post<RentCar>(new RentCar() { BuyerName = buyername, BuyerGender = buyergender, Car_id = Carid }, "RentCar");
        }

        //---------------------END-Create-------------------





        //---------------------Read------------------------
        private static void ReadPreMenu()
        {
            PreMenu(ReadRentCar, ReadCar, ReadBrand);
        }

        private static void ReadBrand()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getBrand = rserv.Get<Brand>(id, "Brand");
            Console.WriteLine($"Id: {getBrand.Id}, BrandName: {getBrand.BrandName}, BrandYear: {getBrand.BrandYear}");
            Console.ReadLine();

        }

        private static void ReadCar()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getCar = rserv.Get<Car>(id, "Car");
            Console.WriteLine($"Id: {getCar.Id}, CarName: {getCar.CarName}, CarType: {getCar.CarType}, BrandId: {getCar.Brand_id}");
            Console.ReadLine();
        }

        private static void ReadRentCar()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getRentCar = rserv.Get<RentCar>(id, "RentCar");
            Console.WriteLine($"Id: {getRentCar.Id}, BuyerName: {getRentCar.BuyerName}, BuyerGender: {getRentCar.BuyerGender}, CarId: {getRentCar.Car_id}");
            Console.ReadLine();
        }

        //---------------------END-Read-------------------





        //----------------------ReadAll----------------------
        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllRentCar, PrintAllCars, PrintAllBrands);
        }

        private static void PrintAllRentCar()
        {
            var RentCar = rserv.Get<RentCar>("RentCar");
            Console.WriteLine("-------------RentCar-------------");
            RentCarToConsole(RentCar);
            Console.ReadLine();
        }
        private static void PrintAllCars()
        {
            var Cars = rserv.Get<Car>("Car");
            Console.WriteLine("-------------Cars-------------");
            CarToConsole(Cars);
            Console.ReadLine();
        }
        private static void PrintAllBrands()
        {
            var Brands = rserv.Get<Brand>("Brand");
            Console.WriteLine("-------------Brands-------------");
            BrandToConsole(Brands);
            Console.ReadLine();
        }
        //---------------END-ReadAll-------------------





        //-----------------Update-------------------
        private static void UpdatePreMenu()
        {
            PreMenu(UpdateRentCar, UpdateCar, UpdateBrand);
        }

        private static void UpdateBrand()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BrandName: ");
            string BrandName = Console.ReadLine();
            Console.WriteLine("BrandYear:");
            int brandyear = int.Parse(Console.ReadLine());
            Brand input = new Brand() { Id = id, BrandName = BrandName, BrandYear = brandyear };
            rserv.Put(input, "Brand");
        }

        private static void UpdateCar()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("CarName: ");
            string teamname = Console.ReadLine();
            Console.WriteLine("CarType:");
            string cartype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            Car input = new Car() { Id = id, CarName = teamname, CarType = cartype, Brand_id = brandid };
            rserv.Put(input, "Car");
        }

        private static void UpdateRentCar()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BuyerName: ");
            string name = Console.ReadLine();
            Console.WriteLine("BuyDate:");
            int buydate = int.Parse(Console.ReadLine());
            Console.WriteLine("Car id: ");
            int Carid = int.Parse(Console.ReadLine());
            RentCar input = new RentCar() { Id = id, BuyerName = name, BuyDate = buydate, Car_id = Carid };
            rserv.Put(input, "RentCar");
        }

        //-----------------END-Update-------------





        //-----------------Delete--------------
        private static void DeletePreMenu()
        {
            PreMenu(DeleteRentCar, DeleteCar, DeleteBrand);
        }

        private static void DeleteBrand()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Brand");
        }

        private static void DeleteCar()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Car");
        }

        private static void DeleteRentCar()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "RentCar");
        }

        //-------------------END-Delete----------













        ////-------------------------------------------------------------------------------------------------------------non-CRUD------------------------------------------------

        private static void GetRentCarsAtSuzukiBrand()
        {
            var output = rserv.Get<IEnumerable<RentCar>>("stat/GetRentCarsAtSuzukiBrand");
            ;
            //RentCarToConsole(output);
            Console.ReadLine();
        }
        private static void GetRentCarWhereWinIsOverTen()
        {
            var output = rserv.Get<RentCar>("stat/GetRentCarWhereWinIsOverTen");
            RentCarToConsole(output);
            Console.ReadLine();
        }

        private static void GetRentCarWhereTeamNameIsRoll()
        {
            var output = rserv.Get<RentCar>("stat/GetRentCarWhereTeamNameIsRoll");
            RentCarToConsole(output);
            Console.ReadLine();
        }
        private static void GetBrandtName()
        {
            var output = rserv.Get<Brand>("stat/GetBrandtName");
            BrandToConsole(output);
            Console.ReadLine();
        }
        private static void GetBrandtAtTwenty()
        {
            var output = rserv.Get<Brand>("stat/GetBrandtAtTwenty");
            BrandToConsole(output);
            Console.ReadLine();
        }















        ////-------------------------------------------------------------------------------------------------------------ToConsole------------------------------------------------
        private static void RentCarToConsole(IEnumerable<RentCar> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BuyDate: {item.BuyDate}, BuyerName: {item.BuyerName}, CarId: {item.Car_id}");
            }
        }
        private static void CarToConsole(IEnumerable<Car> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, CarName: {item.CarName}, CarType: {item.CarType}, BrandId: {item.Brand_id}");
            }
        }
        private static void BrandToConsole(IEnumerable<Brand> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BrandName: {item.BrandName}, BrandYear: {item.BrandYear}");
            }
        }
    }
}
