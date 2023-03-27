using Application.Models.DTOs;
using AppServices.Services.Interfaces;
using DomainServices.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CadastroPessoa.Controllers
{
    [Authorize]
    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService ?? throw new ArgumentNullException(nameof(pessoaAppService));
        }

        // GET: Pessoa
        public IActionResult Index()
        {
            return View(_pessoaAppService.MostraTodosCadastrados());
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(long id)
        {
            return View(await _pessoaAppService.BuscaPessoaPorId(id));
        }


        public async Task<IActionResult> GetByName(string nome)
        {
            try
            {
                return View(await _pessoaAppService.BuscaPessoaPeloNome(nome));
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
        }

        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                return View(await _pessoaAppService.BuscaPessoaPeloCpf(cpf));
            }
            catch (NotFoundException e)
            {
                return View("Error404", e);
            }
        }

        //GET: Pessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriaCadastro criaCadastro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pessoaId = await _pessoaAppService.CadastraPessoa(criaCadastro);
                }
                catch (BadRequestException e)
                {
                    return View("Error500", e);
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(criaCadastro);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
                try
                {
                    var pessoaParaAtualizar = await _pessoaAppService.MostraPessoaPorId(id);

                    return View(pessoaParaAtualizar);
                }
                catch (NotFoundException e)
                {
                    return View("Error404", e);
                }
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, AtualizaCadastro atualizaCadastro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pessoaAppService.AtualizCadastro(id, atualizaCadastro);
                }
                catch (BadRequestException e)
                {
                    return View("Error500", e);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(atualizaCadastro);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var pessoaParaExcluir = await _pessoaAppService.MostraPessoaPorId(id);

                return View(pessoaParaExcluir);
            }
            catch (BadRequestException e)
            {
                return View("Error404", e);
            }
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            try
            {
                _pessoaAppService.ExcluiPessoa(id);
            }
            catch (BadRequestException e)
            {
                return View("Error500", e);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
