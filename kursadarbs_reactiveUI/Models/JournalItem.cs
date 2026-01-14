using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace kursadarbs_reactiveUI.Models
{
    public class JournalItem : ReactiveObject
    {
        public string? _title;
        public string? Title
        {
            get { return _title; }
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }
        public string? Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;



    }
}
