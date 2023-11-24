using Dapper;
using Microsoft.EntityFrameworkCore;
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

        private readonly DatabaseConext _dbContext;

        public BoardRepository(DatabaseConext dbContext)
        {
            _dbContext = dbContext;
        }
        
        private readonly string _connectionString;

/*        public BoardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new OracleConnection(_connectionString);*/

        

        public async Task<IEnumerable<Board123>> GetAllAsync()
        {
            Console.WriteLine("GetAllAsync");

            try
            {
                var result = await _dbContext.Board123s.ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetAllAsync: {ex}");
                throw;
            }

            
        }

        public async Task<Board123> GetBoardAsync(int id)
        {
            try
            {
                return await _dbContext.Board123s.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetBoardAsync: {ex}");
                throw;
            }
        }

        public async Task<bool> AddBoardAsync(Board123 board)
        {
            _dbContext.Board123s.Add(board);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBoardAsync(int id)
        {
            var board = await _dbContext.Board123s.FindAsync(id);
            if (board == null)
                return false;

            _dbContext.Board123s.Remove(board);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBoardAsync(Board123 board)
        {
            _dbContext.Entry(board).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateReadCountAsync(int id)
        {
            var board = await _dbContext.Board123s.FindAsync(id);

            if (board != null)
            {
                board.ReadCount += 1;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

    }
}
