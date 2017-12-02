using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WhenRepair.Application
{
    [TestFixture]
    public class Test
    {
        [Test]
        public async Task Fias()
        {
            var results = await new FiasClient().Get("region", null);

            Assert.That(results, Is.Not.Empty);
        }

        [Test]
        public async Task House()
        {
            var result = await new HouseSearcher().Search(Guid.Parse("92b30014-4d52-4e2e-892d-928142b924bf"),
                                                          Guid.Parse("2763c110-cb8b-416a-9dac-ad28a55b4402"),
                                                          Guid.Parse("95e3c889-e00a-41a2-aa26-bac735271d82"),
                                                          Guid.Parse("8882d015-1fc8-9f80-98ab-82eeb8a70232"));

            Assert.That(result.Length, Is.EqualTo(1));
        }

        [Test]
        public async Task Repair()
        {
            var houseSummeries = await new RepairSearcher().Search("ул. Анри Барбюса 6");

            Assert.That(houseSummeries.Length, Is.EqualTo(3));
        }
    }
}