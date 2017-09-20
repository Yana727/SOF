using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOF.Data;
using SOF.Models;

namespace SOF.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
                       //^ how to manage user it's in Manage controller
        public QuestionsController(ApplicationDbContext context, UserManager<ApplicationUser> um)
        {                                                         //^reference in ManageController
            _context = context;
            _userManager = um; 
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.Questions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }
         [Authorize]
        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,QuestionText")] QuestionsModel questionsModel)
        {
            if (ModelState.IsValid)
            {
                //get the user and attach the userId to the new question
                var user = await _userManager.GetUserAsync(HttpContext.User); 
                                                          //^info about request (cookies)
                questionsModel.ApplicationUserId = user.Id;     
                _context.Add(questionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionsModel);
        }
        [Authorize]

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.Questions.SingleOrDefaultAsync(m => m.Id == id);
            if (questionsModel == null)
            {
                return NotFound();
            }
            return View(questionsModel);
        }
        [Authorize]

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,VoteCount,Title,Body,UserId,PostDate")] QuestionsModel questionsModel)
        {
            if (id != questionsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsModelExists(questionsModel.Id))
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
            return View(questionsModel);
        }
        [Authorize]
        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.Questions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }
        [Authorize]
        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var questionsModel = await _context.Questions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Questions.Remove(questionsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsModelExists(string id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
