namespace Services.Exceptions
{
    public class BelissimoCloneWPFException : Exception
    {
        public int Code { get; set; }
        public BelissimoCloneWPFException(int Code,string massage):base(massage)
        {
            this.Code = Code;
        }
    }
}
