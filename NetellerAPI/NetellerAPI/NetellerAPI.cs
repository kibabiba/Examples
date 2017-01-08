using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace NetellerApiClient
{
    public class NetellerApi
    {
    	string ClientId { get; set;}
    	string ClientSecret { get; set;}
    	string ApiBaseUrl { get; set;}

        NetellerApi()
        {
            NameValueCollection config = ConfigurationManager.GetSection("NetellerConfig") as NameValueCollection;
            if (config != null)
            {
                ClientId = config["clientId"];
                ClientSecret = config["clientSecret"];
                ApiBaseUrl = config["apiBaseUrl"];
            }
        }

        /// <summary>
        /// Gets the current public IP address of the client. This IP address needs to be whitelisted in your merchant account before you can make requests to the NETELLER REST API.
        /// The method uses a third party service to discover the IP address
        /// </summary>
        /// <returns>The public IP address of the REST API client</returns>
        public static string GetIp()
        {
            WebClient webclient = new WebClient();
            byte[] response = webclient.DownloadData("http://whatismyip.akamai.com");
            string sContents = Encoding.ASCII.GetString(response);
            return sContents;
        }

        /// <summary>
        /// Issues an HTTP GET request to the NETELLER API endpoint.
        /// </summary>
        /// <param name="path">The path to the NETELLER REST API resource. Example: "v1/orders".</param>
        /// <param name="queryParams">A list of query string parameters to be sent with the HTTP request.</param>
        /// <param name="headers">A list of headers to be set for the HTTP request.</param>
        /// <returns>A string containing the response of the NETELLER REST API.</returns>
        public string Get(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headers)
        {
            return MakeHttpRequest("GET", path, queryParams, headers, null);
        }

        /// <summary>
        /// Issues an HTTP POST request to the NETELLER API endpoint.
        /// </summary>
        /// <param name="path">The path to the NETELLER REST API resource. Example: "v1/orders".</param>
        /// <param name="queryParams">A list of query string parameters to be sent with the HTTP request.</param>
        /// <param name="headers">A list of headers to be set for the HTTP request.</param>
        /// <param name="requestParams">The JSON-formatted payload to be sent with the HTTP request.</param>
        /// <returns>A string containing the response of the NETELLER REST API.</returns>
        public string Post(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headers, string requestParams)
        {
            return MakeHttpRequest("POST", path, queryParams, headers, requestParams);
        }

        /// <summary>
        /// Issues an HTTP PUT request to the NETELLER API endpoint.
        /// </summary>
        /// <param name="path">The path to the NETELLER REST API resource. Example: "v1/orders".</param>
        /// <param name="queryParams">A list of query string parameters to be sent with the HTTP request.</param>
        /// <param name="headers">A list of headers to be set for the HTTP request.</param>
        /// <param name="requestParams">The JSON-formatted payload to be sent with the HTTP request.</param>
        /// <returns>A string containing the response of the NETELLER REST API.</returns>
        public string Put(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headers, string requestParams)
        {
            return MakeHttpRequest("PUT", path, queryParams, headers, requestParams);
        }

        /// <summary>
        /// Issues an HTTP DELETE request to the NETELLER API endpoint.
        /// </summary>
        /// <param name="path">The path to the NETELLER REST API resource. Example: "v1/orders".</param>
        /// <param name="queryParams">A list of query string parameters to be sent with the HTTP request.</param>
        /// <param name="headers">A list of headers to be set for the HTTP request.</param>
        /// <param name="requestParams">The JSON-formatted payload to be sent with the HTTP request.</param>
        /// <returns>A string containing the response of the NETELLER REST API.</returns>
        public string Delete(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headers, string requestParams)
        {
            return MakeHttpRequest("DELETE", path, queryParams, headers, requestParams);
        }

        /// <summary>
        /// Issues an HTTP request to the NETELLER API endpoint.
        /// </summary>
        /// <param name="method">The HTTP method to be used in the request.</param>
        /// <param name="path">The path to the NETELLER REST API resource. Example: "v1/orders".</param>
        /// <param name="queryParams">A list of query string parameters to be sent with the HTTP request.</param>
        /// <param name="headers">A list of headers to be set for the HTTP request.</param>
        /// <param name="requestParams">The JSON-formatted payload to be sent with the HTTP request.</param>
        /// <returns>A string containing the response of the NETELLER REST API.</returns>
        public string MakeHttpRequest(string method, string path, Dictionary<string, string> queryParams, Dictionary<string, string> headers, string requestParams)
        {
            string url = ApiBaseUrl + path;
            if (queryParams != null)
            {
                string query = queryParams.Aggregate("", (current, val) => current + (HttpUtility.UrlEncode(val.Key) + "=" + HttpUtility.UrlEncode(val.Value) + "&"));

                query = query.TrimEnd('&');

                url = url + "?" + query;
            }

            WebRequest request = WebRequest.Create(url);

            request.ContentType = "application/json";

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> val in headers)
                {
                    request.Headers.Set(val.Key, val.Value);
                }
            }

            request.Method = method;

            if (requestParams != null)
            {
                byte[] buf = Encoding.UTF8.GetBytes(requestParams);
                request.ContentLength = buf.Length;
                request.GetRequestStream().Write(buf, 0, buf.Length);
            }

            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();

                if (dataStream == null)
                {
                    throw new NullReferenceException();
                }

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return responseFromServer;
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse) e.Response;
                Stream dataStream = response.GetResponseStream();

                if (dataStream == null)
                {
                    throw new NullReferenceException();
                }

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                NetellerApiException netellerApiException = new NetellerApiException();

                if (path == "v1/oauth2/token")
                {
                    DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof(TokenError));
                    MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));

                    TokenError responseObject = (TokenError)responseSerializer.ReadObject(responseMemoryStream);

                    if (!String.IsNullOrEmpty(response.StatusCode.ToString()))
                    {
                        netellerApiException.ResponseHttpCode = (int)response.StatusCode;
                    }
                    if (!String.IsNullOrEmpty(responseObject.error))
                    {
                        netellerApiException.NetellerApiResponseMessage = responseObject.error;
                    }
                }
                else
                {
                    DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof(OtherError));
                    MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseFromServer));

                    OtherError responseObject = (OtherError)responseSerializer.ReadObject(responseMemoryStream);

                    if (!String.IsNullOrEmpty(response.StatusCode.ToString()))
                    {
                        netellerApiException.ResponseHttpCode = (int)response.StatusCode;
                    }
                    if (!String.IsNullOrEmpty(responseObject.error.code))
                    {
                        netellerApiException.NetellerApiResponseCode = responseObject.error.code;
                    }
                    if (!String.IsNullOrEmpty(responseObject.error.message))
                    {
                        netellerApiException.NetellerApiResponseMessage = responseObject.error.message;
                    }
                    if (responseObject.error.fieldErrors != null)
                    {
                        netellerApiException.NetellerApiFieldErrors = responseObject.error.fieldErrors;
                    }
                }

                throw netellerApiException;
            }
        }

        /// <summary>
        /// Makes a request to the NETELLER REST API to obtain a new access token using the Client ID and Client Secret from the config.
        /// </summary>
        /// <returns>Returns a new access token of type "client_credentials".</returns>
        public Token getToken_clientCredentials()
        {

            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"}
            };

            Byte[] plainTextCredentials = Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret);
            string base64EncodedCredentials = Convert.ToBase64String(plainTextCredentials);

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Basic " + base64EncodedCredentials}
            };

            const string path = "v1/oauth2/token";

            string response = Post(path, queryParams, headers, null);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (Token));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            Token responseObject = (Token) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Makes a request to the NETELLER REST API to exchange the authorization code for a new access token and refresh token. 
        /// </summary>
        /// <param name="authCode">The authorization code obtained from the authorization flow.</param>
        /// <param name="redirectUri">The redirect_uri used in the authorization flow. This value must match the uri used to obtain authorization, If not supplied during the authorization flow then the redirect_uri will be the registered redirect uri for your application (as set in the merchant.com portal under the APPS section) and should not be passed.</param>
        /// <returns>Returns a new access token of type "auth_code".</returns>
        public Token getToken_authCode(string authCode, string redirectUri = "")
        {
            NetellerApi api = new NetellerApi();

            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"code", authCode}
            };
            if (!String.IsNullOrEmpty(redirectUri))
            {
                queryParams.Add("redirect_uri", redirectUri);
            }

            Byte[] plainTextCredentials = Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret);
            string base64EncodedCredentials = Convert.ToBase64String(plainTextCredentials);

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Basic " + base64EncodedCredentials}
            };

            const string path = "v1/oauth2/token";

            string response = api.Post(path, queryParams, headers, null);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (Token));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            Token responseObject = (Token) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Makes a request to the NETELLER REST API to obtain a new access token from a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token received when you exchanged the auth code for an access token.</param>
        /// <returns>Returns a new access token of type "auth_code".</returns>
        public Token getToken_refreshToken(string refreshToken)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token"},
                {"refresh_token", refreshToken}
            };

            Byte[] plainTextCredentials = Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret);
            string base64EncodedCredentials = Convert.ToBase64String(plainTextCredentials);

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Basic " + base64EncodedCredentials}
            };

            const string path = "v1/oauth2/token";

            string response = Post(path, queryParams, headers, null);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (Token));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            Token responseObject = (Token) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Creates a new incoming payment.
        /// </summary>
        /// <param name="request">A "TransferInRequest" object containing the required data to be send to the API.</param>
        /// <returns>A "TransferInResponse" object, containing the response from the NETELLER REST API.</returns>
		/// <param name = "expand">Expands the specified resource. Possible values: "customer"</param>
        public static TransferInResponse TransferIn(TransferInRequest request, string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(expand))
            {
            	queryParams.Add("expand",expand);
            }
            
            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (TransferInRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            const string path = "v1/transferIn";

            string response = api.Post(path, queryParams, headers, requestJson);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (TransferInResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            TransferInResponse responseObject = (TransferInResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Creates a new outgoing payment.
        /// </summary>
        /// <param name="request">A "TransferOutRequest" object containing the required data to be send to the API.</param>
        /// <returns>A "TransferOutResponse" object, containing the response from the NETELLER REST API.</returns>
		/// <param name = "expand">Expands the specified resource. Possible values: "customer"</param>
        public static TransferOutResponse TransferOut(TransferOutRequest request, string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(expand))
            {
            	queryParams.Add("expand",expand);
            }
            
            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (TransferOutRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            const string path = "v1/transferOut";

            string response = api.Post(path, queryParams, headers, requestJson);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (TransferOutResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            TransferOutResponse responseObject = (TransferOutResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Looks up a payment by provided merchantRefId or transactionId. 
        /// </summary>
        /// <param name="merchantRefId">Your unique identifier for this transaction that was supplied on your original request.</param>
        /// <param name="transactionId">The unique identifier for the transaction.</param>
        /// <param name="expand">Expands the specified resource. Possible values: "customer"</param>
        /// <returns>A "LookupPaymentResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupPaymentResponse LookupPayment(string merchantRefId = "", string transactionId = "", string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string response = "";

            if (!String.IsNullOrEmpty(merchantRefId))
            {
                string path = "v1/payments/" + merchantRefId;

                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"refType", "merchantRefId"}
                };

                if (!String.IsNullOrEmpty(expand))
                {
                    queryParams.Add("expand", expand);
                }

                response = api.Get(path, queryParams, headers);
            }
            else if (!String.IsNullOrEmpty(transactionId))
            {
                string path = "v1/payments/" + transactionId;

                Dictionary<string, string> queryParams = new Dictionary<string, string>();

                if (!String.IsNullOrEmpty(expand))
                {
                    queryParams.Add("expand", expand);
                }

                response = api.Get(path, queryParams, headers);
            }

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupPaymentResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupPaymentResponse responseObject = (LookupPaymentResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Creates a payment order for NETELLERgo! You will need to redirect your customer to the returned URL to initiate the hosted Quick Checkout flow and collect the payment.
        /// </summary>
        /// <param name="request">A "CreateOrderRequest" object containing the required data to be send to the API.</param>
        /// <returns>A "CreateOrderResponse" object, containing the response from the NETELLER REST API.</returns>
        public static CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (CreateOrderRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            const string path = "v1/orders";

            string response = api.Post(path, null, headers, requestJson);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (CreateOrderResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CreateOrderResponse responseObject = (CreateOrderResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Look up details about a previous order request.
        /// </summary>
        /// <param name="orderId">The unique identifier for the order. (ie: ORD_7915d463-ccc8-4305-9d33-9e5c9310f12e)</param>
        /// <returns>A "LookupOrderResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupOrderResponse LookupOrder(string orderId)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/orders/" + orderId;

            string response = api.Get(path, null, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupOrderResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupOrderResponse responseObject = (LookupOrderResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Look up details about a payment invoice issued for an order.
        /// </summary>
        /// <param name="orderId">The unique identifier for the order. (ie: ORD_7915d463-ccc8-4305-9d33-9e5c9310f12e)</param>
        /// <returns>A "LookupOrderInvoiceResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupOrderInvoiceResponse LookupOrderInvoice(string orderId)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/orders/" + orderId + "/invoice";

            string response = api.Get(path, null, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupOrderInvoiceResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupOrderInvoiceResponse responseObject = (LookupOrderInvoiceResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Pre-populate the NETELLER sign-up page with information from your database, so you can speed up the registration process. 
        /// </summary>
        /// <param name="request">A "CreateCustomerRequest" object containing the required data to be send to the API.</param>
        /// <returns>A "CreateCustomerResponse" object, containing the response from the NETELLER REST API.</returns>
        public static CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (CreateCustomerRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            const string path = "vi/customers";

            string response = api.Post(path, null, headers, requestJson);

            DataContractJsonSerializer responseSerializer =
                new DataContractJsonSerializer(typeof (CreateCustomerResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CreateCustomerResponse responseObject = (CreateCustomerResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Lookup details for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier for the customer.</param>
        /// <param name="email">The customer's NETELLER registered Email</param>
        /// <param name="accountId">The customer's NETELLER Account ID.</param>
        /// <returns>A "LookupCustomerResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupCustomerResponse LookupCustomer(string customerId = "", string email = "",
            string accountId = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string response = "";

            if (!String.IsNullOrEmpty(customerId))
            {
                string path = "v1/customers/" + customerId;

                response = api.Get(path, null, headers);
            }
            else if (!String.IsNullOrEmpty(email))
            {
                const string path = "v1/customers";

                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"email", email}
                };

                response = api.Get(path, queryParams, headers);
            }
            else if (!String.IsNullOrEmpty(accountId))
            {
                const string path = "v1/customers";

                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"accountId", accountId}
                };

                response = api.Get(path, queryParams, headers);
            }

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupCustomerResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupCustomerResponse responseObject = (LookupCustomerResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Creates a subscription plan.
        /// </summary>
        /// <param name="request">A "CreatePlanRequest" object containing the required data to be send to the API.</param>
        /// <returns>A "CreatePlanResponse" object, containing the response from the NETELLER REST API.</returns>
        public static CreatePlanResponse CreatePlan(CreatePlanRequest request)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (CreatePlanRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            const string path = "vi/plans";

            string response = api.Post(path, null, headers, requestJson);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (CreatePlanResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CreatePlanResponse responseObject = (CreatePlanResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Returns details about a previously created subscription plan.
        /// </summary>
        /// <param name="planId">The unique identifier for the subscription plan.</param>
        /// <returns>A "LookupPlanResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupPlanResponse LookupPlan(string planId)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/plans/" + planId;

            string response = api.Get(path, null, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupPlanResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupPlanResponse responseObject = (LookupPlanResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Cancels a previously created subscription plan.
        /// </summary>
        /// <param name="planId">The unique identifier for the subscription plan.</param>
        /// <returns>A "CancelPlanResponse" object, containing the response from the NETELLER REST API.</returns>
        public static CancelPlanResponse CacelPlan(string planId)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/plans/" + planId + "/cancel";

            string response = api.Post(path, null, headers, null);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (CancelPlanResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CancelPlanResponse responseObject = (CancelPlanResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Deletes a previously created subscription plan.
        /// </summary>
        /// <param name="planId">The unique identifier for the subscription plan.</param>
        public static void DeletePlan(string planId)
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/plans/" + planId;

            api.Delete(path, null, headers, null);
        }

        /// <summary>
        /// Returns a list of all created plans.
        /// </summary>
        /// <returns>A "ListPlansResponse" object, containing the response from the NETELLER REST API.</returns>
        public static ListPlansResponse ListPlans()
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            const string path = "v1/plans";

            string response = api.Get(path, null, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (ListPlansResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            ListPlansResponse responseObject = (ListPlansResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Enrolls an existing NETELLER account holder in one of your subscription plans.
        /// </summary>
        /// <param name="request">A "CreateSubscriptionRequest" object containing the required data to be send to the API.</param>
        /// <param name="token">An access token of type "auth_code", authorized by the account holder.</param>
        /// <returns>A "CreateSubscriptionResponse" object, containing the response from the NETELLER REST API.</returns>
		/// <param name = "expand">Expands the specified resource. Possible values: "plan, customer"</param>
        public static CreateSubscriptionResponse CreateSubscription(CreateSubscriptionRequest request, string token, string expand = "")
        {
            NetellerApi api = new NetellerApi();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token}
            };
			
        	Dictionary<string, string> queryParams = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(expand))
            {
            	queryParams.Add("expand",expand);
            }    
            
            const string path = "v1/subscriptions";

            DataContractJsonSerializer requestSerializer = new DataContractJsonSerializer(typeof (CreateSubscriptionRequest));
            MemoryStream requestMemoryStream = new MemoryStream();

            requestSerializer.WriteObject(requestMemoryStream, request);
            string requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());

            string response = api.Post(path, queryParams, headers, requestJson);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (CreateSubscriptionResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CreateSubscriptionResponse responseObject = (CreateSubscriptionResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Returns details about a previously created subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier for the subscription.</param>
        /// <param name="expand">Expands the specified resource. Possible values: "plan, customer"</param>
        /// <returns>A "LookupSubscriptionResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupSubscriptionResponse LookupSubscription(string subscriptionId, string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/subscriptions/" + subscriptionId;

            string response;

            if (!String.IsNullOrEmpty(expand))
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"expand", expand}
                };

                response = api.Get(path, queryParams, headers);
            }
            else
            {
                response = api.Get(path, null, headers);
            }

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupSubscriptionResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupSubscriptionResponse responseObject = (LookupSubscriptionResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Cancels a previously created subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier for the subscription.</param>
        /// <param name="expand">Expands the specified resource. Possible values: "plan, customer"</param>
        /// <returns>A "CancelSubscriptionResponse" object, containing the response from the NETELLER REST API.</returns>
        public static CancelSubscriptionResponse CancelSubscription(string subscriptionId, string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/subscriptions/" + subscriptionId + "/cancel";

            string response;

            if (!String.IsNullOrEmpty(expand))
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"expand", expand}
                };

                response = api.Post(path, queryParams, headers, null);
            }
            else
            {
                response = api.Post(path, null, headers, null);
            }


            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (CancelSubscriptionResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            CancelSubscriptionResponse responseObject = (CancelSubscriptionResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Lists all previously created subscriptions.
        /// </summary>
        /// <param name="limit">Sets the number of records to be returned.</param>
        /// <param name="offset">Sets the results offset.</param>
        /// <returns>A "ListSubscriptionsResponse" object, containing the response from the NETELLER REST API.</returns>
        public static ListSubscriptionsResponse ListSubscriptions(string limit = "", string offset = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            const string path = "v1/subscriptions";

            Dictionary<string, string> queryParams = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(limit))
            {
                queryParams.Add("limit", limit);
            }
            if (!String.IsNullOrEmpty(offset))
            {
                queryParams.Add("offset", offset);
            }

            string response = api.Get(path, queryParams, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (ListSubscriptionsResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            ListSubscriptionsResponse responseObject = (ListSubscriptionsResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Looks up a subscription invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier for the subscription.</param>
        /// <param name="invoiceNumber">The nyumber of the invoice for this subscription.</param>
        /// <param name="expand">Expands the specified resource. Possible values: "subscription"</param>
        /// <returns>A "LookupSubscriptionInvoiceResponse" object, containing the response from the NETELLER REST API.</returns>
        public static LookupSubscriptionInvoiceResponse LookupSubscriptionInvoice(string subscriptionId, string invoiceNumber, string expand = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/subscriptions/" + subscriptionId + "/invoices/" + invoiceNumber;

            string response;

            if (!String.IsNullOrEmpty(expand))
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>
                {
                    {"expand", expand}
                };

                response = api.Get(path, queryParams, headers);
            }
            else
            {
                response = api.Get(path, null, headers);
            }

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (LookupSubscriptionInvoiceResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            LookupSubscriptionInvoiceResponse responseObject = (LookupSubscriptionInvoiceResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }

        /// <summary>
        /// Looks up all subscription invoices.
        /// </summary>
        /// <param name="subscriptionId">The unique identifier for the subscription.</param>
        /// <param name="limit">Sets the number of records to be returned.</param>
        /// <param name="offset">Sets the results offset.</param>
        /// <returns>A "ListSubscriptionInvoicesResponse" object, containing the response from the NETELLER REST API.</returns>
        public static ListSubscriptionInvoicesResponse ListSubscriptionInvoices(string subscriptionId, string limit = "", string offset = "")
        {
            NetellerApi api = new NetellerApi();
            Token token = api.getToken_clientCredentials();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + token.accessToken}
            };

            string path = "v1/subscriptions/" + subscriptionId + "/invoices";

            Dictionary<string, string> queryParams = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(limit))
            {
                queryParams.Add("limit", limit);
            }
            if (!String.IsNullOrEmpty(offset))
            {
                queryParams.Add("offset", offset);
            }

            string response = api.Get(path, queryParams, headers);

            DataContractJsonSerializer responseSerializer = new DataContractJsonSerializer(typeof (ListSubscriptionInvoicesResponse));
            MemoryStream responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response));

            ListSubscriptionInvoicesResponse responseObject = (ListSubscriptionInvoicesResponse) responseSerializer.ReadObject(responseMemoryStream);

            return responseObject;
        }
    }

    public class NetellerApiException : Exception
	{	
	    public int ResponseHttpCode { get; set; }
		public string NetellerApiResponseCode { get; set; }
	    public string NetellerApiResponseMessage { get; set; }
	    public List<FieldError> NetellerApiFieldErrors { get; set; }
	}
}