using scaldasS5.Repositories;

namespace scaldasS5
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; set; }

        public App(PersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}