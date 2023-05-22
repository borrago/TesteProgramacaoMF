using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteProgramacaoMF.Profissionais.Application.Services.Cargo;
using TesteProgramacaoMF.Profissionais.Application.Services.Funcionario;
using TesteProgramacaoMF.Profissionais.Application.Services.FuncionarioObra;
using TesteProgramacaoMF.Profissionais.Application.Services.Obra;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.WebApp.MVC.Controllers
{
    [Authorize]
    public class FuncionarioObraController : Controller
    {
        private readonly IFuncionarioObraAppService _funcionarioObraAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IObraAppService _obraAppService;
        private readonly ICargoAppService _cargoAppService;

        public FuncionarioObraController(IFuncionarioObraAppService funcionarioObraAppService, IFuncionarioAppService funcionarioAppService, IObraAppService obraAppService, ICargoAppService cargoAppService)
        {
            _funcionarioObraAppService = funcionarioObraAppService;
            _funcionarioAppService = funcionarioAppService;
            _obraAppService = obraAppService;
            _cargoAppService = cargoAppService;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _funcionarioObraAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _funcionarioObraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

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
        public async Task<IActionResult> Create(FuncionarioObraViewModel funcionarioObraViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return await Create(cancellationToken);

            if (await RegraNegocioInvalidaAsync(funcionarioObraViewModel, cancellationToken))
                return RedirectToAction(nameof(Index));

            await _funcionarioObraAppService.AdicionarAsync(funcionarioObraViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
        {
            await CarregarDropDownListAsync(cancellationToken);
            return View(await _funcionarioObraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FuncionarioObraViewModel funcionarioObraViewModel, CancellationToken cancellationToken)
        {
            if (id != funcionarioObraViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(funcionarioObraViewModel);

            if (await RegraNegocioInvalidaAsync(funcionarioObraViewModel, cancellationToken))
                return BadRequest("Não foi possivel cadastrar.");

            await _funcionarioObraAppService.AtualizarAsync(funcionarioObraViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _funcionarioObraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var funcionarioObra = await _funcionarioObraAppService.ObterPorIdAsNoTrackingNoIncludeAsync(id, cancellationToken);
            await _funcionarioObraAppService.ExcluirAsync(funcionarioObra, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarDropDownListAsync(CancellationToken cancellationToken)
        {
            var obras = await _obraAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            if (obras != null && obras.Any())
                ViewBag.Obras = new SelectList(obras, "Id", "Nome");

            var funcionarios = await _funcionarioAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            if (funcionarios != null && funcionarios.Any())
                ViewBag.Funcionarios = new SelectList(funcionarios, "Id", "Nome");
        }

        private async Task<bool> RegraNegocioInvalidaAsync(FuncionarioObraViewModel funcionarioObraViewModel, CancellationToken cancellationToken)
        {
            var funcionarioObras = await _funcionarioObraAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            if (funcionarioObras.Any(a => a.FuncionarioId == funcionarioObraViewModel.FuncionarioId && a.ObraId == funcionarioObraViewModel.ObraId &&
              a.DtInicio.Date <= funcionarioObraViewModel.DtInicio.Date && a.DtFim.Date >= funcionarioObraViewModel.DtFim.Date))
                return true;

            var cargo = await _cargoAppService.ObterTodosAsNoTrackingAsync(cancellationToken);
            var cargoEncarregadoObra = cargo.FirstOrDefault(f => f.Nome.ToUpper().Equals("ENCARREGADO DE OBRA"));

            var funcionario = await _funcionarioAppService.ObterPorIdAsNoTrackingAsync(funcionarioObraViewModel.FuncionarioId, cancellationToken);

            if (funcionarioObras.Any(a => a.Funcionario.CargoId == cargoEncarregadoObra.Id && funcionario.CargoId == cargoEncarregadoObra.Id &&
              a.ObraId == funcionarioObraViewModel.ObraId))
                return true;

            return false;
        }
    }
}
