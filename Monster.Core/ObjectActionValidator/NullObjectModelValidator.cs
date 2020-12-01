using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Monster.Core.Extensions;
using Monster.Core.Filters;

namespace Monster.Core.ObjectActionValidator
{
    public class NullObjectModelValidator : IObjectModelValidator
    {

        public void Validate(
           ActionContext actionContext,
           ValidationStateDictionary validationState,
           string prefix,
           object model)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                actionContext.ModelValidator(prefix, model);
                return;
            }
        }
    }
}
