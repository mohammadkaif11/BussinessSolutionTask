using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Reposistory
{
    public interface IResposistoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        User Login(string username,string password);
        void Singup(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
