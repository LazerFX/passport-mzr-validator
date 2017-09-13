namespace Mzr.Validation {
    public class MzrOutput
    {
        public bool Valid { get; set; }
        public MzrValidationField[] Messages { get; set; }
    }
}