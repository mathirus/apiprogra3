using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class Datos
    {
        public string myConnectionString = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424";

        public List<Product> GetAll()
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                var productos = conn.Query<Product>(sql).ToList();
                return productos;
            }
        }

        public Product Create(string Name, int Price)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Products (Title, Description, Category, Price) 
                               VALUES (@Title, @Description, @Category, @Price);
                               SELECT LAST_INSERT_ID();";
                var parameters = new
                {
                    Title = Name,
                    Description = Name,
                    Category = Name,
                    Price = Price
                };

                int newId = conn.QuerySingle<int>(sql, parameters);

                // Obtener el producto recién creado
                string selectSql = "SELECT * FROM Products WHERE Id = @Id";
                var product = conn.QuerySingle<Product>(selectSql, new { Id = newId });

                return product;
            }
        }

        public Product GetById(int Id)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products WHERE Id = @Id";
                var product = conn.QueryFirstOrDefault<Product>(sql, new { Id });

                return product;
            }
        }

        public Product Update(int Id, string Title, int Price)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = @"UPDATE Products 
                               SET Title = @Title, Price = @Price 
                               WHERE Id = @Id";
                var parameters = new
                {
                    Id,
                    Title,
                    Price
                };

                int rowsAffected = conn.Execute(sql, parameters);

                if (rowsAffected == 0)
                {
                    return null; // Producto no encontrado
                }

                // Obtener el producto actualizado
                string selectSql = "SELECT * FROM Products WHERE Id = @Id";
                var product = conn.QueryFirstOrDefault<Product>(selectSql, new { Id });

                return product;
            }
        }

        public bool Delete(int Id)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Products WHERE Id = @Id";
                int rowsAffected = conn.Execute(sql, new { Id });

                return rowsAffected > 0;
            }
        }
    }
}
