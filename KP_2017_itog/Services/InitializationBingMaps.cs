using BingMapsSDSToolkit.GeocodeDataflowAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KP_2017_itog.Services
{
    public class InitializationBingMaps
    {
        public static async Task<BatchGeocoderResults> InitializeBingMap()
        {
            var bingMapsKey = "AuFfksssSZ6g0kxOTVSlouU3CnPwnvku1ZDUdBFVX-Xpdm967HxuGsKkyfzAV1U2";

            var geocodeFeed = new GeocodeFeed()
            {
                Entities = new List<GeocodeEntity>()
                {
                    new GeocodeEntity("New York, NY"),
                    new GeocodeEntity("Seattle, WA")
                }
            };

            var geocodeManager = new BatchGeocodeManager();
            var r = await geocodeManager.Geocode(geocodeFeed, bingMapsKey);
            return r;
        }
    }
}