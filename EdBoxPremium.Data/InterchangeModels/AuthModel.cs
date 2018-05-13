using System.Collections.Generic;

namespace EdBoxPremium.Data.InterchangeModels
{
    public class AuthModel
    {
        public Administration_AccessCredential AccessCredential { get; set; }
        public List<Administration_AccessCredentialRole> AccessRoles { get; set; }
    }
}
