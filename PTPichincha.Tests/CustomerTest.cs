using AutoFixture;
using AutoMapper;
using Moq;
using PTPichincha.Domain.Entity;
using PTPichincha.Domain.Utility;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using Xunit;

namespace PTPichincha.Tests
{
    public class Tests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Fixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public Tests()
        {
            _fixture = new Fixture();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();

        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Customer_Created_SuccessFull()
        {
            var customerEntityMock = _fixture.Create<Customer>();
            var result =  _unitOfWork.Setup(u => u.CustomerRepository.Add(customerEntityMock)).ReturnsAsync(customerEntityMock);
            Assert.NotNull(result);

        }

        [Test]
        public void Customer_Call_FindByID_Upon_Time()
        {
            var customerEntityMock = _fixture.Create<Customer>();
            _unitOfWork.Setup(u => u.CustomerRepository.FindById(u =>u.Id == It.IsAny<int>()));
            var result = _unitOfWork.Setup(u => u.CustomerRepository.Update(customerEntityMock)).ReturnsAsync(customerEntityMock);
            Assert.NotNull(result);

        }
    }
}