using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models;
using ProductManager.Service;

namespace ProductManager.Service
{
    public class NewService : INewService
    {
        private readonly DataContext _context;
        public NewService(DataContext context)
        {
            _context = context;
        }
        public List<New> GetNewByType(string typeNew)
        {
            return _context.News.Where(n => n.TypeNew!.Equals(typeNew)).ToList();
        }
        public List<New> SearchNew(string searchingString)
        {
            return  _context.News.Where(s => s.Title!.Contains(searchingString)).ToList();
        }
        public void CreateNew(New New)
        {
            var existedNew = _context.News.FirstOrDefault(n => n.Slug!.Equals(New.Slug));
            if (existedNew != null)
            {
                throw new ArgumentException("Slug is duplicated !");
            }

            _context.News.Add(New);
            _context.SaveChanges();
        }

        public void DeleteNew(int id)
        {
           var existedNew = GetNewById(id);
           if (existedNew == null) return;

           _context.News.Remove(existedNew);
           _context.SaveChanges();
        }

        public List<TypeNew> GetTypeNew()
        {
            return _context.TypeNew.ToList();
        }

        public New? GetNewById(int id)
        {
            return _context.News.FirstOrDefault(p=>p.Id==id);
        }

        public List<New> GetNews()
        {
            return _context.News.Include(p=>p.TypeNew).ToList();
        }

        public void UpdateNew(New news)
        {
            var existedNew = GetNewById(news.Id);
            if (existedNew == null) return;
            existedNew.Title = news.Title;
            existedNew.Slug = news.Slug;

            var checkDuplicated = _context.News.FirstOrDefault(n => n.Slug!.Equals(news.Slug));
            if (checkDuplicated != null)
            {
                throw new ArgumentException("Slug is duplicated !");
            }

            existedNew.Content = news.Content;
            existedNew.Image = news.Image;
            existedNew.TypeNewId = news.TypeNewId;
            _context.News.Update(existedNew);
            _context.SaveChanges();
        }

      
    }
}