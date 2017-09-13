namespace Mzr.Validation
{
    public class Validator
    {
        public MzrInput Input { get; set; }
        public MzrOutput Valid {get { return Validate(); } }

        public Validator(MzrInput input)
        {
            this.Input = input;
        }

        public MzrOutput Validate() {
            if (Input.Mzr == "testvalue")
            {
                return new MzrOutput
                {
                    Valid = true,
                    Messages = new MzrValidationField[]{}
                };
            }
            return new MzrOutput
            {
                Valid = false,
                Messages = new MzrValidationField[]{
                    new MzrValidationField { Id = 0, FieldName = "Mzr", Message = "Mzr Value does not match" }
                }
            };
        }
    }
}