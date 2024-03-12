using Xunit;

namespace XTA.Tests
{
    public class CalculatorTest
    {
        // Calculator is static so no need for constructor

        // A "Fact" in xunit is like saying that a test is always true. More importantly they don't take any parameters and their
        // purpose is testing invariant conditions (test environment,execution order, things related to the test class itself and not the actual tests)

        [Fact]
        public void Add()
        {
            double a = 420;
            double b = 69;
            double expected = 489;
            var actual = Calculator.Add(a, b);
            Assert.Equal(expected, actual,0); // 3rd value is tolerance meaning difference.
        }

        [Fact]
        public void Subtract()
        {
            double a = 2;
            double b = 1;
            double expected = 1;
            var actual = Calculator.Subtract(a, b);
            Assert.Equal(expected, actual, 0); // 3rd value is tolerance meaning difference.
        }

        // Here we have a "theory" aka a way to do tests with parameters. Each InlineData defines values matching the arguments of the function and essentially
        // defines a single test. There are others too (ClassData,PropertyData), but all they do is just make it so you can put values inside of a class or property, nothing else.

        [Theory(DisplayName = "A divided by B. In the case that B is zero, we should see A being returned.")]
        [InlineData(1,1,1)]
        [InlineData(2,0,2)]
        [InlineData(10,5,2)]
        public void Divide(double a,double b, double expected)
        {
            var value = Calculator.Divide(a, b);
            Assert.Equal(expected, value,0);
        }


        // Here we have a test that is always skipped. If you add the Skip attribute with whatever description you want, it skips the test.
        // If you want a specific skip condition you should specify with SkipOn and then write some code in the function. The actual values of these attributes
        // doesn't actually matter. You can skip any test you want by specifying Skip or SkipOn.


        [Fact(Skip = "This is a test that is always skipped. Why? I don't know. But i don't like it.")]
        public void MultiplySkipped()
        {
            double a = 1;
            double b = 0;
            double expected = 0;
            var actual = Calculator.Multiply(a, b);
            Assert.Equal(expected , actual, 0);
        }

        // I feel bad for skipping Multiply above,so we will do it here.

        [Theory(DisplayName = "A*B baby")]
        [InlineData(5,3,15)]
        public void Multiply(double a,double b,double expected)
        {
            var actual = Calculator.Multiply(a, b);
            Assert.Equal(expected, actual, 0);
        }

    }
}