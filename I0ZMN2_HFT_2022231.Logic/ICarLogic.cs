using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public interface ICarLogic
    {
        Car GetCarById(int id);
        IEnumerable<Car> GetAllCars();
        void AddNewCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);



        //IEnumerable<KeyValuePair<string, double>> AVGAgeOfDoctorsPatients();
        //IEnumerable<IEnumerable<string>> AllDiseasesPerDoctor();
        //IEnumerable<KeyValuePair<string, int>> DiseasePerDoctor(string disease);
    }
}
