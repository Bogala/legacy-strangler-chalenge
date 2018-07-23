using legacy_business_logic.Entities;

namespace legacy_business_logic.Providers
{
    public interface ISocialReferentialProvider
    {
        SocialInfo GetSocialInfoByUID(string socialId);
    }

    public class SocialReferentialProvider : ISocialReferentialProvider
    {
        public SocialInfo GetSocialInfoByUID(string socialId)
        {
            return new SocialInfo()
            {
                SocialId = socialId,
                MainAddress = new Address
                {
                    AddressLine1 = "The White House",
                    AddressLine2 = "1600 Pennsylvania Avenue",
                    TownCity = "Washington",
                    AreaCountry = $"DC#{socialId}",
                    PostalCode = "America"
                }
            };
        }
    }
}
