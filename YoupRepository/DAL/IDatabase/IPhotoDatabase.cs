using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IPhotoDatabase
    {
        List<Photo> getPhotos();

        Photo Create(Photo tpc);

        bool Delete(int id);

        bool Update(Photo tpc);

        Photo getPhoto(int id);
    }
}
