using System;
using ColorRevitAddIn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorRevitAddin.Tests
{
    [TestClass]
    public class BuildingTests
    {
        [TestMethod]
        public void Process_AlternateSemitone()
        {
            var building = new Building();
            var part1 = new FakePart("Секция 1", "Этаж 1", "Двухкомнатная", "Квартира 01");
            var part2 = new FakePart("Секция 1", "Этаж 1", "Двухкомнатная", "Квартира 02");
            var part3 = new FakePart("Секция 1", "Этаж 1", "Двухкомнатная", "Квартира 03");
            var part4 = new FakePart("Секция 1", "Этаж 1", "Однокомнатная", "Квартира 04");
            building.Add(new []
            {
                part1, 
                part2, 
                part3, 
                part4, 
            });
            building.Process();

            Assert.IsFalse(part1.IsSemistone);
            Assert.IsTrue(part2.IsSemistone);
            Assert.IsFalse(part3.IsSemistone);
        }
    }
}
