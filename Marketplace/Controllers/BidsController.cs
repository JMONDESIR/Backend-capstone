using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketplace.Data;
using Marketplace.Models;
using Microsoft.AspNetCore.Identity;
using Marketplace.Models.ItemViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Marketplace.Controllers
{
    [Authorize]
    public class BidsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BidsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Bids by current user
        public async Task<IActionResult> BuyerBidIndex()
        {
            var currentUser = await GetCurrentUserAsync();
            var userBids = _context.Bid.Include(i => i.Item).Where(b => b.UserId == currentUser.Id);


            return View(await userBids.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Item)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public async Task<IActionResult> Create(int? Id)
        {
            BidItemViewModel bidItemview = new BidItemViewModel();

            if (Id == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var item = await _context.Item
                .FirstOrDefaultAsync(i => i.ItemId == Id);

            bidItemview.Item = item;
            bidItemview.Bid = new Bid();
            bidItemview.User = currentUser;

            return View(bidItemview);
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BidItemViewModel bidItemView)
        {

            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                bidItemView.Bid.UserId = currentUser.Id;
                bidItemView.Bid.ItemId = bidItemView.Item.ItemId;
                _context.Add(bidItemView.Bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BuyerBidIndex));
            }

            // ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", bid.ItemId);
            return View(bidItemView);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", bid.ItemId);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bid bid)
        {
            if (id != bid.BidId)
            {
                return NotFound();
            }
            var BidToUpdate = await _context.Bid.FindAsync(id);
            BidToUpdate.When = bid.When;
            BidToUpdate.Offer = bid.Offer;
            BidToUpdate.Comment = bid.Comment;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(BidToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.BidId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BuyerBidIndex));
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", bid.ItemId);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Item)
                .FirstOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bid.FindAsync(id);
            _context.Bid.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BuyerBidIndex));
        }

        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.BidId == id);
        }
    }
}
