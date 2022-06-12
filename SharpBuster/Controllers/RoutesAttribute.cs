namespace SharpBuster.Controllers
{
    internal class RoutesAttribute : Attribute
    {
        private string v;

        public RoutesAttribute(string v)
        {
            this.v = v;
        }
    }
}