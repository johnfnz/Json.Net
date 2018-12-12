﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Json.Net.Tests
{
    [TestClass]
    public class FunctionalTests
    {
        enum Gender
        {
            Female,
            Male
        }


        class Pet
        {
            public int id = 1;
            public string name = "gucci";
            public DateTime birth = DateTime.Now;
            public bool alive = true;
            public Gender gender = Gender.Male;
            public Dictionary<string, string> dictType = new Dictionary<string, string>()
            {
                {"Key1","Value1"},
                {"Key2","Value2"},
            };
            public int[] intArray = new[] { 1, 2, 3 };
        }


        [TestMethod]
        public void TestMethod1()
        {
            var json = new Json();
            var originalPet = new Pet();

            var petJson = Json.Serialize(originalPet);
            var restoredPet = json.Deserialize<Pet>(petJson);

            Debug.Assert(restoredPet.id == originalPet.id);
            Debug.Assert(restoredPet.name == originalPet.name);
            Debug.Assert(restoredPet.gender == originalPet.gender);
            Debug.Assert(restoredPet.alive == originalPet.alive);
            Debug.Assert(restoredPet.birth.ToString() == originalPet.birth.ToString());
            Debug.Assert(restoredPet.dictType["Key1"] == originalPet.dictType["Key1"]);
            Debug.Assert(restoredPet.dictType["Key2"] == originalPet.dictType["Key2"]);
            Debug.Assert(restoredPet.intArray[0] == originalPet.intArray[0]);
            Debug.Assert(restoredPet.intArray[1] == originalPet.intArray[1]);
            Debug.Assert(restoredPet.intArray[2] == originalPet.intArray[2]);
        }
    }
}
