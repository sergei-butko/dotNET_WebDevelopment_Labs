using System;
using NUnit.Framework;
using FluentAssertions;
using Library_Lab1_MyStack;

namespace MyStack.Tests
{
    public class Tests
    {
        [Test]
        public void MyStack_NewStackIsEmpty()
        {
            var stack = new MyStack<string>();
            stack.IsEmpty.Should().BeTrue();
        }

        [Test]
        [TestCase("")]
        [TestCase("a")]
        [TestCase("abc")]
        public void MyStack_StackIsNotEmpty(string elem)
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            stack.Push(elem);
            // Assert
            stack.IsEmpty.Should().BeFalse();
        }

        [Test]
        public void MyStack_NewStackSizeIsZero()
        {
            // Arrange + Act
            var stack = new MyStack<string>();
            // Assert
            stack.Size.Should().Be(0);
        }

        [Test]
        public void MyStack_Size_AfterPushes()
        {
            // Arrange
            var stack = new MyStack<string>();
            
            // Act
            stack.Push("abc");
            // Assert
            stack.Size.Should().Be(1);
            
            // Act
            stack.Push("ABC");
            // Assert
            stack.Size.Should().Be(2);
        }

        [Test]
        public void MyStack_PushNullElem_GetArgumentNullException()
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            Action result = () => { stack.Push(null); };
            // Assert
            result.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [TestCase("")]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("!@#$%")]
        [TestCase("2+0-2*1/0")]
        public void MyStack_PushElem_StackIsNotEmpty(string elem)
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            stack.Push(elem);
            // Assert
            stack.Should().NotBeEmpty();
        }
        
        [Test]
        public void MyStack_PushElements_StackIsNotEmpty()
        {
            // Arrange
            var elements = new[] {"", "a", "abc", "!@#$%", "2+0-2*1/0"};
            var stack = new MyStack<string>();
            // Act
            foreach (var elem in elements)
            {
                stack.Push(elem);
            }
            // Assert
            stack.Should().NotBeEmpty();
        }

        [Test]
        [TestCase("")]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("!@#$%")]
        [TestCase("2+0-2*1/0")]
        public void MyStack_PushElem_ReturnElem(string elem)
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            stack.Push(elem);
            // Assert
            stack.Peek().Should().Be(elem);
        }
        
        [Test]
        public void MyStack_ReturnElements()
        {
            // Arrange
            var elements = new[] {"", "a", "abc", "!@#$%", "2+0-2*1/0"};
            var stack = new MyStack<string>();
            
            // Act
            foreach (var elem in elements)
            {
                stack.Push(elem);
            }

            var i = 1;
            foreach (var elem in stack)
            {
                // Assert
                elem.Should().Be(elements[^i]);
                i++;
            }
        }

        [Test]
        public void MyStack_PopFromEmptyStack()
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            Action result = () => { stack.Pop(); };
            // Assert
            result.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void MyStack_PopFromStackWithOneElem()
        {
            // Arrange
            var stack = new MyStack<string>();
            stack.Push("abc");
            // Act
            stack.Pop();
            // Assert
            stack.Should().BeEmpty();
        }
        
        [Test]
        public void MyStack_PopFromStack()
        {
            // Arrange
            var elements = new[] {"", "a", "abc", "!@#$%", "2+0-2*1/0"};
            var stack = new MyStack<string>();
            
            foreach (var elem in elements)
            {
                stack.Push(elem);
            }
            // Act + Assert
            stack.Peek().Should().Be(elements[^1]);
            
            // Act
            stack.Pop();
            // Assert
            stack.Peek().Should().Be(elements[^2]);
        }
        
        [Test]
        public void MyStack_PeekOfEmptyStack()
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            Action result = () => { stack.Peek(); };
            // Assert
            result.Should().Throw<InvalidOperationException>();
        }
        
        [Test]
        [TestCase("")]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("!@#$%")]
        [TestCase("2+0-2*1/0")]
        public void MyStack_PeekOfStackWithOneElem(string elem)
        {
            // Arrange
            var stack = new MyStack<string>();
            // Act
            stack.Push(elem);
            // Assert
            stack.Peek().Should().Be(elem);
        }
        
        [Test]
        public void MyStack_PeekOfStack()
        {
            // Arrange
            var elements = new[] {"", "a", "abc"};
            var stack = new MyStack<string>();
            
            // Act
            foreach (var elem in elements)
            {
                stack.Push(elem);
            }
            
            // Assert
            stack.Peek().Should().Be(elements[^1]);
        }
        
        [Test]
        [TestCase(new Char[] { })]
        [TestCase(new [] { 'a', 'b', 'c', '!', '+', '=' })]
        [TestCase(new [] { 'G', '5', '*', '!', 'e', '_' })]
        public void GetEnumerator_EnumerateItemsInStack_ReturnItemsFromList(Char[] elements)
        {
            // Arrange
            var stack = new MyStack<Char>();
            foreach (var elem in elements)
            {
                stack.Push(elem);
            }

            var i = 1;
            // Act
            foreach (var elem in stack)
            {
                // Assert
                elem.Should().Be(elements[^i]);
                i++;
            }
        }
    }
}