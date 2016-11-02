using System;
using System.ComponentModel.DataAnnotations;

namespace FluentMethods.UnitTests
{
    public class DisplayAnnotationClass
    {
        [Display(Name = "BuzzMethod",Description = "FizzMethod")]
        public void DisplayMethod([Display(Name = "BuzzParameter", Description = "FizzParameter")]int x)
        {
        }

        [Display(Name = "BuzzProperty",Description = "FizzProperty")]
        public string DisplayProperty { get; set; }

        [Display(Name = "BuzzField", Description = "FizzField")]
        public string DisplayField;

        public event EventHandler DisplayEvent;

        [Display(Name = "BuzzIndexer", Description = "FizzIndexer")]
        public string this[int index]
        {
            get { return null; }
            set { }
        }
    }
}
