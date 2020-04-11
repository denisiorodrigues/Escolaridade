using DR.Escolaridade.Application.Interfaces;
using DR.Escolaridade.Application.Services;
using DR.Escolaridade.Application.ViewModels;
using System;
using System.Web.Mvc;

namespace DR.Escolaridade.Web.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : Controller
    {
        private IClienteAppService _clienteAppService;
        private const string role = "Admin";

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();   
        }

        [AllowAnonymous]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }
        //Os dois pontos é passando um DataType, serve para proteção da aplicação
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            _clienteAppService.Adicionar(clienteEndereco);

           return RedirectToAction("Index");
        }

        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);

            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Admin,Gestor")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [Authorize(Roles = role)]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected void Dispose()
        {
            _clienteAppService.Dispose();
        }
    }
}
