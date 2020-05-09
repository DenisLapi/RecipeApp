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
    public class LikeService : ILikeService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public LikeService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool Add(Like like)
        {
            _repoWrapper.Like.Create(like);
            _repoWrapper.Save();
            return true;
        }

        public Like Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _like = (Like) _repoWrapper.Like.FindByCondition(m => m.Id == id).ToList()[0];
            return _like;
        }

        public Like GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _like = (Like) _repoWrapper.Like.FindByCondition(m => m.Id == id).ToList()[0];
            return _like;
        }

        public bool Edit(Like like)
        {
            try
            {
                _repoWrapper.Like.Update(like);
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(like.Id))
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

        public Like GetDelete(int? id)
        {
            return (Like) _repoWrapper.Like.FindByCondition(m => m.Id == id).ToList()[0];
        }

        public bool Delete(int id)
        {
            var _like = (Like) _repoWrapper.Like.FindByCondition(m => m.Id == id).ToList()[0];

            _repoWrapper.Like.Delete(_like);
            _repoWrapper.Save();

            return true;
        }

        private bool LikeExists(int id)
        {
            var likes = _repoWrapper.Like.FindByCondition(e => e.Id == id).ToList();
            return likes.Any();
        }

        public List<Like> GetAll()
        {
            return _repoWrapper.Like.FindAll().ToList();
        }
    }
}
