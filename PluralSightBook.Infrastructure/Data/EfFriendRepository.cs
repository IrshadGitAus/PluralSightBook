using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Infrastructure.Data
{
    public class EfFriendRepository:IFriendRepository
    {
        public void Create(Guid userId, string emailAddress)
        {
            var context = new aspnetdbEntities();
            var newFriend = context.Friends.CreateObject();
            newFriend.UserId = userId;
            newFriend.EmailAddress = emailAddress;
            context.AddToFriends(newFriend);
            context.SaveChanges();
        }


        public void Delete(int friendId)
        {
            var context = new aspnetdbEntities();
            var friendToDelete = context.Friends.FirstOrDefault(m => m.Id == friendId);
            context.Friends.DeleteObject(friendToDelete);
            context.SaveChanges();
        }

        public IEnumerable<Core.Model.Friend> ListFriendsOfUser(Guid currentUserId)
        {
            var context = new aspnetdbEntities();
            return context.Friends
                .Where(f => f.UserId == currentUserId)
                .Select(f => new Friend()
                {
                    Id = f.Id,
                    EmailAddress = f.EmailAddress
                });
        }
    }
}
