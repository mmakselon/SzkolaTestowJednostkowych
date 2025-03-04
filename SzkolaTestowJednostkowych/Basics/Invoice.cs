using System;
using System.Collections.Generic;

namespace SzkolaTestowJednostkowych.Basics
{
    public class Invoice
    {
        public IList<InvoicePosition> Positions { get; set; }

        public void AddPosition(InvoicePosition position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position));

            if (!position.IsAvailable)
                throw new Exception("Position unavailable");

            Positions.Add(position);
        }
    }
}
