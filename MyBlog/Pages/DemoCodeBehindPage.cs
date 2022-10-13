using Microsoft.AspNetCore.Components;

namespace MyBlog.Pages
{
    public partial class DemoCodeBehindPage
    {
        [Parameter]
        public int Id { get; set; }

        public string SomeText { get; set; } 

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SomeText = "Blah blah blah!";
        }
    }
}
