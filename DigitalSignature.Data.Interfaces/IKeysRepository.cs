using DigitalSignature.Data.Entities;

namespace DigitalSignature.Data.Interfaces
{
    public interface IKeysRepository
    {
        PublicKey GetPublicKey();
        PrivateKey GetPrivateKey();
        void SetPublicKey(PublicKey publicKeyNew);
        void SetPrivateKey(PrivateKey privateKeyNew);
    }
}
