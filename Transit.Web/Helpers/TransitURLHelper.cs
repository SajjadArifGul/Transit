using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transit.Web.Helpers
{
    public static class TransitURLHelper
    {
        public static string AboutUSURL = "about-us/";
        public static string VehicleTypesURL = "admin/vehicle-types";

        //public static JsonResult VehicleTypes(this UrlHelper helper)
        //{
        //    return helper.Content(Transit.Services.TransitService.Instance.GetTransitURLByName("VEHICLETYPES").Value).ToLower();
        //}
    }

    //public static class CPURLHelper
    //{
    //    public static string StyleSheet(this UrlHelper helper, string fileName)
    //    {
    //        return helper.Content(string.Format("~/content/{0}", fileName)).ToLower();
    //    }

    //    public static string Image(this UrlHelper helper, string imageName)
    //    {
    //        return helper.Content(string.Format("~/content/images/{0}", imageName)).ToLower();
    //    }

    //    public static string Script(this UrlHelper helper, string scriptFileName)
    //    {
    //        return helper.Content(string.Format("~/scripts/{0}", scriptFileName)).ToLower();
    //    }

    //    public static string ActiveMenuItem(this UrlHelper helper, string controllerName)
    //    {
    //        string controller = helper.RequestContext.RouteData.Values["controller"].ToString();
    //        if (controller.ToLower() == controllerName.ToLower())
    //        {
    //            return "active";
    //        }
    //        return "";
    //    }

    //    public static string ActiveMenuItem(this UrlHelper helper, string controllerName, string controllerName2)
    //    {
    //        string controller = helper.RequestContext.RouteData.Values["controller"].ToString();
    //        if (controller.ToLower() == controllerName.ToLower() || controller.ToLower() == controllerName2.ToLower())
    //        {
    //            return "active";
    //        }
    //        return "";
    //    }

    //    private static Dictionary<string, string> bitlies = new Dictionary<string, string>();

    //    static string lastBitlyAccountUsed = "";
    //    public static string GetBitlyURL(string originalURL)
    //    {
    //        if (bitlies.Count == 0)
    //        {
    //            string[] logins = (GlobalAppConfigs.BitlyLogin).Split(',');
    //            string[] keys = (GlobalAppConfigs.BitlyAPIKey).Split(',');
    //            if (logins != null && logins.Count() != 0)
    //            {
    //                for (int a = 0; a < logins.Count(); a++)
    //                {
    //                    bitlies.Add(logins[a], keys[a]);
    //                }
    //            }
    //            else
    //            {
    //                bitlies.Add(GlobalAppConfigs.BitlyLogin, GlobalAppConfigs.BitlyAPIKey);
    //            }
    //        }
    //        string shortURL = string.Empty;

    //        WebResponse response = null;
    //        StreamReader reader = null;

    //        try
    //        {
    //            string useBitly = bitlies.Keys.Where(x => !lastBitlyAccountUsed.Split("|".ToCharArray()).Contains(x)).FirstOrDefault();
    //            if (string.IsNullOrEmpty(useBitly))
    //            {
    //                useBitly = bitlies.Keys.FirstOrDefault();
    //                lastBitlyAccountUsed = "";
    //            }
    //            else
    //            {
    //                lastBitlyAccountUsed = lastBitlyAccountUsed + "|";
    //            }
    //            string bitlyLogin = useBitly;
    //            string bitlyAPIKey = bitlies[useBitly];
    //            lastBitlyAccountUsed = lastBitlyAccountUsed + useBitly;

    //            string url = string.Format("https://api-ssl.bitly.com/v3/shorten?login={0}&apiKey={1}&longUrl={2}&format=txt", bitlyLogin, bitlyAPIKey,
    //            originalURL);

    //            WebRequest request = WebRequest.Create(url);
    //            response = request.GetResponse();
    //            reader = new StreamReader(response.GetResponseStream());
    //            shortURL = reader.ReadToEnd();
    //        }
    //        catch (Exception ex)
    //        {
    //            shortURL = originalURL;
    //        }
    //        finally
    //        {
    //            if (response != null)
    //            {
    //                response.Close();
    //            }

    //            if (reader != null)
    //            {
    //                reader.Close();
    //            }
    //        }

    //        return shortURL.Trim();
    //    }
    //}
}