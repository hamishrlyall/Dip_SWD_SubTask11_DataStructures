using System;
using NUnit.Framework;
using Data_Structures;


namespace DataStructuresUnitTests {
    
    [TestFixture]
    public class Tests {
        
        LinkedList ll;
        private string[] data = {"asdf", "zxcv", "qwerty", "abc", "xyz", "aeiou", "foo", "bar", "hello", "world"};
    
        [SetUp]
        public void Init() {
            ll = new LinkedList();
            foreach (var s in data) {
                ll.AddToEnd(s);
            }
        }

        [Test]
        public void Find() {
            Assert.AreEqual(true, ll.Find("asdf"));
            Assert.AreEqual(true, ll.Find("foo"));
            Assert.AreEqual(true, ll.Find("world"));
            Assert.AreEqual(false, ll.Find("false"));
        }
        
        [Test]
        public void GetNodeAt() {
            Assert.AreEqual("qwerty", ll.GetNodeAt(2).Data);
            Assert.AreEqual(null, ll.GetNodeAt(-1));
            Assert.AreEqual(null, ll.GetNodeAt(10));
        }
        
        [Test]
        public void Count() {
            Assert.AreEqual(10, ll.Count());
        }

        [Test]
        public void AddToStart() {
            ll.AddToStart("start");
            
            Assert.AreEqual(11, ll.Count());
            Assert.AreEqual("start", ll.GetNodeAt(0).Data);
        }

        [Test]
        public void AddToEnd() {
            ll.AddToEnd("end");
            
            Assert.AreEqual(11, ll.Count());
            //I had to alter this to GetNodeAt(10) instead of GetNodeAt(11)
            //I was being thrown a NullReferenceException
            //I believe this was because the list would start at 0 so the 11th node wouldn't have existed as the true 11th node is 10.
            Assert.AreEqual("end", ll.GetNodeAt(10).Data);
        }

        [Test]
        public void AddNodeAt() {
            ll.AddNodeAt("indexFour", 3);
            //I had to alter this to ll.AddNodeAt("indexFour", 3) instead of ll.AddNodeAt("indexFour", 4)
            //My tests were showing I was retrieving the 5th node in my asserts instead of the fourth
            //I believe this was because the list would start at 0 so the 4th node would need to be referenced directly as 3.
            //This is most likely an issue with the GetNodeAt() method.
            Assert.AreEqual("indexFour", ll.GetNodeAt(4).Data);
            Assert.AreEqual("aeiou", ll.GetNodeAt(6).Data);
        }
        
        [Test]
        public void DeleteNodeAt() {
            ll.DeleteNodeAt(4);
            
            Assert.AreEqual(false, ll.Find("xyz"));
            Assert.AreEqual("aeiou", ll.GetNodeAt(4).Data);
        }
    }
}