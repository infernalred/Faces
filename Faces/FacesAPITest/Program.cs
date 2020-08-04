using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FacesAPITest
{
    class Program
    {
        private static HttpClient Client = new HttpClient();
        static async Task Main(string[] args)
        {
            var imagePath = @"oscars-2017.jpg";
            var urlAddress = "http://localhost:6001/api/faces";
            ImageUtility imgUtil = new ImageUtility();
            var bytes = imgUtil.ConvertToBytes(imagePath);
            List<byte[]> faceList = null;
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            using (var response = await Client.PostAsync(urlAddress, byteContent))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                faceList = JsonConvert.DeserializeObject<List<byte[]>>(apiResponse);
            }
            if (faceList.Count > 0)
            {
                for (int i = 0; i < faceList.Count; i++)
                {
                    imgUtil.FromBytesToImage(faceList[i], $"face{i}.jpg");
                }
            }
        }
    }
}
