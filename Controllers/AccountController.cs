using ASP_Web_Api.Models;
using ASP_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService) =>
            _accountService = accountService;

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _accountService.GetAsync();

        // GET api/<AccountController>/admin
        [HttpGet("{username}")]
        public async Task<List<Account>> Get(string username) =>
            await _accountService.GetAsync(username);

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post(Account account)
        {
            await _accountService.CreateAsync(account);
            return NoContent();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{username}")]
        public async Task<IActionResult> Put(string username, Account accountUpdate)
        {
            var account = await _accountService.GetAsync(username);

            if (account == null)
            {
                return NotFound();
            }
            await _accountService.UpdateAsync(accountUpdate);
            return NoContent();
        }

        // DELETE api/<AccountController>/admin
        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var account = await _accountService.GetAsync(username);

            if (account == null)
            {
                return NotFound();
            }
            await _accountService.DeleteAsync(username);
            return NoContent();
        }
    }
}
