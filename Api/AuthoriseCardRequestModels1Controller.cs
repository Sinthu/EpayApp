using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EpayApp.Data;
using EpayApp.Models;

namespace EpayApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoriseCardRequestModels1Controller : ControllerBase
    {
        private readonly AppDbContext _context;
        public string apiResponseStatusCode;

        public AuthoriseCardRequestModels1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AuthoriseCardRequestModels1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthoriseCardRequestModel>>> GetAuthoriseCardRequestModel()
        {
            return await _context.AuthoriseCardRequestModel.ToListAsync();
        }

        // GET: api/AuthoriseCardRequestModels1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthoriseCardRequestModel>> GetAuthoriseCardRequestModel(int id)
        {
            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel.FindAsync(id);

            if (authoriseCardRequestModel == null)
            {
                return NotFound();
            }

            return authoriseCardRequestModel;
        }

        // PUT: api/AuthoriseCardRequestModels1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthoriseCardRequestModel(int id, AuthoriseCardRequestModel authoriseCardRequestModel)
        {
            if (id != authoriseCardRequestModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(authoriseCardRequestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthoriseCardRequestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AuthoriseCardRequestModels1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuthoriseCardRequestModel>> PostAuthoriseCardRequestModel(AuthoriseCardRequestModel authoriseCardRequestModel)
        {
            var apiData1 = _context.AuthoriseCardRequestModel.Add(authoriseCardRequestModel);
            var apiData2 = await _context.SaveChangesAsync();
            var apiResponse = CreatedAtAction("GetAuthoriseCardRequestModel", new { id = authoriseCardRequestModel.Id }, authoriseCardRequestModel);

            var authoriseCardResponseModel = new AuthoriseCardResponseModel();

            //Get API response status code
            authoriseCardResponseModel.StatusCode = apiResponse.StatusCode.ToString();

            if(authoriseCardResponseModel.StatusCode == "201")
            {
                return apiResponse;
            }
            return null;
            
        }

        // DELETE: api/AuthoriseCardRequestModels1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthoriseCardRequestModel>> DeleteAuthoriseCardRequestModel(int id)
        {
            var authoriseCardRequestModel = await _context.AuthoriseCardRequestModel.FindAsync(id);
            if (authoriseCardRequestModel == null)
            {
                return NotFound();
            }

            _context.AuthoriseCardRequestModel.Remove(authoriseCardRequestModel);
            await _context.SaveChangesAsync();

            return authoriseCardRequestModel;
        }

        private bool AuthoriseCardRequestModelExists(int id)
        {
            return _context.AuthoriseCardRequestModel.Any(e => e.Id == id);
        }
    }
}
