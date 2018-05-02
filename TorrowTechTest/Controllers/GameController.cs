using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TorrowTechTest.Models;
using TorrowTechTest.GameCore;


namespace TorrowTechTest.Controllers
{
    
    public class GameController : Controller
    {
        private GameContext db;
        public GameController(GameContext context)
        {
            db = context;
        }

        //Request that creates a new game using the id received from the client
        [Route("api/game/newgame")]
        [HttpPost]
        public ActionResult NewGame([FromBody]Guid id)
        {
            if(id == Guid.Empty || db.GameStates.Any(x => x.Id == id))
            {
                Response.StatusCode = 400;
                return Content("Game with this Id has already started");
            }
            var field = Field.GetNewField();
            db.GameStates.Add(new GameState { Id = id, GameField = field });
            db.SaveChanges();
            return Json(field);
        }
        
        //Request that makes a turn in the game 
        [Route("api/game/turn")]
        [HttpPost]
        public ActionResult Turn([FromBody] TurnInfo turn)
        {
            var game = db.GameStates.SingleOrDefault(g => g.Id == turn.Id);
            if(game == null)
            {
                Response.StatusCode = 404;
                return Content("Game doesn't exist");
            }
            var field = new Field(game.GameField);
            if (field.Turn(turn.X, turn.Y))
            {
                game.GameField = field.ToString();
                db.GameStates.Update(game);
                db.SaveChanges();                
            }
            return Json(game.GameField);
        }

        // Additional class for turn request
        public class TurnInfo
        {
            public Guid Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
