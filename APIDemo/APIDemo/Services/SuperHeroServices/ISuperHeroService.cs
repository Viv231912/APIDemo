namespace APIDemo.Services.SuperHeroServices
{

    public interface ISuperHeroService
    {
        //Super Hero interface
        //Get all heros
        Task<List<SuperHero>> GetAllHeroes();
        //Get single heros
        Task<SuperHero>? GetSingleHero(int id);
        //Add hero
        Task<List<SuperHero>> AddHero(SuperHero hero);
        //Update hero
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);
        //Delete hero
        Task<List<SuperHero>?> DeleteHero(int id);

    }
}
