using jIAnSoft.Nami.Core;
using NUnit.Framework;

namespace Tests.Core
{
    [TestFixture]
    public class BoundedQueueTest
    {
        [Test]
        public void TestBoundedQueue()
        {
            var q = new BoundedQueue();
            q.Stop();
            q.Enqueue(() => { });
            TestContext.WriteLine($"q.Count():{q.Count()}");
            Assert.AreEqual(0, q.Count());
            q.Run();
            q.Enqueue(() => { });
            TestContext.WriteLine($"q.Count():{q.Count()}");
            Assert.AreEqual(1, q.Count());
            var r = q.DequeueAll();
            TestContext.WriteLine($"q.Count():{q.Count()} r.Count():{r.Count}");
            Assert.AreEqual(0, q.Count());
            Assert.AreEqual(1, r.Count);
        }
        
    }
}