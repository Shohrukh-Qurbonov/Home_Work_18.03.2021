using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApplication.Repositories
{
    public class RepositoryBase<T>
    {
        public string path { get; private set; }
        public RepositoryBase()
        {
            path = "Data source=DESKTOP-4HBI2PP\\SQLEXPRESS; Initial catalog=Alif; Integrated security=true;";
        }
        public List<T> SelectAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(path))
                {
                    return db.Query<T>($"SELECT * FROM Customer").ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return null;
            }
        }
        public void DeleteById()
        {
            Console.WriteLine("Введите ID человека каторый вы хотели удалить его данны!!!");
            Console.Write("ID: "); int ID = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(path))
                {
                    var command = $"DELETE FROM Clients WHERE Id ={ID}";
                    db.Execute(command, new { ID });
                    Console.WriteLine("Успешно удален!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
       
    }
}
