using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Core.Enums
{
    public enum ResponseType
    {
        ServerError = 1,
        LoginExpiration = 302,
        ParametersLack = 303,
        TokenExpiration,
        PINError,
        NoPermissions,
        NoRolePermissions,
        LoginError,
        AccountLocked,
        LoginSuccess,
        SaveSuccess,
        AuditSuccess,
        OperSuccess,
        RegisterSuccess,
        ModifyPwdSuccess,
        EidtSuccess,
        DelSuccess,
        QuerySuccess,
        NoKey,
        NoKeyQuery,
        NoKeyDel,
        KeyError,
        Other
    }
}
