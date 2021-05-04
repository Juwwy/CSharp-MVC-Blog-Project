﻿using Microsoft.EntityFrameworkCore;
using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositaries
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BlogDbContext dbContext;

        public ApplicationUserRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Add(ApplicationUser user)
        {
            await dbContext.ApplicationUsers.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUserDTO> Find(int id)
        {
            var user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == id);
            return new ApplicationUserDTO
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                ProfilePhotoUrl = user.ProfilePhotoUrl
            };
        }

        public async Task<IEnumerable<ApplicationUserDTO>> GetAll()
        {
            return await dbContext.ApplicationUsers.Select(a => new ApplicationUserDTO
            {
                Id = a.Id,
                Firstname = a.Firstname,
                Lastname = a.Lastname,
                Email = a.Email,
                ProfilePhotoUrl = a.ProfilePhotoUrl
            }).ToListAsync();
        }

        public async Task<ApplicationUser> Remove(int id)
        {
            ApplicationUser user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == id);
            dbContext.ApplicationUsers.Remove(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
