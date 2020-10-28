using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EpayApp.Data;
using EpayApp.Models;
using System.Text.RegularExpressions;
using EpayApp.Api;

namespace EpayApp.Views.TransactionReportView
{
    public class AuthoriseCardRequestModelsController : Controller
    {
        private readonly AppDbContext _context;


        public AuthoriseCardRequestModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AuthoriseCardRequestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthoriseCardRequestModel.ToListAsync());
        }

        // GET: AuthoriseCardRequestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authoriseCardRequestModel == null)
            {
                return NotFound();
            }

            return View(authoriseCardRequestModel);
        }

        // GET: AuthoriseCardRequestModels/Create
        public IActionResult Create()
        {
            return View();
        }


        //Function that is used for the payment process - HttpPost

        // POST: AuthoriseCardRequestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CardHolderName,CardNumber,ExpiryMonth,ExpiryYear,Cvv,Currency,Amount,TransactionId,MerchantId")] AuthoriseCardRequestModel authoriseCardRequestModel)
         {
            if (ModelState.IsValid)
            {
                var authoriseCardRequestModels1Controller = new AuthoriseCardRequestModels1Controller(_context);

                //API HttpPost function call
                var apiResponseFromPostmethod = authoriseCardRequestModels1Controller.PostAuthoriseCardRequestModel(authoriseCardRequestModel);

                if (apiResponseFromPostmethod != null)
                {
                    ViewBag.Result = true;
                    ViewBag.TransactionId = authoriseCardRequestModel.TransactionId;
                    return View("~/Views/Home/Index.cshtml", authoriseCardRequestModel);
                }

                else
                {
                    ViewBag.Result = false;
                    return View("~/Views/Home/Index.cshtml", authoriseCardRequestModel);
                }              
            }

            return View(authoriseCardRequestModel);
        }

        // GET: AuthoriseCardRequestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel.FindAsync(id);
            if (authoriseCardRequestModel == null)
            {
                return NotFound();
            }
            return View(authoriseCardRequestModel);
        }

        // POST: AuthoriseCardRequestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardHolderName,CardNumber,ExpiryMonth,ExpiryYear,Cvv,Currency,Amount,TransactionId,MerchantId")] AuthoriseCardRequestModel authoriseCardRequestModel)
        {
            if (id != authoriseCardRequestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authoriseCardRequestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthoriseCardRequestModelExists(authoriseCardRequestModel.Id))
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
            return View(authoriseCardRequestModel);
        }

        // GET: AuthoriseCardRequestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authoriseCardRequestModel == null)
            {
                return NotFound();
            }

            return View(authoriseCardRequestModel);
        }

        // POST: AuthoriseCardRequestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel.FindAsync(id);
            _context.AuthoriseCardRequestModel.Remove(authoriseCardRequestModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthoriseCardRequestModelExists(int id)
        {
            return _context.AuthoriseCardRequestModel.Any(e => e.Id == id);
        }
    }
}
