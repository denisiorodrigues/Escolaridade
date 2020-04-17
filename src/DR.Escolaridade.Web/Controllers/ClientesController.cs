﻿using DR.Escolaridade.Application.Interfaces;
using DR.Escolaridade.Application.ViewModels;
using DR.Escolaridade.Infra.CrossCutting.Filters;
using System;
using DomainValidation.Validation;
using System.Web.Mvc;

namespace DR.Escolaridade.Web.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : BaseController
    {
        // LI,DE,IN,ED,EX
        //LI -> Listar
        //DE -> Detalhar
        //IN -> Incluir
        //ED -> Editar
        //EX -> Excluir

        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [ClaimsAuthorize("Cliente","LI")]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        //Os dois pontos é passando um DataType, serve para proteção da aplicação
        [ClaimsAuthorize("Cliente","DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente","IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Cliente","IN")]
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            clienteEndereco = _clienteAppService.Adicionar(clienteEndereco);
            if (clienteEndereco.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(clienteEndereco.Cliente.ValidationResult);

            return View(clienteEndereco);
        }

        [ClaimsAuthorize("Cliente","ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente","ED")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Cliente", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "EX")]
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
