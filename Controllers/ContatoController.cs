using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aulaMVC.Context;
using aulaMVC.Models;

namespace aulaMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            Contato contato = _context.Contatos.Find(id);
            if (contato is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            Contato contatoBanco = _context.Contatos.Find(contato.Id);
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            Contato contato = _context.Contatos.Find(id);
            if (contato is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            Contato contato = _context.Contatos.Find(id);
            if (contato is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            Contato contatoBanco = _context.Contatos.Find(contato.Id);
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}