namespace Domain.Models
{
    public class Argument
    {
        public Parameter Param { get; set; }

        public object Value { get; set; }

        public Argument(string paramName, object paramValue)
        {
            Param = new Parameter
            {
                Name = paramName
            };
            Value = paramValue;
        }

        public Argument()
        {
            
        }

     }
}