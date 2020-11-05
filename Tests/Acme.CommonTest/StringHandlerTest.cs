using System;
using Xunit;
using Acme.Common;



namespace Acme.CommonTest
{
    public class StringHandlerTest
    {
        [Fact (Skip = "specific reason")]
        public void InsertSpacesTest()
        {
            // Given
            string expected = "Lg Television";
           
            var actual = StringHandler.InsertSpaces("LgTelevision");

            Assert.Equal(expected, actual);
            
        }
        [Theory (Skip = "specific reason")]
        [InlineData("Nick Chlam", "Nick Chlam")]
        [InlineData("AcmeCorporation", "Acme Corporation")]
        [InlineData("KingSooper", "King Sooper")]
        [InlineData(" DiamondCorp", "Diamond Corp")]
        public void InsertSpacesWithSpaceTest(string source, string expected)
        {
            // Given
           
            var actual = StringHandler.InsertSpaces(source);

            // Assert
            Assert.Equal(expected, actual);
            
        }

        [Theory (Skip = "specific reason")]
        [InlineData("Nick Chlam", "Nick Chlam")]
        [InlineData("AcmeCorporation", "Acme Corporation")]
        [InlineData("KingSooper", "King Sooper")]
        [InlineData(" DiamondCorp", "Diamond Corp")]
        [InlineData("AcmeCorporations", "Acme Corporations")]
        [InlineData("KingSoopers", "King Soopers")]
        [InlineData(" DiamondCorps", "Diamond Corps")]
        public void InsertSpaceExtensionMethodTest(string source, string expected)
        {
        //Given
        var actual = source.InsertSpace();
        //When
        
        //Then
        Assert.Equal(expected, actual);
        }
    }
}
