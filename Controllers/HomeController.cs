using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            Dojodachi Retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");
            ViewBag.ShowDiv = false;

            if( Retrieve == null){
                Dojodachi Charmander = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("Charmander", Charmander);
            }

            Retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");

            if (Retrieve.Energy >= 100 && Retrieve.Fullness >= 100 && Retrieve.Happiness >= 100){
                HttpContext.Session.SetString("Message", "You are the best owner ever! Start over?");
                ViewBag.ShowDiv = true;
            }

            if (Retrieve.Fullness <= 0 || Retrieve.Happiness <= 0){
                HttpContext.Session.SetString("Message", "You LOSE!! Try again?");
                ViewBag.ShowDiv = true;
            }

            ViewBag.Charmander = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            return View();
        }
        [HttpGet("Restart")]
        public IActionResult Restart(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet("Feed")]
        public IActionResult Feed(){

            Dojodachi Charmander = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");

            if(Charmander.Meals <= 0){
                HttpContext.Session.SetString("Message", "You have no meals left!");
                return RedirectToAction("Index");
            }

            Random random = new Random();

            int fail = random.Next(0,4);
            Charmander.Meals -= 1;

            if(fail == 0){
                HttpContext.Session.SetString("Message", $"Your Charmander hated that meal!");
            }
            else{
                int fed = random.Next(5, 11);
                Charmander.Fullness += fed;
                HttpContext.Session.SetString("Message", $"You fed Charmander and he gained {fed} fullness!");
            }
            
            HttpContext.Session.SetObjectAsJson("Charmander", Charmander);

            return RedirectToAction("Index");

        }
        [HttpGet("Play")]
        public IActionResult Play(){

            Dojodachi Charmander = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");

            if(Charmander.Energy <= 0){
                HttpContext.Session.SetString("Message", "Charmander doesnt have enough energy to play!");
                return RedirectToAction("Index");
            }

            Charmander.Energy -= 5;
            Random random = new Random();
            int fail = random.Next(0,4);


            if (fail == 0)
            {
                HttpContext.Session.SetString("Message", $"Your Charmander didnt enjoy playing with you!");
            }
            else
            {
                int fed = random.Next(5, 11);
                Charmander.Happiness += fed;
                HttpContext.Session.SetString("Message", $"You played with Charmander and he gained {fed} happiness!");
            }



            HttpContext.Session.SetObjectAsJson("Charmander", Charmander);

            return RedirectToAction("Index");

        }
        [HttpGet("Work")]
        public IActionResult Work(){

            Dojodachi Charmander = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");

            if(Charmander.Energy <= 0){
                HttpContext.Session.SetString("Message", "Charmander is too tired to work!");
                return RedirectToAction("Index");
            }

            Charmander.Energy -= 5;
            Random random = new Random();
            int reward = random.Next(1,4);
            Charmander.Meals += reward;
            HttpContext.Session.SetString("Message", $"Charmander did hard work and gained {reward} meals");
    
            HttpContext.Session.SetObjectAsJson("Charmander", Charmander);

            return RedirectToAction("Index");

        }
        [HttpGet("Sleep")]
        public IActionResult Sleep(){

            Dojodachi Charmander = HttpContext.Session.GetObjectFromJson<Dojodachi>("Charmander");

            Charmander.Energy += 15;
            Charmander.Fullness -= 5;
            Charmander.Happiness -=5;

            HttpContext.Session.SetString("Message", $"Charmander Slept. Energy +15, Fullness -5, Happiness -5");
    
            HttpContext.Session.SetObjectAsJson("Charmander", Charmander);

            return RedirectToAction("Index");

        }


    }
}
