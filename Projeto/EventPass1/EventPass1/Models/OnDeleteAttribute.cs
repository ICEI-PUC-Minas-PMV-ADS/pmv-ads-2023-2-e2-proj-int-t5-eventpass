using Microsoft.EntityFrameworkCore;

namespace EventPass1.Models
{
    internal class OnDeleteAttribute : Attribute
    {
        public OnDeleteAttribute(DeleteBehavior noAction)
        {
            NoAction = noAction;
        }

        public DeleteBehavior NoAction { get; }
    }
}