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
                    Message = "Data is valid."
                };
            }
            return new MzrOutput
            {
                Valid = false,
                Message = "Data did not match test pattern."
            };
        }
    }
}