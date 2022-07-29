using PoopAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace PoopAPI.IPoopManager
{
    public class FriendManager
    {
        public string whatUDo = "I managed!";
        public FriendInfoData fiData;
        public FriendManager()
        {

            fiData = new FriendInfoData();
            LoadDefaultFriendsIntoList();
        }

        

        public void LoadDefaultFriendsIntoList()
        {
       
            for (int i = 0; i < fiData.firstNames.Length; i++)
            {
                fiData.friends.Add(new FriendInfo(fiData.i++, fiData.firstNames[i], fiData.lastNames[i], fiData.location[i]));
               
            }
        }


    }
}
