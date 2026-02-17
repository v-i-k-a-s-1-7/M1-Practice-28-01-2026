using System; // Console, Exception

namespace ItTechGenie.M1.OOP.Q1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");       // ask user for input
            var lines = ConsoleInput.ReadLines();                               // read multi-line input

            var engine = new BankEngine();                                      // orchestrates operations
            engine.Run(lines);                                                  // execute commands
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            // Read until empty line for easy testing.
            var list = new System.Collections.Generic.List<string>();           // store lines
            while (true)
            {
                var line = Console.ReadLine();                                  // read one line
                if (string.IsNullOrWhiteSpace(line)) break;                     // stop on empty
                list.Add(line);                                                 // add line
            }
            return list.ToArray();                                              // return array
        }
    }

    public class BankEngine
    {
        private readonly System.Collections.Generic.Dictionary<int, BankAccount> _accounts = new(); // store accounts

        public void Run(string[] lines)
        {
            foreach (var raw in lines)                                          // process each line
            {
                var cmd = Command.Parse(raw);                                   // parse command structure

                if (cmd.Name == "ACC_CREATE")                                   // create account
                {
                    int id = int.Parse(cmd.Get("id"));                          // parse id
                    string name = cmd.Get("name");                              // get name
                    decimal opening = InputParser.ParseAmount(cmd.Get("opening")); // parse amount with symbols
                    _accounts[id] = new BankAccount(id, name, opening);         // create and store
                }
                else if (cmd.Name == "ACC_DEPOSIT")                             // deposit
                {
                    int id = int.Parse(cmd.Get("id"));                          // id
                    decimal amt = InputParser.ParseAmount(cmd.Get("amount"));   // amount
                    _accounts[id].Deposit(amt, cmd.Get("note"));                // ✅ calls TODO
                }
                else if (cmd.Name == "ACC_WITHDRAW")                            // withdraw
                {
                    int id = int.Parse(cmd.Get("id"));                          // id
                    decimal amt = InputParser.ParseAmount(cmd.Get("amount"));   // amount
                    _accounts[id].Withdraw(amt, cmd.Get("note"));               // ✅ calls TODO
                }
                else if (cmd.Name == "PRINT")                                   // print summary
                {
                    int id = int.Parse(cmd.Get("id"));                          // id
                    Console.WriteLine(_accounts[id].GetSummary());              // output
                }
            }
        }
    }

    public class BankAccount
    {
        private decimal _balance;                                               // encapsulated balance
        public int Id { get; }                                                  // read-only id
        public string HolderName { get; }                                        // read-only name

        public BankAccount(int id, string holderName, decimal opening)
        {
            Id = id;                                                            // assign
            HolderName = holderName;                                            // assign
            _balance = opening;                                                 // set opening balance
        }

        // ✅ TODO: Student must implement only this method
        public void Deposit(decimal amount, string note)
        {
            // TODO:
            // - validate amount > 0
            // - update _balance
            // - print receipt line with note (note can contain spaces/special chars)
            if(amount<=0)
                throw new Exception("Amount must be Greater than 0");
            _balance += amount;
            
            Console.WriteLine($"Account: {Id} | Balance: {_balance} | amount: {amount} | Note: {note}");
            // throw new NotImplementedException();
        }

        // ✅ TODO: Student must implement only this method
        public void Withdraw(decimal amount, string note)
        {
            // TODO:
            // - validate amount > 0
            // - validate amount <= _balance
            // - update _balance
            // - print receipt line with note
            if(amount <= 0)
                throw new Exception("Amount must be Greater than 0");
            if(amount > _balance)
                throw new Exception("Insufficient Balance");
            _balance -= amount;

            Console.WriteLine( $"Account: {Id} | Balance: {_balance} | amount: {amount} | Note: {note}");

            // throw new NotImplementedException();
        }

        public string GetSummary()
        {
            return $"Account[{Id}] {HolderName} | Balance={_balance}";          // summary string
        }
    }

    public static class InputParser
    {
        // ✅ TODO: Student must implement only this method
        public static decimal ParseAmount(string raw)
        {
            // TODO:
            // - handle currency symbols (₹, $, etc.)
            raw = raw.Replace("₹" , "")
                     .Replace("$", "")
                     .Replace(",", "")
                     .Replace("?", "")
                     .Trim();
            // - handle commas: "10,500.75"
            // - handle spaces: "₹ 1,999.25"
            // - return decimal value
            decimal value = decimal.Parse(raw);
            return value;
            // throw new NotImplementedException();
        }
    }

    public class Command
    {
        public string Name { get; }                                             // command name
        private readonly System.Collections.Generic.Dictionary<string, string> _kv; // parameters

        private Command(string name, System.Collections.Generic.Dictionary<string, string> kv)
        {
            Name = name;                                                        // assign
            _kv = kv;                                                           // assign
        }

        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : ""; // safe get

        public static Command Parse(string line)
        {
            // Very small parser: COMMAND|k=v|k="v with spaces"
            var parts = line.Split('|');                                        // split parts
            var name = parts[0].Trim();                                         // command name
            var kv = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 1; i < parts.Length; i++)                              // read key-value tokens
            {
                var p = parts[i];                                               // token
                var idx = p.IndexOf('=');                                       // locate '='
                if (idx <= 0) continue;                                         // skip invalid
                var key = p.Substring(0, idx).Trim();                           // key
                var val = p.Substring(idx + 1).Trim();                          // value
                val = val.Trim().Trim('"');                                    // remove quotes
                kv[key] = val;                                                  // store
            }

            return new Command(name, kv);                                       // build
        }
    }
}