using AutoMapper;
using MedPlan.App.ViewModels;
using MedPlan.Data.Context;
using MedPlan.Domain.Interfaces.InterfaceProcedimento;
using MedPlan.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPlan.App.Controllers
{
    public class ProcedimentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProcedimentoRepositorio _procedimentoRepositorio;

        private readonly ContextBase _context;

        public ProcedimentoController(ContextBase context,
                                     IProcedimentoRepositorio procedimentoRepositorio, 
                                      IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _procedimentoRepositorio = procedimentoRepositorio;
        }

        // GET: Procedimento
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProcedimentoViewModel>>(await _procedimentoRepositorio.ObterTodos()));
        }

        // GET: Procedimento/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // GET: Procedimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Valor,Id")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                procedimento.Id = Guid.NewGuid();
                _context.Add(procedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimento);
        }

        // GET: Procedimento/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }
            return View(procedimento);
        }

        // POST: Procedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Valor,Id")] Procedimento procedimento)
        {
            if (id != procedimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoExists(procedimento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(procedimento);
        }

        // GET: Procedimento/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // POST: Procedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);
            _context.Procedimentos.Remove(procedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoExists(Guid id)
        {
            return _context.Procedimentos.Any(e => e.Id == id);
        }
    }
}
