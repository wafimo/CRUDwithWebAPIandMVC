using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web;
using Client.Models;

namespace Client.Models
{
    public class StudentClient
    {
        private string baseURI = "http://localhost:56291/api/";


        public IEnumerable<Student> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("students").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Student find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("students/"+id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Student>().Result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool create(Student student)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("students",student).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool edit(Student student)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("students/"+student.Id,student).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("students/"+id).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}