using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5Demo.Models
{
    public class MustBeEvenAttribute : DataTypeAttribute, IClientValidatable
    {
        public MustBeEvenAttribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入偶數";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessageString,
                ValidationType = "mustbeeven"
            };

            //rule.ValidationParameters["param1"] = "hello";
            //rule.ValidationParameters["param2"] = "world";

            yield return rule;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            int data = Convert.ToInt32(value);

            return (data % 2 == 0);
        }
    }
}