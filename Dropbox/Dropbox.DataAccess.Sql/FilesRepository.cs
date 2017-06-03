using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess.Sql
{
    public class FilesRepository : IFilesRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;

        public FilesRepository(string connectionString, IUsersRepository usersRepository)
        {
            _connectionString = connectionString;
            _usersRepository = usersRepository;
        }

        public File Add(File file)
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
                            command.CommandText = "insert into files (id, name, owner) values (@id, @name, @owner)";
                            var fileId = Guid.NewGuid();
                            command.Parameters.AddWithValue("@id", fileId);
                            command.Parameters.AddWithValue("@name", file.Name);
                            command.Parameters.AddWithValue("@owner", file.Owner.Id);
                            command.ExecuteNonQuery();
                            file.Id = fileId;
                            return file;
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Не удалось добавить файл с именем {0}", file.Name);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
            }
        }

        public byte[] GetContent(Guid id)
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
                            command.CommandText = "select content from files where id = @id";
                            command.Parameters.AddWithValue("@id", id);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    return reader.GetSqlBinary(reader.GetOrdinal("content")).Value;
                                Log.Logger.ServiceLog.Error("Файл с id: {0} не найден", id);
                                throw new ArgumentException($"file {id} not found");
                            }
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при получении содержимого файла с id: {0}", id);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
            }
        }

        public File GetInfo(Guid fileId)
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
                            command.CommandText = "select id, name, owner from files where id = @id";
                            command.Parameters.AddWithValue("@id", fileId);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    return new File
                                    {
                                        Id = reader.GetGuid(reader.GetOrdinal("id")),
                                        Owner = _usersRepository.Get(reader.GetGuid(reader.GetOrdinal("owner"))),
                                        Name = reader.GetString(reader.GetOrdinal("name")).Trim()
                                    };
                                }
                                Log.Logger.ServiceLog.Error("Файл с id: {0} не найден", fileId);
                                throw new ArgumentException("file not found");
                            }
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при получении файла с id: {0}", fileId);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
            }
        }

        public void UpdateContent(Guid fileId, byte[] content)
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
                            command.CommandText = "update files set content = @content where id = @id";
                            command.Parameters.AddWithValue("@content", content);
                            command.Parameters.AddWithValue("@id", fileId);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при обновлении файла с id: {0}", fileId);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
            }
        }

        public IEnumerable<File> GetUserFiles(Guid id)
        {
            var result = new List<File>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "select id from files where owner = @userid";
                            command.Parameters.AddWithValue("@userid", id);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    result.Add(GetInfo(reader.GetGuid(reader.GetOrdinal("id"))));
                                }
                                return result;
                            }
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при поиске файлов пользователя с id: {0}", id);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
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
                            command.CommandText = "delete from files where id = @id";
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        Log.Logger.ServiceLog.Error("Ошибка при удалении файла с id: {0}", id);
                        throw;
                    }
                }
            }
            catch (SqlException)
            {
                Log.Logger.ServiceLog.Fatal("Не удалось подключиться к базе данных");
                throw;
            }
        }
    }
}
