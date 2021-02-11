using System;
using System.Collections.Generic;
using System.Linq;
using backend_labo01_wijn.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_labo01_wijn.Controllers
{
    [ApiController]
    [Route("api")]
    public class WineController : ControllerBase
    {
        private static List<Wine> _wines;


        public WineController()
        {
            if(_wines == null){
                _wines = new List<Wine>();
                _wines.Add(new Wine(){
                    WineId = 1, Name = "Barolo", Country = "Italië", Price = 35, Color = "Red", Year = 2007, Grapes = "Nebiollo"
                });
                _wines.Add(new Wine(){
                    WineId = 2, Name = "Riesling", Country = "Duitsland", Price = 19, Color = "White", Year = 2008, Grapes = "Riesling"
                });
            }
        }

        [HttpGet]
        [Route("wines")]
        public ActionResult<List<Wine>> GetWines(){
            return new OkObjectResult(_wines);
        }

        [HttpGet]
        [Route("wine/{wineId}")]
        public ActionResult<Wine> getWine(int wineId){
            var wine =  _wines.Where(w => w.WineId == wineId).SingleOrDefault();
            if(wine == null)
            {
                return new NotFoundObjectResult(wineId);
            }
            else
            {
                return wine;
            }            
        }

        [HttpPost]
        [Route("wine")]
        public ActionResult<Wine> AddWine(Wine wine){
            if (wine == null)
                return new BadRequestResult();

            wine.WineId = _wines.Count + 1;
            _wines.Add(wine);
            return new OkObjectResult(wine);

        }  
        
        [HttpDelete]
        [Route("wine/{wineId}")]
        public ActionResult<Wine> DeleteWine(int wineId){

            Wine wine = _wines.Find(wine => wine.WineId == wineId);

            if(wine != null)
            {
                _wines.Remove(wine);
                return new OkObjectResult(wine);
            }
            else
            {
                return new NotFoundResult();
            }
                

        }    

        [HttpPut] 
        [Route("wine")]
        public ActionResult<Wine> UpdateWine(Wine wine){
            Wine existingWine = _wines.Find(w => w.WineId == wine.WineId);
            if(existingWine != null){
                _wines.Remove(existingWine);
                _wines.Add(wine);
            }

            return new OkObjectResult(wine);
        }

    }
}
