using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            
            //Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
            
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsInvalid_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation() ;

            //Act
            reservation.MadeBy = new User() { IsAdmin = false };
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod] 
        public void CanBeCancelledBy_UserIsMadeByUser_ReturnsTrue()
        {
            //Arrange
            var madeByUser = new User();
            var reservation = new Reservation() { MadeBy = madeByUser };
            
            //Act
            var result = reservation.CanBeCancelledBy(madeByUser);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
