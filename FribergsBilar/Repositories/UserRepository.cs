﻿using FribergsBilar.Data;
using FribergsBilar.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace FribergsBilar.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDBContext applicationDBContext;

        public UserRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async void Add(User user)
        {
            await applicationDBContext.Users.AddAsync(user);
            applicationDBContext.SaveChanges();
        }

        public void Delete(User user)
        {
            applicationDBContext.Users.Remove(user);
            applicationDBContext.SaveChanges();
        }

        public void Update(User user)
        {
            applicationDBContext.Users.Update(user);
            applicationDBContext.SaveChanges();
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            return await applicationDBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
