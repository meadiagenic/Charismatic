namespace Charismatic.Tests.DynamicValueTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using FluentAssertions;

    [TestFixture]
    public class ConversionTestFixture
    {
        [Test]
        public void Can_Convert_String_To_Boolean()
        {
            dynamic t = new DynamicValue("true");
            bool testt = t;
            testt.Should().BeTrue();

            dynamic f = new DynamicValue("false");
            bool testf = f;
            testf.Should().BeFalse();
        } 

        [Test]
        public void Can_Convert_Int_To_Boolean()
        {
            dynamic t = new DynamicValue(1);
            bool tTest = t;
            tTest.Should().BeTrue();


            dynamic t2 = new DynamicValue(0);
            bool t2Test = t2;
            t2Test.Should().BeFalse();
        }

        [Test]
        public void Can_Convert_String_To_Double()
        {
            dynamic d = new DynamicValue("100.53");
            double dd = d;
            dd.Should().Equals(100.53);
        }
    }
}
