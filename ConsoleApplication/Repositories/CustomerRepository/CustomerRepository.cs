using Dapper;
using ConsoleApplication.Models;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApplication.Repositories.CustomerRepository
{
    class CustomerRepository:RepositoryBase<Customer>
    {
        public CustomerRepository():base()
        {

        }
        public void Create()
        {
            Customer client = new Customer();
            Console.Write("Имя: "); client.FirstName = Console.ReadLine();
            Console.Write("Фамилия: "); client.LastName = Console.ReadLine();
            Console.Write("Оттчество: "); client.MiddleName = Console.ReadLine();
            Console.Write("Дата рождения: "); 
            client.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(path))
                {
                    var command = $"INSERT INTO Customer([FirstName],[LastName],[MiddleName],[DateOfBirth]) VALUES('{client.FirstName}','{client.LastName}','{client.MiddleName}',{client.DateOfBirth}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    db.Query<int>(command, client);
                    Console.WriteLine("Успешно добавлен!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Select()
        {
            foreach (var item in SelectAll())
            {
                Console.WriteLine($"Id: {item.Id} |  FirstName: {item.FirstName}|  LastName: {item.LastName} |  MiddleName: {item.MiddleName} |  DateOfBirth: {item.DateOfBirth}");
            }
        }
        public void Update()
        {
            Select();
            Console.WriteLine("Введите ID человека каторый вы хотели изменит его данны!!!");
            Console.Write("ID: ");
            int ID = int.Parse(Console.ReadLine()); Console.Clear();
            Customer client = new Customer();
            Console.Write("Имя: "); client.FirstName = Console.ReadLine();
            Console.Write("Фамилия: "); client.LastName = Console.ReadLine();
            Console.Write("Оттчество: "); client.MiddleName = Console.ReadLine();
            Console.Write("Дата рождения: "); client.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(path))
                {
                    var command = $"UPDATE Customer SET FirstName = '{client.FirstName}', LastName ='{client.LastName}', MiddleName = '{client.MiddleName}',BirthDate ={client.DateOfBirth} WHERE Id = {ID}";
                    db.Execute(command, client);
                    Console.WriteLine("Успешно изменено!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Delete()
        {
            Select();
            DeleteById();
        }
    }
}
