using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess.Sql
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Add(string name, string email)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "insert into Users (Id, Name, Email) values (@id, @name, @email)";
                            var userId = Guid.NewGuid();
                            command.Parameters.AddWithValue("@id", userId);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.ExecuteNonQuery();
                            return new User()
                            {
                                Id = userId,
                                Name = name,
                                Email = email
                            };
                        }
                    }
                    catch (SqlException)
                    {
                        Log.Logger.ServiceLog.Error("Не удалось добавить пользователя с именем {0}", name);
                        throw new Exception("Coudn't add new user");
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw new Exception("Can't connect to SQL server");
            }

        }

        public void Delete(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "delete from Users where id = @id";
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException)
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при удалении пользователя с id: {0}", id);
                        throw new Exception($"Coudn't delete user with id: {id}");
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw new Exception("Can't connect to SQL server");
            }

        }

        public User Get(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "select Id, Name, Email from Users where id = @id;";
                        command.Parameters.AddWithValue("@id", id);
                        try
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return new User
                                    {
                                        Id = reader.GetGuid(reader.GetOrdinal("id")),
                                        Email = reader.GetString(reader.GetOrdinal("email")),
                                        Name = reader.GetString(reader.GetOrdinal("name"))
                                    };
                                }
                                Log.Logger.ServiceLog.Error("Пользователь с id: {0} не найден", id);
                                throw new ArgumentException("user not found");
                            }
                        }
                        catch
                        {
                            Log.Logger.ServiceLog.Error("Ошибка при поиске пользователя с id: {0}", id);
                            throw new Exception();
                        }
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw new Exception("Can't connect to SQL server");
            }
        }

        public User GetByMail(string email)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "select Id, Name, Email from Users where Email = @email;";
                        command.Parameters.AddWithValue("@email", email);
                        try
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return new User
                                    {
                                        Id = reader.GetGuid(reader.GetOrdinal("id")),
                                        Email = reader.GetString(reader.GetOrdinal("email")),
                                        Name = reader.GetString(reader.GetOrdinal("name"))
                                    };
                                }
                                Log.Logger.ServiceLog.Error("Пользователь с адресом: {0} не найден", email);
                                throw new ArgumentException("user not found");
                            }
                        }
                        catch
                        {
                            Log.Logger.ServiceLog.Error("Ошибка при поиске пользователя с адресом: {0}", email);
                            throw new Exception();
                        }
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw new Exception("Can't connect to SQL server");
            }
        }
    }
}
