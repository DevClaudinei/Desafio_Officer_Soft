using Application.Models.DTOs;
using AppServices.Services;
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
        public async Task<IActionResult> Index()
        {
            return View(await _pessoaAppService.MostraTodosCadastrados());
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(long id)
        {
            return View(await _pessoaAppService.BuscaPessoaPorId(id));
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
                    return BadRequest(e.Message);
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
                return NotFound(e.Message);
            }
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, AtualizaCadastro atualizaCadastro)
        {
            try
            {
                _pessoaAppService.AtualizCadastro(id, atualizaCadastro);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToAction(nameof(Index));
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
                return NotFound(e.Message);
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
                return BadRequest(e.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
