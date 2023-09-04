using APIDemo.Data;

namespace APIDemo.Services.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService
    {
        //Data sample
        /*private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero {Id = 1,
                    Name ="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"},

                 new SuperHero {Id = 2,
                    Name ="Iron Man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Malibu"}
            };*/

        private readonly DataContext _context;

        //Constructor to inject the data context 
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero); //Add 
            await _context.SaveChangesAsync(); // Save

            return await _context.SuperHeroes.ToListAsync(); //return list of the heroes
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            //use not found status code
            if (hero == null) return null;

            _context.SuperHeroes.Remove(hero); // Remove
            await _context.SaveChangesAsync();// Save changes

            return await _context.SuperHeroes.ToListAsync(); //return list of the heroes

        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            //use not found status code
            if (hero == null) return null;

            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            //Get the property 
            var hero = await _context.SuperHeroes.FindAsync(id);
            //use not found status code
            if (hero == null) return null;
            
            //change the property
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            
            //Save the property
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
