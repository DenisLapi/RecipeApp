﻿using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IContactMessageService
    {
        public List<ContactMessage> GetAll();

        public ContactMessage Details(int? id);

        public bool Add(ContactMessage complexity);

        public ContactMessage GetEdit(int? id);

        public bool Edit(ContactMessage complexity);

        public ContactMessage GetDelete(int? id);

        public bool Delete(int id);
    }
}
