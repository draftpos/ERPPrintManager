using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{
    public class Zimra
    {
        public string ftoken;
        private string hcloud_baseurl = ERPPrintManager.Properties.Settings.Default.ServerAddress; // replace with your actual base URL

        public async Task<string> GetToken()
        {
            string apiUrl = $"{hcloud_baseurl}/api/method/havanozimracloud.api.token";
            Debug.WriteLine(apiUrl);
            string result = "";

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                var cookieContainer = new CookieContainer();
                cookieContainer.Add(new Uri(apiUrl), new Cookie("full_name", "Guest"));
                cookieContainer.Add(new Uri(apiUrl), new Cookie("sid", "Guest"));
                cookieContainer.Add(new Uri(apiUrl), new Cookie("system_user", "no"));
                cookieContainer.Add(new Uri(apiUrl), new Cookie("user_id", "Guest"));
                cookieContainer.Add(new Uri(apiUrl), new Cookie("user_image", ""));

                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = cookieContainer
                };

                using (var httpClient = new HttpClient(handler))
                {
                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);

                    result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(result);
                        var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                        if (data != null && data.ContainsKey("message"))
                        {
                            return data["message"];
                        }
                        else
                        {
                            return $"No 'message' key in response: {result}";
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public async Task<string> SendZimraRequest(string fiscal_ay)
        {
            Debug.WriteLine("Sending Request to HavanoZimra");
            string hcloud_devicesn = ERPPrintManager.Properties.Settings.Default.DeviceSerialNo; 
            string hcloud_key = ERPPrintManager.Properties.Settings.Default.API;      
            string hcloud_secret = ERPPrintManager.Properties.Settings.Default.Secret;   
            string  ftoken = await GetToken();              
            string url = "";
            string postData = "";
            string result = "";

            url = $"{hcloud_baseurl}/api/method/havanozimracloud.api.getzreport";
            postData = $"device_sn={hcloud_devicesn}&" +
            $"fiscal_day={fiscal_ay}";

            Debug.WriteLine(url);
            Debug.WriteLine(postData);

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers["X-Frappe-CSRF-Token"] = ftoken;
                request.Headers["Authorization"] = $"token {hcloud_key}:{hcloud_secret}";
                request.ContentType = "application/x-www-form-urlencoded";

                byte[] dataBytes = Encoding.UTF8.GetBytes(postData);

                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    await requestStream.WriteAsync(dataBytes, 0, dataBytes.Length);
                }

                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending Zimra request: {ex.Message}");
                return $"Failed: {ex.Message}";
            }
        }

    }
}
