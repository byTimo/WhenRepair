using System.Threading.Tasks;
using System.Web.Mvc;
using WhenRepair.Application;

namespace Webmap.Controllers
{
    public class AddressController: Controller
    {
        private static readonly Geocoder geocoder = new Geocoder();
        
        [HttpGet]
        public async Task<ActionResult> Get(string latitude, string longitude)
        {
            var address = await geocoder.Get(new GeoCoordinate {Latitude = latitude, Longitude = longitude});

            return Json(address, JsonRequestBehavior.AllowGet);
        }
    }
}