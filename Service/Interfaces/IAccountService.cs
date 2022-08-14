﻿using MyBookMarks.Domain;
using MyBookMarks.Domain.Response;
using MyBookMarks.Models;
using MyBookMarks.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBookMarks.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ClaimsIdentity>> RegisterUser(RegistrViewModel model);

        Task<Response<ClaimsIdentity>> LoginUser(LoginViewModel model);
    }   
}
