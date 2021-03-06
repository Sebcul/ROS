﻿using System;
using System.Collections.Generic;
using ROSPersistence.ROSDB;

namespace ROS.Services.Test.Test_Utilities
{
    public class TestDataFactory
    {
        

        public static List<User> CreateDataForUserRepository()
        {
            return new List<User>
            {
                new User {Id = 1, Active = true, FirstName = "John", LastName = "Doe", Email = "doedoe_@gmail.com"},
                new User {Id = 2, Active = true, FirstName = "Eric", LastName = "Evans", Email = "evan_s@hotmail.com"},
                new User
                {
                    Id = 3,
                    Active = false,
                    FirstName = "Martin",
                    LastName = "Fowler",
                    Email = "m_fowler@greatest.com"
                },
                new User
                {
                    Id = 4,
                    Active = true,
                    FirstName = "Kent",
                    LastName = "Beck",
                    Email = "commisarie_beck@snuten.se"
                },
                new User
                {
                    Id = 5,
                    Active = true,
                    FirstName = "Uncle",
                    LastName = "Bob", 
                    Email = "uncle_b0b@grottmail.com"
                }
            };
        }



        public static List<Regatta> CreateRegattaTestData()
        {
            return new List<Regatta>
            {
                new Regatta {Id = 1, Name = "Regatta 1", Active = true, StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue},
                new Regatta {Id = 2, Name = "Regatta 2", Active = true, StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue},
                new Regatta {Id = 3, Name = "Regatta 3", Active = false, StartTime = DateTime.MinValue, EndTime = DateTime.MinValue},
                new Regatta {Id = 4, Name = "Regatta 4", Active = true, StartTime = DateTime.Today, EndTime = DateTime.Today},
                new Regatta {Id = 5, Name = "Regatta 5", Active = true, StartTime = DateTime.MinValue, EndTime = DateTime.MinValue},
                new Regatta {Id = 5, Name = "Regatta 6", Active = true, StartTime = DateTime.MinValue, EndTime = DateTime.MaxValue},
                new Regatta {Id = 5, Name = "Regatta 7", Active = true, StartTime = DateTime.MinValue, EndTime = DateTime.MaxValue}
            };
        }


        public static List<Regatta> CreateRegattaTestDataWithUser(User user)
        {
            return new List<Regatta>
            {
                new Regatta
                {
                    Id = 1, Name = "Westcoast S-Regatta 2016", Active = true,
                    StartTime = new DateTime(2016, 06, 22, 13, 00, 00),
                    EndTime = new DateTime(2016, 06, 27, 18, 00, 00),
                    Entries = new List<Entry>{new Entry{Id = 1,
                        RegisteredUsers = new List<RegisteredUser> {new RegisteredUser{EntryId = 1, Id = user.Id, UserId = user.Id, User = user}}}}
                },
                    
                new Regatta
                {
                    Id = 2, Name = "Eastcoast S-Regatta 2016", Active = true,
                    StartTime = new DateTime(2016, 07, 05, 12, 00, 00),
                    EndTime = new DateTime(2016, 07, 10, 22, 00, 00),
                    Entries = new List<Entry>{new Entry{Id = 1,
                        RegisteredUsers = new List<RegisteredUser> {new RegisteredUser{EntryId = 1, Id = user.Id, UserId = user.Id, User = user}}}}
                },

                new Regatta
                {
                    Id = 3, Name = "This one is Inactive!", Active = false
                }

            };
        }
    }
}
