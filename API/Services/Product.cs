using System.Data.SqlClient;
using API.Models;

namespace API.Services {
    public class ProductService {
        public static List<Product> getAllProducts(){
            var result = new List<Product>();

            using (var conn = BaseService.getConnection())
            {
                var sql = new SqlCommand("SELECT * FROM product", conn);
                var queryResult = sql.ExecuteReader();

                while(queryResult.Read())
                {
                    result.Add(new Product() {
                        Id = Convert.ToInt32(queryResult["id"]),
                        Name = queryResult["name"].ToString(),
                        UnitOfMeasure = queryResult["unit_of_measure"].ToString(),
                    });
                }
            }

            return result;
        }


        public static bool insertProduct(Product product)
        {
            try {
                using(var conn = BaseService.getConnection())
                {
                    var sql = new SqlCommand("INSERT INTO product (name, unit_of_measure) values (@name, @uom)", conn);
                    sql.Parameters.AddWithValue("@name", product.Name);
                    sql.Parameters.AddWithValue("@uom", product.UnitOfMeasure);
                    var queryResult = sql.ExecuteNonQuery();
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }            
        }

        public static bool deleteProduct(int id)
        {
            try {
                using(var conn = BaseService.getConnection())
                {
                    var sql = new SqlCommand("DELETE FROM product WHERE Id = @id", conn);
                    sql.Parameters.AddWithValue("@id", id);
                    var queryResult = sql.ExecuteNonQuery();
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool updateProduct(Product product)
        {
            try{
                using(var conn = BaseService.getConnection())
                {
                    var sql = new SqlCommand("UPDATE product SET name=@name, unit_of_measure = @uom WHERE Id = @id", conn);
                    sql.Parameters.AddWithValue("@name", product.Name);
                    sql.Parameters.AddWithValue("@uom", product.UnitOfMeasure);
                    sql.Parameters.AddWithValue("@id", product.Id);
                    var queryResult = sql.ExecuteNonQuery();
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
