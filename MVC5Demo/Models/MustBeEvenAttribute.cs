using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Demo.Models
{
    public class MustBeEvenAttribute : DataTypeAttribute
    {
        public MustBeEvenAttribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入偶數";
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