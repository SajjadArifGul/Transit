using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Data;
using Transit.Entities;

namespace Transit.Services
{
    public class TransitService
    {
        TransitURLs transitURLs = new TransitURLs();

        #region Define as Singleton
        private static TransitService _Instance;

        public static TransitService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TransitService();
                }

                return (_Instance);
            }
        }

        private TransitService()
        {
        }
        #endregion

        public List<TransitURL> GetAllTransitURLs()
        {
            return transitURLs.GetAll();
        }

        public TransitURL GetTransitURLByID(int ID)
        {
            return transitURLs.GetAll().Where(t => t.ID == ID).FirstOrDefault();
        }

        public TransitURL GetTransitURLByName(string Name)
        {
            return transitURLs.GetAll().Where(t => t.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public bool IsUpdateAllowed(int ID, string Name)
        {
            if (transitURLs.GetAll().Where(t => t.Name == Name).Where(t => t.ID != ID).FirstOrDefault() != null)
            {
                return false;
            }
            else return true;
        }

        public bool AddNewTransitURL(TransitURL transitURL)
        {
            return transitURLs.Add(transitURL);
        }

        public bool UpdateTransitURL(TransitURL transitURL)
        {
            return transitURLs.Update(transitURL);
        }

        public bool DeleteTransitURL(TransitURL transitURL)
        {
            return transitURLs.Delete(transitURL);
        }

        public bool DeleteTransitURLByID(int ID)
        {
            return transitURLs.Delete(new TransitURL() { ID = ID });
        }
    }
}
