using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrowTechTest.Models;
using System.Net.Http;
using System.Net;
using TorrowTechTest.GameCore;
using Microsoft.EntityFrameworkCore;

namespace TorrowTechTest.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private GameContext db;
        public GameController(GameContext context)
        {
            db = context;
        }
        //Запрос, создающий новую игру по Guid
        // POST api/game/id
        [HttpPost("{id}")]
        public ActionResult Post(Guid id)
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
        //Запрос, совершающий ход в игре. Игра определяется по Guid
        // POST api/game
        //TO DO: BODY
        [HttpPost("{id}/{x}/{y}")]
        public ActionResult Post(Guid id, int x, int y)
        {
            var game = db.GameStates.SingleOrDefault(g => g.Id == id);
            if(game == null)
            {
                Response.StatusCode = 404;
                return Content("Game doesn't exist");
            }
            var field = new Field(game.GameField);
            if (field.Turn(x, y))
            {
                game.GameField = field.ToString();
                db.GameStates.Update(game);
                db.SaveChanges();
                
            }
            return Json(game.GameField);
        }        
    }
}
