using EdBoxPremium.Core;
using EdBoxPremium.Library.Dictionary;
using System.Collections.Generic;
using System.Linq;
using EdBoxPremium.Library;

namespace EdBoxPremium.Data.InterchangeModels
{
    public class Mocks
    {
        private const string MockSalt = "edboxpremium";

        public static List<AuthModel> MockCredentials
        {
            get
            {
                var listOfCreds = new List<AuthModel>
                {
                    new AuthModel()
                    {
                        AccessCredential = new Administration_AccessCredential()
                        {
                            Id = 0,
                            IsDeleted = false,
                            PasswordData = Encryption.SaltEncrypt("accessentry", MockSalt),
                            PasswordSalt = MockSalt,
                            Username = "administrator@edboxpremium.com"
                        }, 
                        AccessRoles = EnumDictionary.GetList<RolePermissions>().ToList().Select(rp => new Administration_AccessCredentialRole()
                        {
                            CredentialId = 0,
                            IsDeleted = false, 
                            PermissionId = rp.ItemId
                        }).ToList()
                    },
                    new AuthModel()
                    {
                        AccessCredential = new Administration_AccessCredential()
                        {
                            Id = 1,
                            IsDeleted = false,
                            PasswordData = Encryption.SaltEncrypt("edboxaccess12345", MockSalt),
                            PasswordSalt = MockSalt,
                            Username = "tagopr@edboxpremium.com"
                        },
                        AccessRoles = EnumDictionary.GetList<RolePermissions>().ToList().Where(x => x.ItemId == (int)RolePermissions.TagOpr).Select(rp => new Administration_AccessCredentialRole()
                        {
                            CredentialId = 1,
                            IsDeleted = false,
                            PermissionId = rp.ItemId
                        }).ToList()
                    },
                    new AuthModel()
                    {
                        AccessCredential = new Administration_AccessCredential()
                        {
                            Id = 2,
                            IsDeleted = false,
                            PasswordData = Encryption.SaltEncrypt("edboxaccess12345", MockSalt),
                            PasswordSalt = MockSalt,
                            Username = "attendanceopr@edboxpremium.com"
                        },
                        AccessRoles = EnumDictionary.GetList<RolePermissions>().ToList().Where(x => x.ItemId == (int)RolePermissions.AttendanceOpr).Select(rp => new Administration_AccessCredentialRole()
                        {
                            CredentialId = 2,
                            IsDeleted = false,
                            PermissionId = rp.ItemId
                        }).ToList()
                    }
                }.ToList();

                return listOfCreds;
            }
        }
    }
}