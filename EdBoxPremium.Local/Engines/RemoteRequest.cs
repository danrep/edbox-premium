using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EdBoxPremium.Data.InterchangeModels;

namespace EdBoxPremium.Local.Engines
{
    public class RemoteRequest
    {
        public static async Task<ResponseData> Get(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var entities = new LocalEntities();

                    client.BaseAddress =
                        new Uri(
                            entities.System_Setting.FirstOrDefault(
                                x => x.SettingKey == (int)Library.SettingKey.RemoteApi)?.SettingValue ?? "");

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(json);
                    }
                    else
                        return new ResponseData
                        {
                            Message = "Bad Response",
                            Status = false
                        };
                }
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
                return new ResponseData
                {
                    Message = e.Message,
                    Status = false
                };
            }
        }

        public static ResponseData Post(string url, string payload)
        {
            try
            {
                var entities = new LocalEntities();
                var request = (HttpWebRequest)WebRequest.Create((entities.System_Setting.FirstOrDefault(
                            x => x.SettingKey == (int)Library.SettingKey.RemoteApi)?.SettingValue ?? "") + url);

                request.Method = "POST";
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";

                var byteArray = Encoding.UTF8.GetBytes(payload);
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                var dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var response = request.GetResponse();
                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(responseFromServer);
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
                return new ResponseData
                {
                    Message = e.Message,
                    Status = false
                };
            }
        }
    }
}
