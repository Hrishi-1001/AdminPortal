using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Views.Assets
{
	public class AssetsController : Controller
	{
		private readonly DatabaseContext _context;

		public AssetsController(DatabaseContext context)
		{
			_context = context;
		}

		[Route("/Assets")]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Assets.ToListAsync());
		}

		[Route("/Assets/Details/id")]
		// GET: Assets/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var asset = await _context.Assets
				.FirstOrDefaultAsync(m => m.Id == id);
			if (asset == null)
			{
				return NotFound();
			}

			return View(asset);
		}

		// GET: Assets/Create
		[Route("/Assets/Create")]
		[Route("/Assets/Create/{selectedLocation?}")]
		public IActionResult Create(string selectedLocation = null)
		{
			Asset asset = new Asset { Area = selectedLocation };
			return View(asset);
		}

		// POST: Assets/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("/Assets/Create")]
		[Route("/Assets/Create/{selectedLocation?}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Area,Latitude,Longitude,State,Temperature,Moisture")] Asset asset, string selectedLocation = null)
		{
			if (ModelState.IsValid)
			{
				asset.State = AssetState.functional;
				asset.Moisture = 2.0m;
				asset.Temperature = 26.4m;
				asset.Area = selectedLocation;
				_context.Add(asset);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(asset);
		}

		// GET: Assets/Edit/5
		[Route("/Assets/Edit/id")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var asset = await _context.Assets.FindAsync(id);
			if (asset == null)
			{
				return NotFound();
			}
			return View(asset);
		}

		// POST: Assets/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("/Assets/Edit/id")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Area,Latitude,Longitude,State,Temperature,Moisture")] Asset asset)
		{
			if (id != asset.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(asset);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AssetExists(asset.Id))
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
			return View(asset);
		}

		// GET: Assets/Delete/5
		[Route("/Assets/Delete/id")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var asset = await _context.Assets
				.FirstOrDefaultAsync(m => m.Id == id);
			if (asset == null)
			{
				return NotFound();
			}

			return View(asset);
		}

		// POST: Assets/Delete/5
		[HttpPost, ActionName("Delete")]
		[Route("/Assets/Delete/id")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var asset = await _context.Assets.FindAsync(id);
			_context.Assets.Remove(asset);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AssetExists(int id)
		{
			return _context.Assets.Any(e => e.Id == id);
		}
	}
}
