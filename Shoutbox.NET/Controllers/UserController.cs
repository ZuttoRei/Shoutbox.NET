﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoutbox.NET.Data;
using Shoutbox.NET.Models;
using System.DirectoryServices.AccountManagement;
using Shoutbox.NET.Services;

namespace Shoutbox.NET.Controllers
{
    public class UserController : Controller, IUserRepository
    {
        private IUserPrincipalRepository _userPrincipalRepository;

        public UserController(IUserPrincipalRepository userPrincipalRepository)
        {
            _userPrincipalRepository = userPrincipalRepository;
        }

        public UserController()
        {
        }

        public User GetByLogonUser(string logonUser)
        {
            using (ShoutboxContext db = new ShoutboxContext())
            {
                string username = logonUser.Split('\\')[1];
                User user = db.Users.FirstOrDefault(f => f.Username == username);

                //If user doesn't exist yet, register them
                if (user == null) user = Create(logonUser);

                return user;
            }
        }


        public User Create(string logonUser)
        {
            if (ModelState.IsValid)
            {
                using (ShoutboxContext db = new ShoutboxContext())
                {
                    //Get the user's information from ActiveDirectory
                    UserPrincipal activeDirectoryUser = _userPrincipalRepository.GetByLogonUser(logonUser);

                    //Store the information in a database for faster processing
                    User user = new User
                    {
                        Name = activeDirectoryUser.DisplayName,
                        Domain = logonUser.Split('\\')[0],
                        Username = logonUser.Split('\\')[1],
                        Division = Division.RN
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                    return user;
                }
            }

            return null;
        }
    }
}
