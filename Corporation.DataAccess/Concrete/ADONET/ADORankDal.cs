using System;
using System.Collections.Generic;
using System.Text;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;
using Microsoft.Data.SqlClient;

namespace Corporation.DataAccess.Concrete.ADONET
{
    public class ADORankDal:IADORepository<Rank>
    {
        public void Add(Rank entity)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Ranks VALUES (@RankName)"))
            {
                cmd.Parameters.AddWithValue("RankName", entity.RankName);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Update(Rank entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("UPDATE Ranks set RankId = @RankId, RankName = @RankName,  where RankId = @RankId"))
            {
                cmd.Parameters.AddWithValue("RankId", entity.RankId);
                cmd.Parameters.AddWithValue("RankName", entity.RankName);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Delete(Rank entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM Ranks where RankId = @RankId"))
            {
                cmd.Parameters.AddWithValue("Id", entity.RankId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public List<Rank> GetAll()
        {
            var categoryList = new List<Rank>();
            SqlCommand cmd = new SqlCommand("Select * from Ranks");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Rank category = new Rank()
                {
                    RankId = Convert.ToInt32(reader[0]),
                    RankName = reader[1].ToString(),
                };

                categoryList.Add(category);
            }
            return categoryList;
        }

        public Rank Get(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Ranks where Id = @RankId");
            cmd.Parameters.AddWithValue("RankId", id);

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Rank category = new Rank()
                {
                    RankId = Convert.ToInt32(reader[0]),
                    RankName = reader[1].ToString(),
                };

                return category;
            }
            return null;
        }
    }
}
