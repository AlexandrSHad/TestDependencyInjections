using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PopulateCharactersIfNoExist();
            var characters = _characterRepository.GetAll();
            return Ok(characters);
        }

        private void PopulateCharactersIfNoExist()
        {
            if (!_characterRepository.GetAll().Any())
            {
                _characterRepository.Add(new Character("Vvv Nnnn"));
                _characterRepository.Add(new Character("123 456"));
                _characterRepository.Add(new Character("Ivan Pereb"));
            }
        }
    }
}
