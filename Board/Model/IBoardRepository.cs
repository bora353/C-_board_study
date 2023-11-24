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
        Task<IEnumerable<Board123>> GetAllAsync();
        // id로 조회
        Task<Board123> GetBoardAsync(int id);
        // 생성
        Task<bool> AddBoardAsync(Board123 board);
        // 업데이트
        Task<bool> UpdateBoardAsync(Board123 board);
        // 삭제
        Task<bool> DeleteBoardAsync(int id);
        // 조회수 증가
        Task<bool> UpdateReadCountAsync(int id);

    }
}
