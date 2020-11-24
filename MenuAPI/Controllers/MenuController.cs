using MenuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MenuAPI.Controllers
{
    public class MenuController : ApiController
    {
        MongoDbHelper mongoDbHelper = new MongoDbHelper("MenuDb");

        /// <summary>
        /// Get all the dishes
        /// </summary>
        /// <returns>list of dishes</returns>      
        public IHttpActionResult Get()
        {
            List<Dish> documents = mongoDbHelper.ReadDocument<Dish>("Dishes");
            return Ok(documents);
        }

        /// <summary>
        /// Get a specific dish by id
        /// </summary>
        /// <param name="id">Id of the dish</param>
        /// <returns>A specific dish which matches the id</returns>
        public HttpResponseMessage Get(string id)
        {
            Dish document = mongoDbHelper.ReadDocumentById<Dish>("Dishes", id);
            if (document == null)
            {
                string message = string.Format("No Dish was found with Id : {0}", id);                
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, document);            
        }

        /// <summary>
        /// Add one dish to the database
        /// </summary>
        /// <param name="dish">A dish object</param>
        public IHttpActionResult Post([FromBody]Dish dish)
        {
            mongoDbHelper.InsertDocument("Dishes", dish);
            return Ok();
        }        
    }
}