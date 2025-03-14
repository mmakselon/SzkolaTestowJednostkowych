using System;

namespace SzkolaTestowJednostkowych.Basics
{
    public class Offer
    {
        public string Title { get; private set; }

        public event EventHandler<Guid> OfferChanged;

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            Title = title;

            OnOfferChanged(Guid.NewGuid());
        }

        private void OnOfferChanged(Guid id)
        {
            OfferChanged?.Invoke(this, id);
        }
    }
}
