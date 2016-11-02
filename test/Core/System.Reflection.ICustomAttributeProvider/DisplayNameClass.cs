using System;
using System.ComponentModel;

namespace FluentMethods.UnitTests
{
    [DisplayName("BuzzClass")]
    public class DisplayNameClass
    {
        [DisplayName("BuzzMethod")]
        public void DisplayNameMethod(int x)
        {
            DisplayNameEvent?.Invoke(this, EventArgs.Empty);
        }

        [DisplayName("BuzzProperty")]
        public string DisplayNameProperty { get; set; }

        [DisplayName("BuzzEvent")]
        public event EventHandler DisplayNameEvent;

        public string DisplayNameField;

        [DisplayName("BuzzIndexer")]
        public string this[int index]
        {
            get { return null; }
            set { }
        }
    }
}
