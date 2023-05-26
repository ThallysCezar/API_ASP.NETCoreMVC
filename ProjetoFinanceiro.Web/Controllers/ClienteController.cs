using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoFinanceiro.Web.Models;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        #region Propriedades

        private readonly string ENDPOINT = "";

        private readonly HttpClient httpClient = null;

        private readonly IConfiguration _configuration;

        #endregion

        #region Construtores
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
            ENDPOINT = _configuration["AppConfig:EndPoints:Url_Api"];

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        #endregion

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
                throw ex;
            }
        }

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ClienteViewModel result = await Pesquisar(id);
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
        public async Task<IActionResult> Create([Bind("Nome, Cpf")] ClienteViewModel cliente)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cliente);
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
            ClienteViewModel cliente = await Pesquisar(id);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("ClienteId, Nome, Cpf")] ClienteViewModel cliente)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cliente);
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
            ClienteViewModel cliente = await Pesquisar(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string ClienteId)
        {
            int id = Int32.Parse(ClienteId);
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
        #endregion

        #region MétodosAuxiliares
        private async Task<ClienteViewModel> Pesquisar(int id)
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


        #endregion
    }
}
