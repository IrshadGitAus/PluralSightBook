using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Core.Interfaces
{
    public interface IFriendRepository
    {
        void Create(Guid userId, string emailAddress);

        void Delete(int friendId);

        IEnumerable<Model.Friend> ListFriendsOfUser(Guid userId);
    }
}
