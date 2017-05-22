using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess.Sql
{
    public class SharesRepository : ISharesRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;
        private readonly IFilesRepository _filesRepository;

        public SharesRepository(string connectionString, IUsersRepository userRepository, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _usersRepository = userRepository;
            _filesRepository = filesRepository;
        }

        public void Add(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into sharingFiles (id_file, id_user) values (@id_file, @id_user)";
                    command.Parameters.AddWithValue("@id_file", share.FileId);
                    command.Parameters.AddWithValue("@id_user", share.UserId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<File> GetUserFiles(Guid userId)
        {
            var result = new List<File>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id_file from sharingFiles where id_user = @userid";
                    command.Parameters.AddWithValue("@userid", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(_filesRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("id_file"))));
                        }
                        return result;
                    }
                }
            }
        }

        public void Delete(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from sharingFiles where id_file = @id_file and id_user = @id_user";
                    command.Parameters.AddWithValue("@id_file", share.FileId);
                    command.Parameters.AddWithValue("@id_user", share.UserId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
