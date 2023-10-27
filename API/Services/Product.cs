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
                        UnitOfMeasured = queryResult["unit_of_measure"].ToString(),
                    });
                }
            }

            return result;
        }
    }
}
