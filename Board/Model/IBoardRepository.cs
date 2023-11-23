using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Model
{
    public interface IBoardRepository
    {
        // 전체 조회
        Task<IEnumerable<Board>> GetAllAsync();
        // id로 조회
        Task<Board> GetBoardAsync(int id);
        // 생성
        Task<bool> AddBoardAsync(Board board);
        // 업데이트
        Task<bool> UpdateBoardAsync(Board board);
        // 삭제
        Task<bool> DeleteBoardAsync(int id);
    }
}
