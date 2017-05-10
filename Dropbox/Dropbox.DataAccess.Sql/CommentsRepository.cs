using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;
using System.Data.SqlClient;

namespace Dropbox.DataAccess.Sql
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;
        private readonly IFilesRepository _filesRepository;

        public CommentsRepository(string connectionString, IUsersRepository userRepository, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _usersRepository = userRepository;
            _filesRepository = filesRepository;
        }

        public Comment Add(Comment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into comments (id, id_file, id_user) values (@id, @id_file, @id_user)";
                    var id = Guid.NewGuid();
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id_file", comment.FileId);
                    command.Parameters.AddWithValue("@id_user", comment.UserId);

                    command.ExecuteNonQuery();
                    comment.Id = id;
                    return comment;
                }
            }
        }

        public Comment GetInfo(Guid commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id, id_file, id_user from comments where id = @id";
                    command.Parameters.AddWithValue("@id", commentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Comment
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                FileId = reader.GetGuid(reader.GetOrdinal("id_file")),
                                UserId = reader.GetGuid(reader.GetOrdinal("id_user"))
                            };
                        }
                        throw new ArgumentException("comment not found");
                    }
                }
            }
        }

        public string GetText(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select comment from comments where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            return reader.GetSqlString(reader.GetOrdinal("comment")).Value;
                        throw new ArgumentException($"comment {id} not found");
                    }
                }
            }
        }

        public void UpdateText(Guid commentId, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "update comments set comment = @comment where id = @id";
                    command.Parameters.AddWithValue("@comment", text);
                    command.Parameters.AddWithValue("@id", commentId);
                    command.ExecuteNonQuery();
                }
            }

        }

        public IEnumerable<Comment> GetFileComments(Guid fileId)
        {
            var result = new List<Comment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id from comments where id_file = @fileid";
                    command.Parameters.AddWithValue("@fileid", fileId);
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
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from comments where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
