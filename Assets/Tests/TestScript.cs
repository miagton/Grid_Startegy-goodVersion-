using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {
        GridStructure grid;
      [OneTimeSetUp]
      public void Init()
      {
            GridStructure grid = new GridStructure(3,100,100);
      }


        #region GridPositionTest
        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionPasses()
        {
            //arrange
           
            Vector3 position = new Vector3(0, 0, 0);
            //act
            Vector3 returnPosition=  grid.CalculateGridPosition(position);
            //assert
            Assert.AreEqual( Vector3.zero,returnPosition);
        }
        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            //arrange
           
            Vector3 position = new Vector3(2.8f, 0, 2.8f);
            //act
            Vector3 returnPosition = grid.CalculateGridPosition(position);
            //assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }
        [Test]
        public void CalculateGridPositionFail()
        {
            //arrange
            
            Vector3 position = new Vector3(3.1f, 0, 0);
            //act
            Vector3 returnPosition = grid.CalculateGridPosition(position);
            //assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
        #endregion


    }
}
