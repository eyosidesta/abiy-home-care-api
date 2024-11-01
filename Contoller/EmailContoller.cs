using Microsoft.AspNetCore.Mvc;
using model.email;
using services.email;

namespace contoller.email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController: ControllerBase {
        private readonly EmailServices _emailServices;
        public EmailController(EmailServices emailServices) {
            _emailServices = emailServices;
        }

        [HttpGet]
        public async Task<IActionResult> getAllEmail() {
            var todos = await _emailServices.GetAllEmailAsync();
            return Ok(todos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmailById(int id) {
            var email = await _emailServices.GetEmailByIdAsync(id);
            if (email == null) return NotFound();
            return Ok(email);
        }
        [HttpPost]
        public async Task<IActionResult> addEmail([FromBody] EmailModel email) {
            var newEmail = await _emailServices.CreateEmailAsync(email);
            return CreatedAtAction(nameof(getEmailById), new {id = newEmail.Id}, newEmail);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateEmail(int id, [FromBody] EmailModel email) {
            if (id != email.Id) return BadRequest();
            var updateEmail = await _emailServices.UpdateEmailAsync(email);
            return Ok(updateEmail);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEmail(int id) {
            var result = await _emailServices.DeleteEmailAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }

}