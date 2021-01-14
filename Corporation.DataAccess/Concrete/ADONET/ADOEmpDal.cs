using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;
using Microsoft.Data.SqlClient;

namespace Corporation.DataAccess.Concrete.ADONET
{
    public class ADOEmpDal:IEmpDal
    {
        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            var empList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Select * from Employees");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    Id = Convert.ToInt32(reader[0]),
                    FirstName = reader[1].ToString(),
                    LastName = reader[2].ToString(),
                    Salary = Convert.ToDecimal(reader[3]),
                    RankId = Convert.ToInt32(reader[4]),
                };

                empList.Add(emp);
            }
            return empList;
        }

        public Employee Get(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Employees where Id = @Id");
            cmd.Parameters.AddWithValue("Id", id);

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    Id = Convert.ToInt32(reader[0]),
                    FirstName = reader[1].ToString(),
                    LastName = reader[2].ToString(),
                    Salary = Convert.ToDecimal(reader[3]),
                    RankId = Convert.ToInt32(reader[4]),
                };

                return emp;
            }
            return null;
        }

        public void Add(Employee entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("INSERT INTO Employees (FirstName,LastName,Salary, RankId) VALUES (@FirstName,@LastName,@salary, @RankIdd)"))
            {
                cmd.Parameters.AddWithValue("FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("LastName", entity.LastName);
                cmd.Parameters.AddWithValue("Salary", entity.Salary);
                cmd.Parameters.AddWithValue("RankId", entity.RankId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Update(Employee entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("UPDATE Employees set FirstName = @FirstName, LastName = @LastName, Salary = @Salary, RankId = @RankId, where Id = @Id"))
            {
                cmd.Parameters.AddWithValue("Id", entity.Id);
                cmd.Parameters.AddWithValue("FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("LastName", entity.LastName);
                cmd.Parameters.AddWithValue("Salary", entity.Salary);
                cmd.Parameters.AddWithValue("RankId", entity.RankId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Delete(Employee entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM Employees where Id = @Id"))
            {
                cmd.Parameters.AddWithValue("Id", entity.Id);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }
    }
}
