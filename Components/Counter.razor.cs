using System.Diagnostics;

namespace BlazorApp.Components
{
    public partial class Counter
    {
        public int xx = 0;

        private void IncrementCount()
        {
            Debug.Print("BOOOM");
            xx++;
        }
    }
}
