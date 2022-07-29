
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using PoopAPI.Models;
using PoopAPI.IPoopService;

namespace PoopAPI.PoopController
{

    [ApiController]
    [Route("[Controller]")]

    public class FriendController : ControllerBase
    {
        //int[] Id = new int[] { 1, 2, 3, 4, 5 };
        public FriendInfoData fiData;
        int Id = 1;

        private readonly IFriendService fService;
        public FriendController(IFriendService friService)
        {
            fService = friService;
        }

        [HttpGet("TestService", Name = "TestService")]
        public ActionResult<string> TestService()
        {
            return fService.friendServiceTest();
        }

        [HttpGet("TestManager", Name = "TestManager")]
        public ActionResult<string> TestManager()
        {
            return fService.friendManagerTest();
        }

        [HttpGet("ControllerTest", Name = "ControllerTest")]
        public ActionResult<string> TestController()
        {
            return fService.friendControllerTest();
        }


        [HttpGet("ReturnsNames", Name = "ReturnsNames")]

        public List<FriendInfo> SaveToFile2()
        {
         return fService.LoadDefaultFriendsIntoList();
        }

        [HttpPut("ChangeAName", Name = "ChangeAName")]

        public List<FriendInfo> ChangeName(FriendInfo newFriend)
        {
            var newFriendList = fService.ChangedList(newFriend);
            return newFriendList;
        }

        [HttpPut("ChangeAName2", Name = "ChangeAName2")]

        public List<FriendInfo> ChangeName2(FriendInfo newFriend)
        {
            var newFriendList = fService.ChangedList2(newFriend);
            return newFriendList;
        }


        [HttpPost("AddName", Name = "AddName")]
        public List<FriendInfo> AddName(FriendInfo newFriend)
        {
            var newFriendList = fService.AppendedList(newFriend);
            return newFriendList;
        }

        [HttpPost("SaveNames", Name = "SaveNames")]
        public ActionResult<string> SaveName()
        {
            return fService.SaveName();
           
        }




        /*
                [HttpGet("ReturnsNames", Name = "ReturnsNames")]
                public IEnumerable<FriendInfo> Get()
                {
                    FriendInfoData data = new FriendInfoData();


                    return Enumerable.Range(0, 5).Select(index => new FriendInfo(Id[index], data.firstNames[index], data.lastNames[index], data.lastNames[index])
                    {
                        Id = Id[index],
                        FirstName = data.firstNames[index],
                        LastName = data.lastNames[index],
                        Location = data.location[index]
                    })
                    .ToArray();
                }*/

    }
    }


    
    

