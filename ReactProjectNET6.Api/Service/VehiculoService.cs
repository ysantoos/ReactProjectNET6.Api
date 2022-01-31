using ReactProjectNET6.Api.Models;

namespace ReactProjectNET6.Api.Service
{

    public interface IVehiculoService
    {

        IEnumerable<Vehiculo> GetAll();
        bool Add(Vehiculo vehiculo);
        bool Remove(int IdVehiculo);
        bool Update(Vehiculo vehiculo);
        Vehiculo Get(int Id);

    }
    public class VehiculoService : IVehiculoService
    {
        public bool Add(Vehiculo vehiculo)
        {
            try
            {
                using (var db = new dbSatCenterContext())
                {
                    var originalModel = db.Vehiculos.Single(x =>
                    x.IdVehiculo == vehiculo.IdVehiculo);

                    if (originalModel != null)
                    {
                        originalModel.Placa = vehiculo.Placa;
                        originalModel.Descripcion = vehiculo.Descripcion;

                        db.Update(originalModel);
                        db.SaveChanges();

                    }
                    else
                    {
                        db.Add(vehiculo);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public Vehiculo Get(int Id)
        {
            var result = new Vehiculo();

            try
            {
                using (var db = new dbSatCenterContext())
                {
                    result = db.Vehiculos.Single(e => e.IdVehiculo == Id);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            var result = new List<Vehiculo>();

            try
            {
                using (var db = new Models.dbSatCenterContext())
                {
                    result = db.Vehiculos.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool Remove(int IdVehiculo)
        {
            try
            {
                using (var db = new dbSatCenterContext())
                {
                    db.Entry(new Vehiculo { IdVehiculo = IdVehiculo }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;
        }

        public bool Update(Vehiculo vehiculo)
        {
            try
            {
                using (var db = new dbSatCenterContext())
                {
                    var originalModel = db.Vehiculos.Single(x =>
                    x.IdVehiculo == vehiculo.IdVehiculo);

                    originalModel.Placa = vehiculo.Placa;
                    originalModel.Descripcion = vehiculo.Descripcion;

                    db.Update(originalModel);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
