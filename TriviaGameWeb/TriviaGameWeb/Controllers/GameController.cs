using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TriviaGameWeb.Models;

namespace TriviaGameWeb.Controllers
{
    public class GameController : Controller
    {
        public Question question = new Question();

        // GET: /<controller>/
        public IActionResult StartGame(int? Id)
        {
            if(HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 1);
                ViewBag.Count = HttpContext.Session.GetInt32("count").Value;
                question.GetQuestions(ViewBag.Count);
                return View(question);
            }
            var current = HttpContext.Session.GetInt32("count");
            HttpContext.Session.SetInt32("count", (int)(current + 1));
            ViewBag.Count = HttpContext.Session.GetInt32("count").Value;
            question.GetQuestions(ViewBag.Count);
            return View(question);
        }
    }
}

