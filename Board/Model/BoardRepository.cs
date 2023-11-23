using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Board.Model
{
    public class BoardRepository : IBoardRepository
    {
        // 코드 구현 (데이터베이스 연결 및 CRUD 작업)
        private readonly string _connectionString;

        public BoardRepository(string connectionString)
        {
            _connectionString = connectionString;
            //SqlConnection connection = new SqlConnection(connectionString);
        }

        private IDbConnection Connection => new OracleConnection(_connectionString);

        

        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            Console.WriteLine("GetAllAsync");

            try
            {
                using (var connection = Connection)
                {
                    const string query = "SELECT * FROM Board";
                    Console.WriteLine("Executing query: " + query);

                    var result = await connection.QueryAsync<Board>(query);
                    

                    foreach (var board in result)
                    {
                        Console.WriteLine($"Board Id: {board.Id}, Title: {board.Subject}, Content: {board.RegDate}");
                    }
                    return result;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetAllAsync: {ex}");
                throw;
            }

            
        }

        public async Task<Board> GetBoardAsync(int id)
        {
            try
            {
                using (var connection = Connection)
                {
                    const string query = "SELECT * FROM Board WHERE Id = :Id";
                    Console.WriteLine("Executing query: " + query); 
                    return await connection.QuerySingleAsync<Board>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetBoardAsync: {ex}");
                throw;
            }
        }

        public async Task<bool> AddBoardAsync(Board board)
        {
            using (var connection = Connection)
            {
                const string query = "INSERT INTO Board (SUBJECT, WRITER, REG_DATE,READ_COUNT,CONTENT,GROUP_NO,PRINT_NO,PRINT_LEVEL) " +
                                " VALUES (:Subject, :Writer, :RegDate, 0, :Content, 0, 0, 0)";
                return await connection.ExecuteAsync(query, board) > 0;
            }
        }

        public async Task<bool> DeleteBoardAsync(int id)
        {
            using (var connection = Connection)
            {
                const string query = "DELETE FROM Board WHERE Id = :Id";
                return await connection.ExecuteAsync(query, new { Id = id }) > 0;
            }
        }

        public async Task<bool> UpdateBoardAsync(Board board)
        {
            using (var connection = Connection)
            {
                const string query = "UPDATE Board SET SUBJECT = :Subject, WRITER = :Writer, CONTENT = :Content WHERE ID = :Id";
                return await connection.ExecuteAsync(query, board) > 0;
            }
        }
    }
}
