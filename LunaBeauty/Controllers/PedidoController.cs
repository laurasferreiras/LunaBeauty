using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LunaBeauty.Data;
using LunaBeauty.Models;

namespace LunaBeauty.Controllers
{
    public class PedidoController : Controller
    {
        private readonly LunaContext _context;

        public PedidoController(LunaContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var lunaContext = _context.Pedidos.Include(p => p.ClienteOrigem).Include(p => p.VendedorOrigem);
            return View(await lunaContext.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.ClienteOrigem)
                .Include(p => p.VendedorOrigem)
                .Include(p => p.Itens)
                .ThenInclude(i => i.ProdutoOrigem)
                .FirstOrDefaultAsync(m => m.PedidoId == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome");
            ViewBag.Produtos = _context.Produtos.ToList();
            return View(new Pedido
            {
                Itens = new List<ItemPedido>()
            });

        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,ClienteId,VendedorId,Data,Itens")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in pedido.Itens)
                {
                    item.ProdutoOrigem = await _context.Produtos.FindAsync(item.ProdutoId);
                    item.CalcularValorTotal();
                    if (item.ProdutoOrigem != null)
                    {
                        item.ProdutoOrigem.Estoque -= item.Quantidade;
                        if (item.ProdutoOrigem.Estoque < 0)
                            item.ProdutoOrigem.Estoque = 0;

                        _context.Update(item.ProdutoOrigem);
                    }
                }
                _context.Add(pedido);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome", pedido.VendedorId);
            ViewBag.Produtos = _context.Produtos.ToList();

            return View(pedido);
        }


        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Itens)
                .ThenInclude(i => i.ProdutoOrigem)
                .FirstOrDefaultAsync(p => p.PedidoId == id);

            if (pedido == null)
            {
                return NotFound();
            }
            
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome", pedido.VendedorId);

            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,ClienteId,VendedorId,Data,Itens")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome", pedido.VendedorId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.ClienteOrigem)
                .Include(p => p.VendedorOrigem)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }



    }
}

