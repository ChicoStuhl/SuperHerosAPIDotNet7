using Microsoft.AspNetCore.Http.HttpResults;
using SuperHerosAPIDotNet7.Data;
using SuperHerosAPIDotNet7.Models;

namespace SuperHerosAPIDotNet7.Service.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService
    {

        private readonly DataContext _dataContext;

        public SuperHeroService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero superHero)
        {

            await _dataContext.SuperHeroes.AddAsync(superHero);
            await _dataContext.SaveChangesAsync();
            
            return await GetAll();
        }

        public async Task<List<SuperHero>> DeleteHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FirstAsync(x => x.Id == id);
            if (hero == null)
            {
                return null;
            }
            _dataContext.SuperHeroes.Remove(hero);
            await _dataContext.SaveChangesAsync();

            return await GetAll();
        }

        public async Task<List<SuperHero>> GetAll()
        {
            var heroes = await _dataContext.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FirstAsync(x => x.Id == id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = await _dataContext.SuperHeroes.FirstAsync(x => x.Id == request.Id);
            if (hero == null)
            {
                return null;
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _dataContext.SaveChangesAsync();
          
            return await GetAll();
        }
    }
}
