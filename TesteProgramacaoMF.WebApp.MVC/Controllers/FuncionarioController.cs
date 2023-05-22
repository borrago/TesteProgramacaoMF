using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteProgramacaoMF.Profissionais.Application.Services.Cargo;
using TesteProgramacaoMF.Profissionais.Application.Services.Funcionario;
using TesteProgramacaoMF.Profissionais.Application.Services.FuncionarioObra;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.WebApp.MVC.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly ICargoAppService _cargoAppService;

        public FuncionarioController(IFuncionarioAppService funcionarioAppService, ICargoAppService cargoAppService)
        {
            _funcionarioAppService = funcionarioAppService;
            _cargoAppService = cargoAppService;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _funcionarioAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _funcionarioAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // GET: Funcionario/Create
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            await CarregarDropDownListAsync(cancellationToken);
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return await Create(cancellationToken);

            await _funcionarioAppService.AdicionarAsync(funcionarioViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
        {
            await CarregarDropDownListAsync(cancellationToken);
            return View(await _funcionarioAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FuncionarioViewModel funcionarioViewModel, CancellationToken cancellationToken)
        {
            if (id != funcionarioViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(funcionarioViewModel);

            await _funcionarioAppService.AtualizarAsync(funcionarioViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _funcionarioAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken);
            await _funcionarioAppService.ExcluirAsync(funcionario, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarDropDownListAsync(CancellationToken cancellationToken)
        {
            var itens = await _cargoAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            if (itens != null && itens.Any())
                ViewBag.Cargos = new SelectList(itens, "Id", "Nome");
        }
    }
}
