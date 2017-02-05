using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using WebClient.Models;

namespace WebClient.Modules
{
    public class RequestWriterModule : IHttpModule
    {
        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var Request = HttpContext.Current.Request;
            var UserAgent = Request.ServerVariables["HTTP_USER_AGENT"];

            var Track = new RecordedRequest();
            Track.Refferer = Request.UrlReferrer == null ? null : Request.UrlReferrer.ToString();
            Track.Url = Request.Url.ToString();
            Track.Device = (UserAgent.Contains("iPhone") || UserAgent.Contains("Windows Phone") || UserAgent.Contains("Android")) ? "Mobile" : "Desktop";
            Track.Browser = UserAgent;
            Track.Ip = GetIp();
            Track.User = userName();

            Track.Create();
        }

        string userName()
        {
            try
            {
                var request = HttpContext.Current.Request;
                var authHeader = request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                    // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                    if (authHeaderVal.Scheme.Equals("basic",
                            StringComparison.OrdinalIgnoreCase) &&
                        authHeaderVal.Parameter != null)
                    {
                        var encoding = Encoding.GetEncoding("iso-8859-1");
                        var credentials = encoding.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

                        int separator = credentials.IndexOf(':');
                        return credentials.Substring(0, separator);
                    }
                }

            }
            catch
            {
                return null;
            }
            return null;
        }

        string GetIp()
        {
            var Request = System.Web.HttpContext.Current.Request;
            string Ip = string.Empty;
            string ForwardIp = Request.ServerVariables["X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ForwardIp))
                Ip = Request.UserHostAddress;
            else if (ForwardIp.IndexOf(",") > -1)
                Ip = ForwardIp;
            else
                Ip = ForwardIp;
            return Ip;
        }
    }
}