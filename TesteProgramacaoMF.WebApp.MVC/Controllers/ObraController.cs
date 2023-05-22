using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteProgramacaoMF.Profissionais.Application.Services.Obra;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.WebApp.MVC.Controllers
{
    [Authorize]
    public class ObraController : Controller
    {
        private readonly IObraAppService _obraAppService;

        public ObraController(IObraAppService context)
        {
            _obraAppService = context;
        }

        // GET: Obra
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _obraAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Obra/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _obraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // GET: Obra/Create
        public IActionResult Create()
            => View();

        // POST: Obra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObraViewModel obraViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(obraViewModel);

            await _obraAppService.AdicionarAsync(obraViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Obra/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
            => View(await _obraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Obra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ObraViewModel obraViewModel, CancellationToken cancellationToken)
        {
            if (id != obraViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(obraViewModel);

            await _obraAppService.AtualizarAsync(obraViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Obra/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _obraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var obra = await _obraAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken);
            await _obraAppService.ExcluirAsync(obra, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
