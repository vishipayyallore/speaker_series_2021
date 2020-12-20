using College.ApplicationCore.Common;

namespace ClientApps.Common.Utilities
{

    public static class AddressGenerator
    {

        static public string GenerateAddress()
        {
            return string.Format(Constants.GenerateAddress.FullAddress, 
                RandomNumberGenerator.GetRandomValue(8, 999), 
                NameGenerator.GenerateName(RandomNumberGenerator.GetRandomValue(1, 20)),
                NameGenerator.GenerateName(RandomNumberGenerator.GetRandomValue(1, 20)));
        }

    }

}
