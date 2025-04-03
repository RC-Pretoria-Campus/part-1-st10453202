using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

class Program
{
    private static bool continueConversation;

    static void Main(string[] args)
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        synth.Volume = 100;
        synth.Rate = 0;



        // Dictionary for cybersecurity responses
        Dictionary<string, string> cybersecurityResponses = new Dictionary<string, string>
        {
            { "password safety", "Password safety is important. Always use complex passwords and never reuse them across different sites. Consider using a password manager." },
            { "phishing", "Phishing is a type of cyber attack where attackers attempt to trick you into giving up sensitive information like passwords. Always verify the source before clicking on links or providing personal data." },
            { "safe browsing", "Safe browsing means being cautious when visiting websites. Always ensure the website is secure by checking for 'https' in the URL and avoid clicking on suspicious links." },
            { "how are you?", "I'm doing great, thank you! How can I assist you today?" },
            { "what's your purpose?", "My purpose is to help you stay safe online by providing cybersecurity tips!" },
            { "what can i ask you about?", "You can ask me about password safety, phishing, safe browsing, data protection, malware, social engineering, and two-factor authentication." },
            { "data protection", "Data protection involves safeguarding sensitive information from unauthorized access. Always ensure that your personal data is encrypted and avoid sharing sensitive details over insecure channels." },
            { "malware", "Malware is malicious software designed to damage, disrupt, or gain unauthorized access to computer systems. To protect yourself, ensure your antivirus software is up to date and avoid downloading files from untrusted sources." },
            { "two-factor authentication", "Two-factor authentication (2FA) adds an extra layer of security by requiring two forms of identification. This could be something you know (like a password) and something you have (like a phone or an authentication app)." },
            { "social engineering", "Social engineering is a type of attack where attackers manipulate you into revealing personal information or performing actions that compromise your security. Be cautious about unsolicited requests for sensitive information." },
            { "vpn", "A Virtual Private Network (VPN) encrypts your internet connection and masks your IP address, making it harder for hackers to track your online activities. Use a VPN when accessing public Wi-Fi networks to protect your data." },
            { "ransomware", "Ransomware is a type of malware that locks your data or system until you pay a ransom. Always back up important files regularly and be cautious about downloading suspicious attachments or clicking on unknown links." },
            { "firewall", "A firewall is a security system that monitors and controls incoming and outgoing network traffic. It helps protect your computer from unauthorized access by blocking malicious activity." },
            { "encryption", "Encryption is the process of converting information into a secure format that cannot be read without the proper decryption key. It is essential for protecting sensitive data during transmission over the internet." },
            { "security patch", "A security patch is an update designed to fix vulnerabilities in software or operating systems. Always install security updates as soon as they are available to protect your device from known threats." },
            { "identity theft", "Identity theft occurs when someone uses your personal information without your permission, typically for fraudulent purposes. Protect your identity by using strong passwords, monitoring your financial accounts, and being cautious with your personal data." },
            { "zero-day exploit", "A zero-day exploit refers to a security vulnerability in software that is unknown to the vendor. Since there are no patches available, these vulnerabilities are often exploited by hackers before the issue is fixed." },
            { "brute-force attack", "A brute-force attack is a method used to gain unauthorized access to an account by systematically trying every possible combination of characters until the correct one is found. Strong passwords can protect against such attacks." },
            { "spyware", "Spyware is malicious software that secretly gathers user information without their consent. To protect yourself, use reliable antivirus software and avoid downloading untrusted programs." },
            { "adware", "Adware is software that automatically displays or downloads advertisements to your device. While often not harmful, it can be intrusive and slow down your system. Be cautious of free software that includes adware." },
            { "botnet", "A botnet is a network of infected computers controlled by a hacker to carry out cyberattacks such as DDoS (Distributed Denial of Service). Protect your devices with antivirus software and firewalls." },
            { "denial of service attack", "A Denial of Service (DoS) attack is a malicious attempt to disrupt the normal traffic of a server, service, or network by overwhelming it with a flood of internet traffic. It's often used to cause outages." },
            { "data breach", "A data breach occurs when unauthorized individuals gain access to confidential or protected information. Always change your passwords if you suspect your data has been compromised, and monitor your accounts for unusual activity." },
            { "patch management", "Patch management involves regularly updating software to fix security vulnerabilities. Always ensure your operating system, browsers, and other software are up to date to protect against exploits." },
            { "social media security", "Social media security involves using best practices to protect your online presence. This includes using strong, unique passwords for each platform, being mindful of the information you share, and enabling two-factor authentication." },
            { "physical security", "Physical security involves protecting your hardware from unauthorized access, theft, or damage. Use locks, encrypt sensitive information, and ensure that your devices are stored securely when not in use." },
            { "internet of things (iot)", "The Internet of Things (IoT) refers to devices that connect to the internet, such as smart home devices. It's important to secure these devices with strong passwords and keep their software updated to avoid vulnerabilities." },
            { "cloud security", "Cloud security is the practice of protecting data stored online in the cloud. Ensure that you use strong authentication methods and that your cloud provider offers proper encryption for data storage and transmission." },
            { "multi-factor authentication", "Multi-factor authentication (MFA) is an advanced form of two-factor authentication that requires multiple forms of identification, like something you know (a password), something you have (a smartphone), and something you are (biometrics)." },
            { "patch Tuesday", "Patch Tuesday refers to the second Tuesday of every month, when Microsoft releases security patches for its products. It's a good idea to stay up to date with these updates to ensure your system is secure." },
            { "ssl certificate", "An SSL (Secure Sockets Layer) certificate is a digital certificate that authenticates a website's identity and encrypts information sent to the server. It's important for ensuring secure communication on websites." },
            { "deep web", "The deep web is the part of the internet that is not indexed by search engines. This includes private databases, password-protected sites, and subscription-based content." },
            { "dark web", "The dark web is a small portion of the deep web where illegal activities occur. It's important to be aware of the risks associated with it, such as encountering scams or illegal content." },
           
            { "ethical hacking", "Ethical hacking involves authorized testing of computer systems to identify vulnerabilities and improve security. Ethical hackers, also known as white hats, use their skills to protect systems from malicious hackers." }
        };

        
        DisplayHeader();
        DisplayASCIIArt();
        Console.WriteLine("Chatbot : Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
        synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online");

        
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"Hello {userName}! Welcome to the Cybersecurity Awareness Bot.");
        Console.WriteLine();

