namespace ModelOfLAN
{
    /// <summary>
    /// type of operating system
    /// </summary>
    public enum OS { Windows, Linux, OS_X};

    /// <summary>
    /// computer of local network
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="abbr">type of operating system</param>
        public Computer(char abbr)
        {
            switch (abbr)
            {
                case 'w':
                    {
                        this.OperatingSystem = OS.Windows;
                        this.healthPoints = 60;
                        break;
                    }
                case 'l':
                    {
                        this.OperatingSystem = OS.Linux;
                        this.healthPoints = 70;
                        break;
                    }
                case 'o':
                    {
                        this.OperatingSystem = OS.OS_X;
                        this.healthPoints = 50;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// type of operating system
        /// </summary>
        public OS OperatingSystem { get; set; }

        /// <summary>
        /// ID of computer in local network
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// checks the health of computer
        /// </summary>
        /// <returns></returns>
        public bool IsInfected() => this.isInfected;

        /// <summary>
        /// simulates a viral attack on the computer
        /// </summary>
        /// <param name="damagePoints">the power of viral attacks</param>
        public void Infect(int damagePoints)
        {
            if (damagePoints >= healthPoints)
            {
                isInfected = true;
            }
        }

        private int healthPoints;
        private bool isInfected;
    }
}
