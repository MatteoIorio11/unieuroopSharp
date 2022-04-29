using NUnit.Framework;
using unieuroopSharp.Iorio.AnalitycImpl;
    
namespace IorioTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            AnalitycImpl dioporco = new unieuroopSharp.Iorio.AnalitycImpl(null);
        }

        [Test]
        public void Test1()
        { 
            Assert.Pass();
        }
    }
}