using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteProgramacaoMF.Profissionais.Application.Services.Cargo;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.WebApp.MVC.Controllers
{
    [Authorize]
    public class CargoController : Controller
    {
        private readonly ICargoAppService _cargoAppService;

        public CargoController(ICargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;
        }

        // GET: Cargo
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _cargoAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Cargo/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _cargoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // GET: Cargo/Create
        public IActionResult Create()
            => View();

        // POST: Cargo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CargoViewModel cargoViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(cargoViewModel);

            await _cargoAppService.AdicionarAsync(cargoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cargo/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
            => View(await _cargoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CargoViewModel cargoViewModel, CancellationToken cancellationToken)
        {
            if (id != cargoViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(cargoViewModel);

            await _cargoAppService.AtualizarAsync(cargoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cargo/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _cargoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var cargo = await _cargoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken);
            await _cargoAppService.ExcluirAsync(cargo, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
