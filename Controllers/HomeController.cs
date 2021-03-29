using BC_IS413_Assignment10.Models;
using BC_IS413_Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }
        private int pageSize = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext Context)
        {
            _logger = logger;
            context = Context;
            //Using context approach, not repository
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 1)
        {
            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                .Where(x => x.TeamId == teamid || teamid == null)
                .OrderBy(x => x.BowlerFirstName) //Order by first name, not specified in instructions
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)), //no need to convert to list, it's redundant

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If no team has been selected, then get full count. Otherwise, only count the number from the selected team
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : 
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                Team = teamname //Stores the team name of the selected, brought in from the View Component of the Team Selector
            });  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
