using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using log4net;
using OwinSelfHostedWebAPI.Data;
using OwinSelfHostedWebAPI.Models;

namespace OwinSelfHostedWebAPI.Controllers
{
    [RoutePrefix("Items")]
    public class ItemsController : ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ItemsController));

        private static ItemsCache Items { get; } = new ItemsCache();
        
        [HttpGet]
        [Route("Get")]
        public List<Item> All()
        {
            return Items.GetAll();
        }

        [HttpPost]
        [Route("Add")]
        public Item Add(Item item)
        {
            if (item.Id == 0)
            {
                item.Id = Items.GetAll().Max(i => i.Id) + 1;
                _log.Info("Added item with ID of " + item.Id);
            }

            Items.Add(item);

            return item;
        }
    }
}
