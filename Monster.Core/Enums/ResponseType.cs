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
        NotFound,
        NoPermissions,
        NoRolePermissions,
        LoginError,
        AccountLocked,
        NoKey,
        NoKeyQuery,
        NoKeyDel,
        KeyError,
        Other,
        LoginSuccess = 2000,
        SaveSuccess,
        AuditSuccess,
        OperSuccess,
        RegisterSuccess,
        ModifyPwdSuccess,
        EidtSuccess,
        DelSuccess,
        QuerySuccess
    }
}
