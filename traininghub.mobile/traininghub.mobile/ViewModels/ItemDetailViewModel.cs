using System;
using traininghub.mobile.models;

namespace traininghub.mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Game Item { get; set; }

        public ItemDetailViewModel(Game item = null)
        {
            Title = item?.OrganizerName;
            Item = item;
        }
    }
}
