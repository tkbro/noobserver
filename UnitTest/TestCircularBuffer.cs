namespace UnitTest
{
  using Xunit;

  public class TestCircularBuffer
  {
    [Theory]
    [InlineData(0)]
    public void CircularBuffer_Produce_CorrectContent(int value)
    {
      Assert.True(value == 1);
    }
  }
}
