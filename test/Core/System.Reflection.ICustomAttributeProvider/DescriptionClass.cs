using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FluentMethods.UnitTests
{
    [Description("FizzClass")]
    public class DescriptionClass
    {
        [Description("FizzMethod")]
        public void DescriptionMethod([Description("FizzParameter")]int x)
        {
            DescriptionEvent?.Invoke(this, EventArgs.Empty);
        }

        [Description("FizzProperty"), Required, RegularExpression("^\\w+$")]
        public string DescriptionProperty { get; set; }

        [Description("FizzEvent")]
        public event EventHandler DescriptionEvent;

        [Description("FizzField")]
        public string DescriptionField;

        [Description("FizzIndexer")]
        public string this[int index]
        {
            get { return null; }
            set { }
        }
    }
}
