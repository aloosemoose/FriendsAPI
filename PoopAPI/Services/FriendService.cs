
using PoopAPI.IPoopManager;
using System.Collections.Generic;
using PoopAPI.Models;
using System.IO;
using System.Linq;

namespace PoopAPI.IPoopService
{
    public interface IFriendService
    {
        public string friendServiceTest();
        public string friendManagerTest();
        public string friendControllerTest();

        public string SaveName();
        public List<FriendInfo> ChangedList(FriendInfo newFriend);
        public List<FriendInfo> ChangedList2(FriendInfo newFriend);

        public List<FriendInfo> AppendedList(FriendInfo newFriend);

        public List<FriendInfo> LoadDefaultFriendsIntoList();


      
    }
    public class FriendService : IFriendService
    {
        private readonly FriendManager Manager;
        public FriendService(FriendManager manager)
        {
            Manager = manager;
        }

        public string friendServiceTest()
        {
            return "Success from the manager";
        }
        public string friendManagerTest()
        {
            return Manager.whatUDo;
        }
        public string SaveName()
        {

        

           
            //get list of friends

            //

            var currentList = Manager.fiData.friends;
            //convert current list to .json string using newtonsoft.json

            //loop through list
            //convert each friend object into a .json string using newtonsoft.json


            var currentListAsArray = currentList.ToArray();
            //change to type IEnumerable<string>
            //var stringList = currentList.OfType<string>();

            File.AppendAllLines("nEWtEXT.txt", (IEnumerable<string>)currentList);

            return "Done!";
        }

        public string friendControllerTest()
        {
            return "Success from the controller";
        }

        public List<FriendInfo> LoadDefaultFriendsIntoList()
        {
            return Manager.fiData.friends;
        }

        public List<FriendInfo> AppendedList(FriendInfo newFriend)
        {
           // var currentList = Manager.fiData.friends;
            Manager.fiData.friends.Add(newFriend);
            var newList = Manager.fiData.friends;
            return newList;

        }

        public List<FriendInfo> ChangedList(FriendInfo newFriend)
        {

            var newList = Manager.fiData.friends.Remove(Manager.fiData.friends[newFriend.Id - 1]);
            int a = 1;
            if (newList)
            {
                Manager.fiData.friends.Add(newFriend);
                return Manager.fiData.friends;
            }
            return Manager.fiData.friends;
        }
        
        public List<FriendInfo> ChangedList2(FriendInfo newFriend) 
        {
            var currentList = Manager.fiData.friends;
            var IdOfUpdate = newFriend.Id;

            foreach (var friend in currentList)
            {
                if(friend.Id == IdOfUpdate)
                {
                    friend.FirstName = newFriend.FirstName;
                    friend.LastName = newFriend.LastName;
                    friend.Location = newFriend.Location;
                }
            }
            return currentList;
        
        }
    }
}