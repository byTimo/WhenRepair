using System.Threading.Tasks;
using System.Web.Mvc;
using WhenRepair.Application;
using WhenRepair.Repository;

namespace Webmap.Controllers
{
    public class LayersController : Controller
    {
        private static readonly IAddressInfoRepository addressInfoRepository = null;

        public async Task<ActionResult> GetYears()
        {
            //var dictionary = await addressInfoRepository.GetYears();

            var years = new[]
            {
                "2011-2020",
                "2021-2040",
                "2041-2060",
            };

            return Json(years, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetLayer(string years)
        {
            var geoCoordinate = new[]
            {
                new GeoCoordinate()
                {
                    Latitude = "56.837500",
                    Longitude = "60.613203"

                },
                new GeoCoordinate()
                {
                    Latitude = "56.838219",
                    Longitude = "60.611162"
                },

                new GeoCoordinate()
                {
                    Latitude = "56.838694",
                    Longitude = "60.610303"
                },

                new GeoCoordinate()
                {
                    Latitude = "56.838503",
                    Longitude = "60.612221"
                },
            };

            return Json(geoCoordinate, JsonRequestBehavior.AllowGet);
        }
    }
}