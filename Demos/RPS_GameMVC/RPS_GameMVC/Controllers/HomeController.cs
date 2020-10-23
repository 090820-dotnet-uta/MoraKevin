using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RPS_Game_Refactored;
using RPS_GameMVC.Models;

namespace RPS_GameMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;
        List<Player> players;
        List<Round> rounds;
        List<Game> games;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;

            if (!_cache.TryGetValue("players", out players))
            {
                _cache.Set("players", new List<Player>());
                _cache.TryGetValue("players", out players);
                _cache.TryGetValue("games", out games);
                _cache.TryGetValue("rounds", out rounds);
            }
        }

        public IActionResult SaveChanges()
        {
            _cache.Set("players", players);
            _cache.Set("rounds", rounds);
            _cache.Set("games", games);

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string fname)
        {
            Player p1 = players.FirstOrDefault(p => p.Name == fname);

            if(p1 == null)
            {
                p1 = new Player 
                { 
                    Name = fname
                };
            }

            return RedirectToAction("AddPlayer", p1);
        }

        public IActionResult AddPlayer(Player player)
        {
            if(player.PlayerID == -1)
            {
                Player pHighID = players.OrderByDescending(p => p.PlayerID).FirstOrDefault();
                if(pHighID == null)
                {
                    player.PlayerID = 1;
                }
                else
                {
                    player.PlayerID = (pHighID.PlayerID + 1);
                }
                _cache.Set("loggedInPlayer", player);
                players.Add(player);
                SaveChanges();
            }

            return View(player);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EditPlayer(int id)
        {
            Player player = players.Where(x => x.PlayerID == id).FirstOrDefault();
            if(player == null)
            {
                ViewData["notFound"] = "That player was not found! Please choose another";
                return View("AddPlayer", player);
            }
            return View(player);
        }

        public IActionResult EditPlayer(Player editedPlayer)
        {

            Player player = players.Where(x => x.PlayerID == editedPlayer.PlayerID).FirstOrDefault();
            if (player == null)
            {
                ViewData["notFound"] = "That player was not found! Please choose another";
                return View("PlayerList");
            }

            player.Name = editedPlayer.Name;
            player.Wins = editedPlayer.Wins;
            player.Losses = editedPlayer.Losses;

            //test is we can just say =
            //player = editedPlayer;
            SaveChanges();

            return RedirectToAction("PlayerList");
        }

        public IActionResult PlayerDetails(Player player)
        {
            throw new NotImplementedException("PlayerDetails not implemented yet");
        }

        //playersList action here
        public IActionResult PlayerList()
        {
            return View(players);
        }

        public IActionResult DeletePlayer(int id)
        {
            //check that the player being deleted is the player logged in.
            //log him out and redirect to login page. with a message
            Player lgp = (Player)_cache.Get("loggedInPlayer");
            if (id == lgp.PlayerID)
            {
                TempData["deletedMyself"] = "Looks like you deleted ourself. Please user a unique name to log in and create your account again.";
                return RedirectToAction("Logout", id);
            }
            players.Remove(players.Where(x => x.PlayerID == id).FirstOrDefault());
            SaveChanges();

            return View("PlayerList");
        }

        /// <summary>
        /// deletes the Logged In player from the cache
        /// and returns to the log in screen
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            _cache.Remove("loggedInPlayer");

            return View("Index");
        }
    }
}
