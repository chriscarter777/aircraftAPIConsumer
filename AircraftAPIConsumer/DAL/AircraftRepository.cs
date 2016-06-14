using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AircraftAPIConsumer.Models;
using AircraftAPIConsumer.DAL;
using System.Net.Http;
using Newtonsoft.Json;

namespace AircraftAPIConsumer.DAL
{
    public class AircraftRepository : IAircraftRepository
    {

        private string APIaddress;

        public AircraftRepository()
        {
            this.APIaddress = "http://localhost:59757/api/aircraft";
        }

        public IEnumerable<Aircraft> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(APIaddress).Result;
                IEnumerable<Aircraft> aircraft = JsonConvert.DeserializeObject<IEnumerable<Aircraft>>(response.Content.ReadAsStringAsync().Result);
                return aircraft;
            }
        }

        public Aircraft Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(APIaddress + "/" + id).Result;
                Aircraft aircraft = JsonConvert.DeserializeObject<Aircraft>(response.Content.ReadAsStringAsync().Result);
                return aircraft;
            }
        }

        public void Add(Aircraft plane)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                string serializedPlane = JsonConvert.SerializeObject(plane);
                StringContent requestContent = new StringContent(serializedPlane);
                HttpResponseMessage response = client.PostAsync(APIaddress, requestContent).Result;
            }
        }

        public void Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(APIaddress + "/" + id).Result;
            }
        }

        public void Change(Aircraft plane)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                string serializedPlane = JsonConvert.SerializeObject(plane);
                StringContent requestContent = new StringContent(serializedPlane);
                HttpResponseMessage response = client.PutAsync(APIaddress, requestContent).Result;
            }
        }
    }
}