using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoupRepository.DAL;

namespace YoupRepository.DAL
{
    public interface IThreadDatabase
    {
        List<Thread> getThreads();

        Thread Create(Thread tpc);

        bool Delete(int id);

        bool Update(Thread tpc);

        Thread getThread(int id);
    }
}
