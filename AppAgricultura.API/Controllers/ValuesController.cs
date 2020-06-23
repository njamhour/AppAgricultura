using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAgricultura.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAgricultura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context; // Atributos privados levam '_' na frente
        public ValuesController(DataContext context)
        {
            _context = context;   
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues() // utilizando forma asincrona
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(usuario);
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
