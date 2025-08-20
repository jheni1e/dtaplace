using Xunit;

namespace dtaplace.Tests;

public class AuthTest
{
    [Theory]
    [InlineData("minhasenhaA", "minhasenhaA", true)]
    [InlineData("12345678", "sdfjkadsjh", false)]
    [InlineData("", "a", false)]
    [InlineData("acomplexpassword314", "acomplexpassword314", true)]
    public void TestPasswordHash(string senha1, string senha2, bool result)
    {
        var hasher = new PBKDF2PasswordService();

        var hash = hasher.Hash(senha1);
        var ok = hasher.Compare(senha2, hash);
        Assert.Equal(result, ok);
    }
}