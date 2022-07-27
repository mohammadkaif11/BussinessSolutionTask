using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Reposistory
{
    public class ReposistoryBase<T> : IResposistoryBase<T> where T : class
    {
        private readonly TechdomEntities dataContext;
        private DbSet<T> entites;
        public ReposistoryBase(TechdomEntities _dataContext)
        {
            dataContext = _dataContext;
            entites = dataContext.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {

            var cmd = dataContext.Database.Connection.CreateCommand();

            var Email = new SqlParameter("@email", SqlDbType.VarChar);
            var Password = new SqlParameter("@password", SqlDbType.VarChar);
            Email.Value = email;
            Password.Value = password;

            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(Password);

            cmd.CommandText = "spGetUsers";
            cmd.CommandType = CommandType.StoredProcedure;


            DataSet ds = new DataSet();
            DataTable t;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                while (!reader.IsClosed)
                {
                    t = new DataTable();
                    t.Load(reader);
                    ds.Tables.Add(t);
                }
            }
            var userobj = new User();

            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    userobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    userobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    userobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    userobj.IsActive = ds.Tables[0].Rows[i]["IsActive"].ToString();
                    userobj.Roles = ds.Tables[0].Rows[i]["Roles"].ToString();
                    userobj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                    userobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();

                }
            }

            return userobj;
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Singup(T entity)
        {
            entites.Add(entity);
            dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
