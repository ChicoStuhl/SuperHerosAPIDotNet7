using Microsoft.AspNetCore.Mvc;
using SuperHerosAPIDotNet7.Models;

namespace SuperHerosAPIDotNet7.Service.SuperHeroServices
{
    public interface ISuperHeroService
    {
        public Task<List<SuperHero>> GetAll();
        public Task<SuperHero> GetSingleHero(int id);
        public Task<List<SuperHero>> AddHero(SuperHero superHero);
        public Task<List<SuperHero>> UpdateHero(SuperHero superHero);
        public Task<List<SuperHero>> DeleteHero(int id);
    }
}
