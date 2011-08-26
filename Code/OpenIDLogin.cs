using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace FullerHelpers
{
    public class OpenAuthHelper
    {

        public Exception Exception { get { return _Exception; } }
        private Exception _Exception { get; set; }

        public ActionResult ActionResult { get { return _ActionResult; } }
        private ActionResult _ActionResult { get; set; }

        public AuthenticationStatus? AuthStatus { get { return _AuthStatus; } }
        private AuthenticationStatus? _AuthStatus { get; set; }

        public string MyIdentifier { get { return _MyIdentifier; } }
        private string _MyIdentifier { get; set; }

        public HttpRequestBase Request { get { return _Request; } }
        private HttpRequestBase _Request { get; set; }

        public FetchRequest FetchRequest { get { return _FetchRequest; } }
        private FetchRequest _FetchRequest { get; set; }

        public Dictionary<int, string> FetchValues { get { return _FetchValues; } }
        private Dictionary<int, string> _FetchValues { get; set; }

        public void Login()
        {
            var ErrorMessage = "";
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();
            if (response == null)  // Initial operation
            {
                // Step 1 - Send the request to the OpenId provider server
                Identifier id;
                if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
                {
                    try
                    {
                        //Create Request
                        var req = openid.CreateRequest(Request.Form["openid_identifier"]);
                        
                        //Create request for email address
                        req.AddExtension(_FetchRequest);

                        _ActionResult = req.RedirectingResponse.AsActionResult();
                    }
                    catch (Exception ex)
                    {
                        // display error by showing original LogOn view
                        _Exception = ex;
                    }
                }
                else
                {
                    _Exception = new Exception("Invalid Identifier");
                }
            }
            else // OpenId redirection callback
            {
                // Step 2: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        _MyIdentifier = response.ClaimedIdentifier;

                        var fetch = response.GetExtension<FetchResponse>();
                        _FetchValues = new Dictionary<int, string>();

                        if (fetch != null)
                        {
                            int counter = 0;
                            foreach (var val in _FetchRequest.Attributes)
                            {
                                try
                                {
                                    _FetchValues.Add(counter, fetch.GetAttributeValue(val.TypeUri));

                                }
                                catch
                                {

                                }
                                counter++;
                            }
                        }
                        break;
                    case AuthenticationStatus.Canceled:
                        break;
                    case AuthenticationStatus.Failed:
                        break;
                }
                _AuthStatus = response.Status;
            }
        }

        public OpenAuthHelper(HttpRequestBase request, FetchRequest fetchRequest)
        {
            _Request = request;
            _FetchRequest = fetchRequest;
        }
    }
}
