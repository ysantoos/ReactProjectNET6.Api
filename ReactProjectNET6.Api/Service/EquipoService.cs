using ReactProjectNET6.Api.Models;

namespace ReactProjectNET6.Api.Service
{

    public interface IEquipoService
    {

        IEnumerable<Equipo> GetAll();
        //bool Add(Equipo equipo);
        //bool Remove(Equipo equipo);
        //bool Update(Equipo equipo);
        Equipo Get(int Id);

    }
    public class EquipoService : IEquipoService
    {
        //public bool Add(Equipo equipo)
        //{
        //    throw new NotImplementedException();
        //}

        public Equipo Get(int Id)
        {
            var result = new Equipo();

            try
            {
                using (var db = new dbSatCenterContext())
                {
                    result = db.Equipos.Single(e => e.IdEquipo == Id);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public IEnumerable<Equipo> GetAll()
        {
            var result = new List<Equipo>();

            try
            {
                using (var db = new Models.dbSatCenterContext())
                {
                    result = db.Equipos.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        //public bool Remove(Equipo equipo)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(Equipo equipo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
