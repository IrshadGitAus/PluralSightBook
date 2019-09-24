using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Services
{
    public class FriendsService
    {
        private readonly INotificationService _notificationService;
        private readonly IFriendRepository _friendRepository;
        public FriendsService(IFriendRepository friendRepository, INotificationService notificationService)
        {
            _friendRepository = friendRepository;
            _notificationService = notificationService;
        }

        public void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail)
        {

            _friendRepository.Create(currentUserId, friendEmail);

            _notificationService.SendNotification(currentUserEmail, currentUserName, friendEmail);
        }


        public IEnumerable<Friend> ListFriendsOf(Guid currentUserId)
        {
            return _friendRepository.ListFriendsOfUser(currentUserId);
        }

        public void DeleteFriend(int friendId)
        {
            _friendRepository.Delete(friendId);
        }
    }
}
