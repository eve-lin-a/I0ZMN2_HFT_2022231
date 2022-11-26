using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public class Carlogic: ICarLogic
    {
        IRepository<Car> CarRepository;
        IRepository<Brand> BrandRepository;

        public Carlogic(IRepository<Car> CarRepository, IRepository<Brand> BrandRepository)
        {
            this.CarRepository = CarRepository;
            this.BrandRepository = BrandRepository;
        }


        public void AddNewCar(Car car)
        {
            CarRepository.Create(car);
        }

        //public IEnumerable<KeyValuePair<string, double>> AVGAgeOfCarsandBrands()
        //{
        //    return (from x in patientRepository.GetAll()
        //            group x by x.Doctor.Name into g
        //            select new KeyValuePair<string, double>
        //            (
        //                g.Key, g.Average(x => x.Age)
        //            )).ToList();
        //}

        public void DeleteCar(int id)
        {
            CarRepository.Delete(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return CarRepository.GetAll();
            //if (cars.Count != 0)
            //{
            //    return doctorList;
            //}
            //else
            //{
            //    throw new ListIsEmptyException("GetAllDoctors");
            //}
        }

        public Car GetCarById(int id)
        {

            if (CarRepository.GetAll().Any(x => x.Id.Equals(id)))
            {
                return CarRepository.Get(id);
            }
            else
            {
                throw new IndexOutOfRangeException("{ERROR} ID was too big!");
            }
        }

        //public IEnumerable<IEnumerable<string>> AllDiseasesPerDoctor()
        //{


        //    return doctorRepository.GetAll().Select(x => x.Patients.Select(y => y.Disease).ToList()).ToList();


            //TESTS

            //var dlist = patientRepository.GetAll().Select(x => x.Disease).ToList();
            //var doctorName = doctorRepository.GetAll().Select(x => x.Name).ToList();

            //;       



            //;

            //var asd = (from x in doctorRepository.GetAll()
            //           group x by x.Name into g
            //           select new
            //           {
            //               KEY = g.Key,
            //               DISEASE = g.Select(x => x.Patients.Select(y => y.Disease).ToList()).ToList()
            //           }).ToList();


            //var asd = doctors.Select(x => x.Patients.Max(y => y.Disease));

            //;
            //var sub = from x in patientRepository.GetAll()
            //          group x by x.Disease into g
            //          select new
            //          {
            //              DISEASE = g.Key,
            //              COUNT = g.Count(),
            //              DOCTOR_ID = g.Select(y => y.DoctorID).SingleOrDefault()
            //          };



            //return null;
            //return (from x in doctorrepository.getall()
            //        join z in sub on x.doctorid equals z.doctor_id
            //        let joineditem = new { x.doctorid, x.name, z.disease }
            //        group joineditem by joineditem.name into g
            //        select new keyvaluepair<string, int>()
            //        {

            //        }


            //return (from x in patientrepository.getall()
            //        group x by x.doctor.name into g
            //        select new keyvaluepair<string, ienumerable<string>>
            //        (
            //            g.key, dlist
            //        )).tolist();

        //}

        public void UpdateCar(Car car)
        {
            CarRepository.Update(car);
        }


        //ilyesmiket

        //public IEnumerable<KeyValuePair<string, int>> DiseasePerDoctor(string disease)
        //{
        //    return (from x in patientRepository.GetAll()
        //            group x by x.Doctor.Name into g
        //            select new KeyValuePair<string, int>
        //            (
        //                g.Key, g.Where(y => y.Disease.Equals(disease)).Count()
        //            )).ToList();
        //}

        //public IEnumerable<KeyValuePair<string, int>> BuyerByCar(string buyer)
        //{ 
        //    return (from x in CarRepository.GetAll()
        //            group x by x.CarName into g
        //            select new KeyValuePair<string, int>
        //            (
        //                g.Key, g.Where(y => y.BuyerName.Equals(buyer)).Count()
        //            )).ToList();
        //}
    }
}
