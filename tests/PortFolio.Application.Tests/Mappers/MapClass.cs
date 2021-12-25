using AutoMapper;
using NUnit.Framework;
using PortFolio.Application.Common.Mappers;
using PortFolio.Application.Models;
using PortFolio.Domain;

namespace PortFolio.Application.Tests.Mappers
{
    [TestFixture]
    public class MapClass
    {
        private MapperConfiguration _configuration;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _configuration = new MapperConfiguration(x =>
                x.AddProfile<AutoProfile>());
            _mapper = _configuration.CreateMapper();
        }
        
        [Test]
        public void Map_User_To_UserModel()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = "Foo",
            };
            var userModel = new UserModel();
           
            // Act
            _mapper.Map(user, userModel);
            
            // Assert
            
            Assert.AreEqual(1, userModel.Id);
            Assert.AreEqual("Foo", userModel.Name);
            Assert.AreEqual(null, userModel.LastName);
        }
    }
}