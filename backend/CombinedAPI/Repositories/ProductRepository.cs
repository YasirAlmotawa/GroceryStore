using CombinedAPI.Models;
using CombinedAPI.Interfaces;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Logging.Abstractions;
using Azure.Messaging;

namespace CombinedAPI.Repositories
{
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

        string query = @"
              SELECT 
                  p.ProductID,
                  p.Name,
                  p.Description,
                  p.Price,
                  p.Images,
                  p.Manufacturer,
                  p.Dimensions,
                  p.Weight,
                  p.Rating,
                  p.SKU,
                  p.CategoryID,
                  p.Stock,
                  p.SaleID,
                  COALESCE(
                      CASE 
                          WHEN s.IsPercentage = 1 THEN p.Price * (1 - s.DiscountAmount / 100.0)
                          ELSE p.Price - s.DiscountAmount
                      END,
                      p.Price
                  ) AS DiscountedPrice
              FROM 
                  Products p
              LEFT JOIN 
                  Sales s ON p.SaleID = s.SaleID AND s.StartDate <= GETDATE() AND GETDATE() <= s.EndDate
              WHERE 
                  p.ProductID = @ProductID;";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductID", productId);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Price = (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                DiscountedPrice = reader.IsDBNull(reader.GetOrdinal("DiscountedPrice")) ? (double)reader.GetDecimal(reader.GetOrdinal("Price")) : (double)reader.GetDecimal(reader.GetOrdinal("DiscountedPrice")),
                Images = reader.GetString(reader.GetOrdinal("Images")),
                Manufacturer = reader.GetString(reader.GetOrdinal("Manufacturer")),
                Dimensions = reader.GetString(reader.GetOrdinal("Dimensions")),
                Weight = (double)reader.GetDecimal(reader.GetOrdinal("Weight")),
                Rating = (double)reader.GetDecimal(reader.GetOrdinal("Rating")),
                SKU = reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                SaleID = reader.IsDBNull(reader.GetOrdinal("SaleID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SaleID"))
              };
            }
          }
        }
      }
      return null;
    }

    public Product GetProductByName(string name)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = @"
              SELECT 
                  p.ProductID,
                  p.Name,
                  p.Description,
                  p.Price,
                  p.Images,
                  p.Manufacturer,
                  p.Dimensions,
                  p.Weight,
                  p.Rating,
                  p.SKU,
                  p.CategoryID,
                  p.Stock,
                  p.SaleID,
                  COALESCE(
                      CASE 
                          WHEN s.IsPercentage = 1 THEN p.Price * (1 - s.DiscountAmount / 100.0)
                          ELSE p.Price - s.DiscountAmount
                      END,
                      p.Price
                  ) AS DiscountedPrice
              FROM 
                  Products p
              LEFT JOIN 
                  Sales s ON p.SaleID = s.SaleID AND s.StartDate <= GETDATE() AND GETDATE() <= s.EndDate
              WHERE 
                  p.Name = @Name;";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@Name", name);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Price = (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                DiscountedPrice = reader.IsDBNull(reader.GetOrdinal("DiscountedPrice")) ? (double)reader.GetDecimal(reader.GetOrdinal("Price")) : (double)reader.GetDecimal(reader.GetOrdinal("DiscountedPrice")),
                Images = reader.GetString(reader.GetOrdinal("Images")),
                Manufacturer = reader.GetString(reader.GetOrdinal("Manufacturer")),
                Dimensions = reader.GetString(reader.GetOrdinal("Dimensions")),
                Weight = (double)reader.GetDecimal(reader.GetOrdinal("Weight")),
                Rating = (double)reader.GetDecimal(reader.GetOrdinal("Rating")),
                SKU = reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                SaleID = reader.IsDBNull(reader.GetOrdinal("SaleID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SaleID"))
              };
            }
          }
        }
      }
      return null;
    }


    public List<Product> GetProductByCategory(int categoryId)
    {
      List<Product> products = new List<Product>();

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = @"
              SELECT 
                  p.ProductID,
                  p.Name,
                  p.Description,
                  p.Price,
                  p.Images,
                  p.Manufacturer,
                  p.Dimensions,
                  p.Weight,
                  p.Rating,
                  p.SKU,
                  p.CategoryID,
                  p.Stock,
                  p.SaleID,
                  COALESCE(
                      CASE 
                          WHEN s.IsPercentage = 1 THEN p.Price * (1 - s.DiscountAmount / 100.0)
                          ELSE p.Price - s.DiscountAmount
                      END,
                      p.Price
                  ) AS DiscountedPrice
              FROM 
                  Products p
              LEFT JOIN 
                  Sales s ON p.SaleID = s.SaleID AND s.StartDate <= GETDATE() AND GETDATE() <= s.EndDate
              WHERE 
                  p.CategoryID = @CategoryID;";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@CategoryID", categoryId);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              products.Add(new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Price = (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                DiscountedPrice = reader.IsDBNull(reader.GetOrdinal("DiscountedPrice")) ? (double)reader.GetDecimal(reader.GetOrdinal("Price")) : (double)reader.GetDecimal(reader.GetOrdinal("DiscountedPrice")),
                Images = reader.GetString(reader.GetOrdinal("Images")),
                Manufacturer = reader.GetString(reader.GetOrdinal("Manufacturer")),
                Dimensions = reader.GetString(reader.GetOrdinal("Dimensions")),
                Weight = (double)reader.GetDecimal(reader.GetOrdinal("Weight")),
                Rating = (double)reader.GetDecimal(reader.GetOrdinal("Rating")),
                SKU = reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                SaleID = reader.IsDBNull(reader.GetOrdinal("SaleID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SaleID"))
              });
            }
          }
        }
      }

      if (products.Count == 0)
      {
        return null;
      }

      return products;
    }

    public List<Product> GetAllProducts()
    {
      List<Product> products = new List<Product>();

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = @"
              SELECT 
                  p.ProductID,
                  p.Name,
                  p.Description,
                  p.Price,
                  p.Images,
                  p.Manufacturer,
                  p.Dimensions,
                  p.Weight,
                  p.Rating,
                  p.SKU,
                  p.CategoryID,
                  p.Stock,
                  p.SaleID,
                  COALESCE(
                      CASE 
                          WHEN s.IsPercentage = 1 THEN p.Price * (1 - s.DiscountAmount / 100.0)
                          ELSE p.Price - s.DiscountAmount
                      END,
                      p.Price
                  ) AS DiscountedPrice
              FROM 
                  Products p
              LEFT JOIN 
                  Sales s ON p.SaleID = s.SaleID AND s.StartDate <= GETDATE() AND GETDATE() <= s.EndDate;";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              products.Add(new Product
              {
                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Price = (double)reader.GetDecimal(reader.GetOrdinal("Price")),
                DiscountedPrice = reader.IsDBNull(reader.GetOrdinal("DiscountedPrice")) ? (double)reader.GetDecimal(reader.GetOrdinal("Price")) : (double)reader.GetDecimal(reader.GetOrdinal("DiscountedPrice")),
                Images = reader.GetString(reader.GetOrdinal("Images")),
                Manufacturer = reader.GetString(reader.GetOrdinal("Manufacturer")),
                Dimensions = reader.GetString(reader.GetOrdinal("Dimensions")),
                Weight = (double)reader.GetDecimal(reader.GetOrdinal("Weight")),
                Rating = (double)reader.GetDecimal(reader.GetOrdinal("Rating")),
                SKU = reader.GetString(reader.GetOrdinal("SKU")),
                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                SaleID = reader.IsDBNull(reader.GetOrdinal("SaleID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SaleID"))
              });
            }
          }
        }
      }
      return products;
    }

    // Update product stock
    public bool UpdateProductStock(int productID, int stock)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();

        string query = "UPDATE Products SET stock = @stock WHERE productID = @productID";
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ProductID", productID);
          cmd.Parameters.AddWithValue("@stock", stock);

          int rowsAffected = cmd.ExecuteNonQuery();
          return rowsAffected > 0;
        }
      }
    }
  }
}
