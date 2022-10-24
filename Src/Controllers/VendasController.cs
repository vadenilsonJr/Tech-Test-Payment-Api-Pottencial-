using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tech_test_payment_api.Src.Models;
using tech_test_payment_api.Src.Context;

namespace tech_test_payment_api.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public VendaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
           var Vendas = _context.Vendas.Find(id);
            
            if (Vendas == null)
            return NotFound();

            
            return Ok(Vendas);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var vendas = _context.Vendas.ToList();
            return Ok(vendas);
        }

        [HttpPost]
        public IActionResult Criar(Vendas venda)
        {
            if (venda.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Vendas venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            if (venda.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            vendaBanco.Produto = venda.Produto;
            vendaBanco.Data = venda.Data;
            vendaBanco.Status = venda.Status;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            
            return Ok(vendaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var vendasBanco = _context.Vendas.Find(id);

            if (vendasBanco == null)
                return NotFound();

            _context.Vendas.Remove(vendasBanco);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}