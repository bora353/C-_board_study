using Board.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace BoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly Board.Model.IBoardRepository _repository;

        public BoardController(IBoardRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<IEnumerable<Board.Model.Board>> Boards { get; set; }

        [HttpGet]
        public async Task<IEnumerable<Board.Model.Board>> GetAll()
        {
            return await _repository.GetAllAsync();

        }

        [HttpGet("{id}")]
        public async Task<Board.Model.Board> GetOneById(int id)
        {
            return await _repository.GetBoardAsync(id);
        }



        [HttpPost("create")]
        public async Task<ActionResult<Board.Model.Board>> AddBoard([FromBody] Board.Model.Board board  )
        {
            board.RegDate = DateTime.Now;
            await _repository.AddBoardAsync(board);

            return CreatedAtAction(nameof(GetOneById), new { id = board.Id }, board);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, [FromBody] Board.Model.Board board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            var updatedBoard = await _repository.UpdateBoardAsync(board);
            return Ok(updatedBoard);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var appointmentsType = await _repository.GetBoardAsync(id);
            if (appointmentsType == null)
            {
                return NotFound();
            }

            await _repository.DeleteBoardAsync(id);
            return NoContent();
        }

    }
}
