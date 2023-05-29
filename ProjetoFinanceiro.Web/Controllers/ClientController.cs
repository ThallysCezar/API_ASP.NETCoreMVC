using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectFinance.Web.Models;
using System.Text;

namespace ProjectFinance.Web.Controllers
{
    public class ClientController : Controller
    {
        #region Propriedades

        private readonly string ENDPOINT = "";

        private readonly HttpClient httpClient = null;

        private readonly IConfiguration _configuration;

        #endregion Propriedades

        #region Construtores

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            ENDPOINT = _configuration["AppConfig:EndPoints:Url_Api"];

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        #endregion Construtores

        #region Actions

        public async Task<IActionResult> Index()
        {
            try
            {
                List<ClienteViewModel> clientes = null;

                HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(clientes);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ;
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

                string url = ENDPOINT;
                TempData["SuccessMessage"] = "Seller successfully created!";
                HttpResponseMessage response = await httpClient.PostAsync(url, byteArrayContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErroMessage"] = $"Oops! We could not create the Seller, please try again, error detail:  ERROR";
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

                string url = ENDPOINT;
                TempData["SuccessMessage"] = "Seller successfully edited!";
                HttpResponseMessage response = await httpClient.PutAsync(url, byteArrayContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErroMessage"] = $"Oops! We could not edit the Seller, please try again, error detail:  ERROR";
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
            string url = $"{ENDPOINT}{id}";
            TempData["SuccessMessage"] = "Seller successfully readed!";
            HttpResponseMessage response = await httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                TempData["ErroMessage"] = $"Oops! We could not read the Seller, please try again, error detail: ERROR";
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
                string url = $"{ENDPOINT}{id}";
                TempData["SuccessMessage"] = "Seller successfully updated!";
                HttpResponseMessage response = await httpClient.GetAsync(url);
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