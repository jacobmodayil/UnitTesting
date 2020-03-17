using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _repository;
        private Booking _existingBooking;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBookingRepository>();
            _existingBooking = new Booking()
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };

            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>()
            {
             _existingBooking
            }.AsQueryable());
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                    DepartureDate = Before(_existingBooking.ArrivalDate)
                }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingStartsBeforeAndFinishesInTheMiddleAnExistingBooking_ReturnExistingBooking()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = Before(_existingBooking.ArrivalDate),
                    DepartureDate = After(_existingBooking.DepartureDate)
                }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBooking()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = After(_existingBooking.ArrivalDate),
                    DepartureDate = Before(_existingBooking.DepartureDate)
                }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingStartsAndFinishesInTheMiddleOfAnExistingBookingButFinishesAfter_ReturnExistingBooking()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = After(_existingBooking.ArrivalDate),
                    DepartureDate = After(_existingBooking.DepartureDate)
                }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = After(_existingBooking.DepartureDate),
                    DepartureDate = After(_existingBooking.DepartureDate, days: 2)
                }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookingHelper")]
        public void OverlappingBookingExist_BookingsOverlapButNewBookingIsCancelled_ReturnExistingBooking()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 1,
                    ArrivalDate = After(_existingBooking.ArrivalDate),
                    DepartureDate = After(_existingBooking.DepartureDate),
                    Status = "Cancelled"
                }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(2017, 1, 10, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(2017, 1, 14, 10, 0, 0);
        }

    }
}
