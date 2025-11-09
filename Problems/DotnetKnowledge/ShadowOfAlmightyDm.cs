using Xunit;

namespace Problems.DotnetKnowledge;

public sealed class ShadowOfAlmightyDm
{
    public void DoIt(string source, string target)
    {
        unsafe
        {
            fixed (char* sourcePtr = source)
            fixed (char* targetPtr = target)
            {
                var length = Math.Min(source.Length, target.Length) * sizeof(char);
                Buffer.MemoryCopy(targetPtr, sourcePtr, length, length);
            }
        }
    }

    [Fact]
    public void Test()
    {
        DoIt("this is a magic bro", "good luck have fun!!!");

        Assert.Equal("good luck have fun!", "this is a magic bro");

        var text = "this is a magic bro";
        Assert.Equal("good luck have fun!", text);

        var shortText = "abc";
        DoIt(shortText, "hello world");
        Assert.Equal("hel", shortText);
    }
}