using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using RecipeApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ContactMessageService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool Add(ContactMessage contactMessage)
        {
            _repoWrapper.ContactMessage.Create(contactMessage);
            _repoWrapper.Save();
            return true;
        }

        public ContactMessage Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _contactMessage = (ContactMessage) _repoWrapper.ContactMessage.FindByCondition(m => m.Id == id).ToList()[0];
            return _contactMessage;
        }

        public ContactMessage GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _contactMessage = (ContactMessage) _repoWrapper.ContactMessage.FindByCondition(m => m.Id == id).ToList()[0];

            return _contactMessage;
        }

        public bool Edit(ContactMessage contactMessage)
        {
            try
            {
                _repoWrapper.ContactMessage.Update(contactMessage);
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactMessageExists(contactMessage.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public ContactMessage GetDelete(int? id)
        {
            return (ContactMessage) _repoWrapper.ContactMessage.FindByCondition(m => m.Id == id).ToList()[0];
        }

        public bool Delete(int id)
        {
            var contactMessage = (ContactMessage) _repoWrapper.ContactMessage.FindByCondition(m => m.Id == id).ToList()[0];

            _repoWrapper.ContactMessage.Delete(contactMessage);
            _repoWrapper.Save();

            return true;
        }

        private bool ContactMessageExists(int id)
        {
            var contactMessages = _repoWrapper.ContactMessage.FindByCondition(e => e.Id == id).ToList();
            return contactMessages.Any();
        }

        public List<ContactMessage> GetAll()
        {
            return _repoWrapper.ContactMessage.FindAll().ToList();
        }
    }
}
