using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters.AsEnumerable();
        }
    }
}
