using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTservice.Services
{
    public interface I_MockPetServices
    {
        int GenMerchantAbility(string nickname, string species, string colour);
        int GenPwrLevel(string nickname, string species);
    }
}
