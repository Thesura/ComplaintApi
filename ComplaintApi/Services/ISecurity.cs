using ComplaintApi.Models;

namespace ComplaintApi.Services
{
    public interface ISecurity
    {
        string hash(string password, byte[] salt);

        bool authenticate(UserMasterDto user, string username, string password);

    }
}