        bool continueConversation = true;
        while (continueConversation)
        {
            Console.WriteLine("You can ask me questions about cybersecurity topics like 'password safety', 'phishing', 'data protection', 'malware', 'vpn', and more.");
            Console.WriteLine("Ask me something:");
            string userQuery = Console.ReadLine();

            
            RespondToQuery(userQuery, synth, cybersecurityResponses);

            // Ask if the user wants to continue
            Console.WriteLine("\nPress Enter any key to continue with another question or type '0' to end the program.");
            string userChoice = Console.ReadLine(); 

            if (userChoice == "0")
            {
                continueConversation = false; // End the conversation
                Console.WriteLine("Goodbye! Stay safe online.");
            }
            else
            {
                // Continue to the next question if user presses Enter
                Console.WriteLine("Let's continue...");
            }
        }
    }

    // Method to handle user queries based on the dictionary
    static void RespondToQuery(string query, SpeechSynthesizer synth, Dictionary<string, string> cybersecurityResponses)
    {
        // Convert the query to lowercase for easier matching
        query = query.ToLower();

        // Check if the query matches a key in the dictionary
        if (cybersecurityResponses.ContainsKey(query))
        {
            Console.WriteLine(cybersecurityResponses[query]);
            synth.Speak(cybersecurityResponses[query]); // Respond with speech
        }
        else
        {
            Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            synth.Speak("I didn't quite understand that. Could you rephrase?");
        }
    }

    // Method to display the header with colors and formatting
    static void DisplayHeader()
    {
        // Set background color and text color
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();  // Clear the console to apply the background color

        Console.WriteLine("===========================================================================================================================");
        Console.WriteLine("                                       Cybersecurity Awareness Bot                                                         ");
        Console.WriteLine("===========================================================================================================================");
        Console.ResetColor();  // Reset color for other parts of the UI
    }


    static void DisplayASCIIArt()
    {
        Console.WriteLine(@"

                 _______       __      __           ____          __      __    ____      __    __      _______                      __________
               /  _____  \    |  |    |  |         /    \        |  |    |  |  |     \   |  |  /   \   /  _____  \                   | 0    0 |
              |  |      \/    |  |    |  |        /  /\  \       |  |    |  |  |      \  |  |   \  /  |  |      \/                 [ |    *   | ]
              \  \______      |  |    |  |       /  /  \  \      |  |    |  |  |  | \  \ |  |   /_/   \  \______                     |    =   |
               \______   \    |  |____|  |      /  /____\  \     |  |    |  |  |  |  \  \|  |          \______   \                   |________|
                       \  |       ____   |     /   ______   \    |  |    |  |  |  |   \     |                  \  |                       |
               __      |  |   |  |    |  |    /  /        \  \   |  |____|  |  |  |    \    |            __    |  |                       |
              |  |____/  /    |  |    |  |   /  /          \  \  |          |  |  |     \   |           |  \__/  /                      / | \
               \_______ /     |__|    |__|  /__/            \__\  \________/   |__|      \__|            \_____ /                      /  |  \
                                                                                                                                      /   |   \
                _______     __      __          _____       ____________    ______       ______    ____________     __              _/    |    \_
               /  ____  \  |  |    |  |        /  _  \     |____    ____|  |   __  \   /  ___   \ |____    ____|   |  |                   |
              |  /    \ /  |  |    |  |       /  / \  \         |  |       |  |  \  |  | /    \ |      |  |        |  |                  / \
              |  |         |  |____|  |      /  /___\  \        |  |       |  |__/ /   | |    | |      |  |        |  |                 /   \
              |  |         |   ____   |     /   _____   \       |  |       |   __  \   | |    | |      |  |        |__|                /     \
              |  |         |  |    |  |    /  /       \  \      |  |       |  |  \  \  | |    | |      |  |         __                /       \
              |  \____/ \  |  |    |  |   /  /         \  \     |  |       |  |__/  |  |  \__/  |      |  |        /  \              /         \
              \_________/  |__|    |__|  /__/           \__\    |__|       |______ /    \______/       |__|        \__/           __/           \__
               

");

        Console.WriteLine("===========================================================================================================================");
        Console.WriteLine("                                                                                                                           ");
        Console.WriteLine("===========================================================================================================================");

        Console.ReadLine();

    }


}
