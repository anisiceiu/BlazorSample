using BlazorApp1.DAL;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorContext context = new AuthorContext();
        public AuthorController() { 
        

        }

        [HttpGet]
        [Route("Index")]
        public async Task<IEnumerable<Author>> Index()
        {
            
            return await context.Authors.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Author> Create([FromBody] Author author)
        {
            if (ModelState.IsValid)
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }

            return author;
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Author Details(int id)
        {
            Author author = context.Authors.Find(id);
            return author;
        }

        [HttpPut]
        [Route("Edit")]
        public void Edit([FromBody] Author author)
        {
            if (ModelState.IsValid)
            {
                context.Entry(author).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            Author author = context.Authors.Find(id);
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }
}
