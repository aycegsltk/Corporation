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
                    Name = reader[1].ToString(),
                    Salary = Convert.ToDecimal(reader[2]),
                    RankId = Convert.ToInt32(reader[3]),
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
                    Name = reader[1].ToString(),
                    Salary = Convert.ToDecimal(reader[2]),
                    RankId = Convert.ToInt32(reader[3]),
                };

                return emp;
            }
            return null;
        }

        public void Add(Employee entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("INSERT INTO Employees (Name,Salary, RankId) VALUES (@Name,@salary, @RankIdd)"))
            {
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Salary", entity.Salary);
                cmd.Parameters.AddWithValue("RankId", entity.RankId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Update(Employee entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("UPDATE Employees set Name = @Name, Salary = @Salary, RankId = @RankId, where Id = @Id"))
            {
                cmd.Parameters.AddWithValue("Id", entity.Id);
                cmd.Parameters.AddWithValue("Name", entity.Name);
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
