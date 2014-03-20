using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class PhotoDatabase : IPhotoDatabase
    {

        public List<Photo> getPhotos()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Photos.ToList();
        }

        public Photo Create(Photo tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Photos.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Photo notDisplay = ye.Photos.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Photo tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Photo>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Photo getPhoto(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Photos.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
