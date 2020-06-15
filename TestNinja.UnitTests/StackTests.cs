using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        private Fundamentals.Stack<string> stack;
        [SetUp]
        public void SetUp()
        {
             stack = new Fundamentals.Stack<string>();
        }
        [Test]
        public void push_whenObjectNullInsert_throwNullException()
        {
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }
        [Test]
        public void push_whenStringInsert_AddList()
        {
            //System.Collections.Generic.Stack<string> a = new System.Collections.Generic.Stack<string>();
            //a.Push("Hi");
            //  Fundamentals.Stack<string> result = new Fundamentals.Stack<string>();
            stack.Push("Hi");
                Assert.That(stack.Count,Is.EqualTo(1));
        }
        [Test]
        public void EmptyStack_stackCount_ReturnZero()
        {
            Assert.That(stack.Count, Is.EqualTo(0));

        }
        [Test]
        public void LoadedStack_stackCount_ReturnLength()
        {
            stack.Push("Hi");
            stack.Push("Hello");
            Assert.That(stack.Count, Is.EqualTo(2));

        }
        [Test]
        public void Pop_StackCountZero_throwException()
        {
            Assert.Throws<InvalidOperationException>(()=>stack.Pop());
        }
        [Test]
        public void Pop_LoadedStack_RemoveInsrted()
        {
            stack.Push("Hi");
            stack.Push("Hello");
            string result = stack.Pop();
            Assert.That(result, Is.EqualTo("Hello"));
            int count = stack.Count;
            Assert.That(count, Is.EqualTo(1));
        }
        [Test]
        public void Peek_StackCountZero_throwException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Peek_LoadedStack_ReturnLastElement()
        {
            stack.Push("Hi");
            stack.Push("Hello");
            string result = stack.Peek();
            int count = stack.Count;
            Assert.That(result, Is.EqualTo("Hello"));





        }
    }

}
