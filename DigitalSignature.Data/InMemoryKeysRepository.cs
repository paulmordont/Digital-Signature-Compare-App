using DigitalSignature.Data.Entities;
using DigitalSignature.Data.Interfaces;

namespace DigitalSignature.Data
{
    public class InMemoryKeysRepository : IKeysRepository
    {
        private PublicKey publicKey;

        private PrivateKey privateKey;

        public PublicKey GetPublicKey()
        {
            return publicKey;
        }

        public PrivateKey GetPrivateKey()
        {
            return privateKey;
        }

        public void SetPublicKey(PublicKey publicKeyNew)
        {
            publicKey = publicKeyNew;
        }

        public void SetPrivateKey(PrivateKey privateKeyNew)
        {
            privateKey = privateKeyNew;
        }
    }
}
