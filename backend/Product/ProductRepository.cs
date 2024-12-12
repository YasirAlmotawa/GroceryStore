namespace Product
{
  using System;
  using Microsoft.Data.SqlClient;
  using System.Collections.Generic;

  public class ProductRepository : IProductRepository
  {
    private string _connectionString;
    public ProductRepository(string connectionString)
    {
      _connectionString = connectionString;
    }
    public Product GetProductById(int productId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        // Query to select the product by ID
        string query = "SELECT * FROM Product WHERE ProductID = @ProductId";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductID", productId);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              // Return a new Product object filled with data from SQL
              return new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Price")),
                Images = reader.IsDBNull(reader.GetOrdinal("Images")) ? string.Empty : reader.GetString(reader.GetOrdinal("Images")),
                Manufacturer = reader.IsDBNull(reader.GetOrdinal("Manufacturer")) ? string.Empty : reader.GetString(reader.GetOrdinal("Manufacturer")),
                Dimensions = reader.IsDBNull(reader.GetOrdinal("Dimensions")) ? string.Empty : reader.GetString(reader.GetOrdinal("Dimensions")),
                Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Weight")),
                Rating = reader.IsDBNull(reader.GetOrdinal("Rating")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Rating")),
                SKU = reader.IsDBNull(reader.GetOrdinal("SKU")) ? string.Empty : reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.IsDBNull(reader.GetOrdinal("Stock")) ? 0 : reader.GetInt32(reader.GetOrdinal("Stock")),
                Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Discount")),
                DiscountStartDate = reader.IsDBNull(reader.GetOrdinal("DiscountStartDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DiscountStartDate")),
                DiscountEndDate = reader.IsDBNull(reader.GetOrdinal("DiscountEndDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DiscountEndDate"))
              };
            }
          }
        }
      }
      throw new InvalidOperationException($"No product found with ID {productId}.");
    }

    // Fetch all products from the database
    public List<Product> GetAllProducts()
    {
      List<Product> products = new List<Product>();

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "SELECT * FROM Product"; // Retrieve all products
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              products.Add(new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                Price = Convert.ToDouble(reader["Price"]),
                Images = reader["Images"] as string ?? string.Empty,
                Manufacturer = reader["Manufacturer"] as string ?? string.Empty,
                Dimensions = reader["Dimensions"] as string ?? string.Empty,
                Weight = Convert.ToDouble(reader["Weight"]),
                Rating = Convert.ToDouble(reader["Rating"]),
                SKU = reader.IsDBNull(reader.GetOrdinal("SKU")) ? string.Empty : reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.IsDBNull(reader.GetOrdinal("Stock")) ? 0 : reader.GetInt32(reader.GetOrdinal("Stock")),
                Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? 0.0 : reader.GetDouble(reader.GetOrdinal("Discount")),
                DiscountStartDate = reader.IsDBNull(reader.GetOrdinal("DiscountStartDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DiscountStartDate")),
                DiscountEndDate = reader.IsDBNull(reader.GetOrdinal("DiscountEndDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DiscountEndDate"))
              });
            }
          }
        }
      }
      return products;
    }

    // Update product stock
    public bool UpdateProductStock(int productId, int stock)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "UPDATE Product SET Stock = @Stock WHERE ProductID = @ProductId";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductId", productId);
          cmd.Parameters.AddWithValue("@Stock", stock);

          int rowsAffected = cmd.ExecuteNonQuery();
          return rowsAffected > 0;
        }
      }
    }

    // Apply discount to a product
    public bool ApplyDiscount(int productId, double discount)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "UPDATE Product SET Discount = @Discount WHERE ProductID = @ProductId";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductId", productId);
          cmd.Parameters.AddWithValue("@Discount", discount);

          int rowsAffected = cmd.ExecuteNonQuery();
          return rowsAffected > 0;
        }
      }
    }

    // Check if the product is in stock
    public bool inStock(int productId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "SELECT Stock FROM Product WHERE ProductID = @ProductId";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductId", productId);

          object result = cmd.ExecuteScalar();
          return result != DBNull.Value && (int)result > 0;
        }
      }
    }

    // Edit the product rating
    public void EditRating(int productId, double rating)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "UPDATE Product SET Rating = @Rating WHERE ProductID = @ProductId";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductId", productId);
          cmd.Parameters.AddWithValue("@Rating", rating);

          cmd.ExecuteNonQuery();
        }
      }
    }
  }
}
