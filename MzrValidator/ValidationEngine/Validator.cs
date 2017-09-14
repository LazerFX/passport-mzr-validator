using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mzr.ValidationEngine
{
    public class Validator<T> : IValidator<T>
    {
        public Func<T, ValidationStatus>[] Validations { get; set; }

        public Validator(Func<T, ValidationStatus>[] validations) {
            Validations = validations;
        }

        public ValidationResult[] Validate(T input) {
            var result = new List<ValidationResult>();

            foreach (var validation in Validations) {
                var interim = new ValidationResult("Field", "Error", ValidationStatus.Error);

                interim.Field = (from a in validation.Method.GetCustomAttributes()
                                  where a.GetType() == typeof(FieldAttribute)
                                  select ((FieldAttribute)a).FieldName).First();

                interim.Message = (from a in validation.Method.GetCustomAttributes()
                                  where a.GetType() == typeof(MessageAttribute)
                                  select ((MessageAttribute)a).Message).First();

                interim.Status = validation(input);

                result.Add(interim);
            }

            return result.ToArray();
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class FieldAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string fieldName;
        
        // This is a positional argument
        public FieldAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }
        
        public string FieldName
        {
            get { return fieldName; }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class MessageAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string messageString;
        
        // This is a positional argument
        public MessageAttribute(string messageString)
        {
            this.messageString = messageString;
        }
        
        public string Message
        {
            get { return messageString; }
        }
    }
}