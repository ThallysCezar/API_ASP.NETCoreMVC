using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectFinance.Web.Models;
using System.Net.Http;
using System.Text;

namespace ProjectFinance.Web.Controllers
{
    public class ClientController : Controller
    {
        #region Propriedades

        private readonly string _endpoint;

        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        #endregion Propriedades

        #region Construtores

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _endpoint = _configuration["AppConfig:_endpoints:Url_Api"];

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_endpoint)
            };
        }

        #endregion Construtores

        #region Actions

        public async Task<IActionResult> Index()
        {
            try
            {
                List<ClienteViewModel> clients = null;

                HttpResponseMessage response = await _httpClient.GetAsync(_endpoint);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clients = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Error processing request");
                }

                return View(clients);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ClienteViewModel result = await Search(id);
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Cpf")] ClienteViewModel client)
        {
            try
            {
                string json = JsonConvert.SerializeObject(client);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = _endpoint;
                TempData["SuccessMessage"] = "Client successfully created!";
                HttpResponseMessage response = await _httpClient.PostAsync(url, byteArrayContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Error processing request");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErroMessage"] = $"Oops! We could not create the Client, please try again, error detail:  ERROR";
                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            ClienteViewModel client = await Search(id);
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("ClientId, Name, Cpf")] ClienteViewModel client)
        {
            try
            {
                string json = JsonConvert.SerializeObject(client);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = _endpoint;
                TempData["SuccessMessage"] = "Client successfully edited!";
                HttpResponseMessage response = await _httpClient.PutAsync(url, byteArrayContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Error processing request");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErroMessage"] = $"Oops! We could not edit the Client, please try again!!";
                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            ClienteViewModel client = await Search(id);
            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string ClientId)
        {
            int id = Int32.Parse(ClientId);
            string url = $"{_endpoint}{id}";
            TempData["SuccessMessage"] = "Client successfully deleted!";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                TempData["ErroMessage"] = $"Oops! We could not delete the client, please try again!!";
                ModelState.AddModelError(null, "Erro ao processar a solicitação");
            }

            return RedirectToAction("Index");
        }

        #endregion Actions

        #region MétodosAuxiliares

        private async Task<ClienteViewModel> Search(int id)
        {
            try
            {
                ClienteViewModel result = null;
                string url = $"{_endpoint}{id}";
                TempData["SuccessMessage"] = "Seller successfully updated!";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClienteViewModel>(content);
                }

                return result;
            }
            catch (Exception)
            {
                TempData["ErroMessage"] = $"Oops! We could not update the Seller, please try again, error detail: ERROR";
                throw;
            }
        }

        #endregion MétodosAuxiliares
    }
}